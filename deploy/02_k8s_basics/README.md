# Basic Kubernetes (deployment, service, ingress)
Создание минимального сервиса

## Подготовка
1. Выполнить инструкции из [init](..\00_k8s_init\README.md)

## Разворачивание
### Windows
1. Выполнить в консоли:
    ```bash
    deploy.bat
    ```
### Отдельные команды
1. Добавляем Deployment:
     ```bash
    kubectl apply -f .\health-deployment.yaml
    ```
1. Добавляем Service:
     ```bash
    kubectl apply -f .\health-service.yaml
    ```
1. Добавляем Ingress:
     ```bash
    kubectl apply -f .\health-ingress.yaml
    ```

## Откат
### Windows
1. Выполнить в консоли:
    ```bash
    delete.bat
    ```
### Отдельные команды
1. Добавляем Ingress:
     ```bash
    kubectl delete -f .\health-ingress.yaml
    ```
1. Добавляем Service:
     ```bash
    kubectl delete -f .\health-service.yaml
    ```
1. Добавляем Deployment:
     ```bash
    kubectl delete -f .\health-deployment.yaml
    ```