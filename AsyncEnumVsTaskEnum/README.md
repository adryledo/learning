Build an image using the Dockerfile in the current directory`(.)` and name it *learn-async-img* with tag *v1*
```
docker build -t learn-async-img:v1 .
```

Create a container named *learn-async-cont* run it in the background`(-d)`, keeping STDIN open`(-i)` and allocate a pseudo-TTY`(-t)`
```
docker run -d -it --name learn-async-cont learn-async-img:v1
```
The previous is equivalent to `docker create` + `docker start`

(OPTIONAL) Execute the command `/bin/bash` in the running container to access its terminal
```
docker exec -it learn-async-cont /bin/bash
```
> With docker attach learn-async-cont you attach your terminal to the *ENTRYPOINT/CMD* process

View the logs our application left in the container
```
docker logs -f learn-async-cont
```

---
## Wipe our environment
List all containers including non-running
```
docker ps -a
```

(OPTIONAL) Remove the container
```
docker rm -f learn-async-cont
```

List the images
```
docker images
```

Remove the image even if the container is running
```
docker rmi -f learn-async-img:v1
```