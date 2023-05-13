using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSA.User.Api.ApiModels;
using MSA.User.Infrastructure;

namespace MSA.User.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;

        public UserController(
            UserDbContext dbContext,
            IMapper mapper,
            ILogger<UserController> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{userId}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Task<ApiModels.User?> GetAsync(long userId) => _mapper
            .ProjectTo<ApiModels.User>(
                _dbContext.Users.Where(u => u.Id == userId))
            .FirstOrDefaultAsync();

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] NewUser user)
        {
            var entity = _dbContext.Users.Add(_mapper.Map<Domain.User>(user));
            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("User created. UserId: {userId}", entity.Entity.Id);

            return CreatedAtAction(nameof(GetAsync), new { userId = entity.Entity.Id });
        }

        [HttpPut("{userId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(long userId, [FromBody] NewUser user)
        {
            var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (dbUser == null)
            {
                return NotFound();
            }

            _mapper.Map(user, dbUser);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("User updated. UserId: {userId}", userId);

            return Ok();
        }

        [HttpDelete("{userId}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(long userId)
        {
            var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (dbUser == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(dbUser);

            await _dbContext.SaveChangesAsync();

            _logger.LogInformation("User deleted. UserId: {userId}", userId);

            return Ok();
        }
    }
}
