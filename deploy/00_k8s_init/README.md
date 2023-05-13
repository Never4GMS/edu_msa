# Prepare Kuberneters
Initial steps for upcomming parts

## Deployment
### On Windows
1. Execute in console:
    ```bash
    ..\init.bat
    ```

### On any environment
1. Add namespace to k8s:
    ```bash
    kubectl create namespace ms-arch-homework --dry-run=client -o yaml | kubectl apply -f -
    ```
1. **[Optional]** Add Ingress Nginx to minikube:
    ```bash
    helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx/ && helm repo update && helm install nginx ingress-nginx/ingress-nginx --namespace ms-arch-homework -f nginx-ingress.yaml
    ```