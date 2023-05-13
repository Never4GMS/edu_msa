# Basic Kubernetes (deployment, service, ingress)
Build minimal service in Kubernetes using Deployment, Service and Ingress

## Prepare
1. Execute instructions in [init](..\00_k8s_init\README.md)

## Deploy
### Windows
1. Execute in console:
    ```bash
    deploy.bat
    ```
### Отдельные команды
1. Add Deployment:
     ```bash
    kubectl apply -f .\health-deployment.yaml
    ```
1. Add Service:
     ```bash
    kubectl apply -f .\health-service.yaml
    ```
1. Add Ingress:
     ```bash
    kubectl apply -f .\health-ingress.yaml
    ```

## Rollback
### Windows
1. Execute in console:
    ```bash
    delete.bat
    ```
### Отдельные команды
1. Add Ingress:
     ```bash
    kubectl delete -f .\health-ingress.yaml
    ```
1. Add Service:
     ```bash
    kubectl delete -f .\health-service.yaml
    ```
1. Add Deployment:
     ```bash
    kubectl delete -f .\health-deployment.yaml
    ```