echo off

kubectl create namespace ms-arch-homework --dry-run=client -o yaml | kubectl apply -f -

kubectl apply -f .\health-deployment.yaml
kubectl apply -f .\health-service.yaml
kubectl apply -f .\health-ingress.yaml