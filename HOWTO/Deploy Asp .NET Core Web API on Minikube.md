SETUP ENVIRONMENT:
choco install virtualbox
choco install minikube -y
minikube start --driver=virtualbox
minikube status
kubectl get nodes
choco install docker-cli -y
minikube docker-env --> copy all the set variableX and execute them on Powershell(may need --shell=powershell)
docker ps
minikube ip

CREATE API image
docker build -t test-minikube:v1 .
docker images

PS C:\Users\adri\source\repos\TestMinikube> kubectl config get-contexts
CURRENT   NAME       CLUSTER    AUTHINFO   NAMESPACE
*         minikube   minikube   minikube

CREATE deployment.yml
PS C:\Users\adri\source\repos\TestMinikube> kubectl apply -f deployment.yml
deployment.apps/test-minikube-dpl created
PS C:\Users\adri\source\repos\TestMinikube> kubectl get deployments
NAME                  READY   UP-TO-DATE   AVAILABLE   AGE
test-minikube-dpl   1/1     1            1           21s
PS C:\Users\adri\source\repos\TestMinikube> kubectl get pods
NAME                                  READY   STATUS    RESTARTS   AGE
test-minikube-dpl-7767448bc-gnjb7   1/1     Running   0          30s
PS C:\Users\adri\source\repos\TestMinikube> kubectl logs test-minikube-dpl-7767448bc-gnjb7
[40m[32minfo[39m[22m[49m: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://[::]:80
[40m[32minfo[39m[22m[49m: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
[40m[32minfo[39m[22m[49m: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
[40m[32minfo[39m[22m[49m: Microsoft.Hosting.Lifetime[0]
      Content root path: /app

CREATE service.yml and add type: LoadBalancer
PS C:\Users\adri\source\repos\TestMinikube> kubectl apply -f .\service.yml
service/test-minikube-srv created
PS C:\Users\adri\source\repos\TestMinikube> kubectl get services
NAME                  TYPE           CLUSTER-IP      EXTERNAL-IP   PORT(S)          AGE
kubernetes            ClusterIP      10.96.0.1       <none>        443/TCP          158m
test-minikube-srv   LoadBalancer   10.109.31.107   <pending>     8080:30187/TCP   10s
PS C:\Users\adri\source\repos\TestMinikube> minikube service test-minikube-srv
|-----------|---------------------|-------------|-----------------------------|
| NAMESPACE |        NAME         | TARGET PORT |             URL             |
|-----------|---------------------|-------------|-----------------------------|
| default   | test-minikube-srv |        8080 | http://192.168.99.100:32123 |
|-----------|---------------------|-------------|-----------------------------|
* Opening service default/test-minikube-srv in default browser...

Now the API can be accessed http://192.168.99.100:32123/endpoint