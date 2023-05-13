# Minimal app with health check
Exploring health checks

## Depoyment
### Docker
Execute in console:
```bash
docker run --name health -p 127.0.0.1:80:80/tcp -d mrjobzzz/healthservice:1.0.2 
```

## Using
Make request to health endpoint:
```bash
curl 127.0.0.1/health
```

Respone:
```json
{
    "status": "OK"
}
```