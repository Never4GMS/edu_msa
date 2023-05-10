echo off

kubectl delete -f .\health-ingress.yaml
kubectl delete -f .\health-service.yaml
kubectl delete -f .\health-deployment.yaml