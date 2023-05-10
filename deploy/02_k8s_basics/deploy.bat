echo off

kubectl apply -f .\health-deployment.yaml
kubectl apply -f .\health-service.yaml
kubectl apply -f .\health-ingress.yaml