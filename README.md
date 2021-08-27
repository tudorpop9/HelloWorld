# Hello world application backend course
Available at: https://pta-hello-world-container-p33.herokuapp.com/


## How to create a docker container and image of the project.
TO DO.. in HelloWorldWeb
```
docker build . -t tudor_hello_world_app 

```

```
docker run -d -p 8081:80 --name tudor_hello_world_container tudor_hello_world_app

```

## How to deploy to Heroku
1. Create heroku account
2. Create application
3. Choose container registry as deployment method
4. Make sure application works locally

Log in to Heroku and follow the cmd instructions
```
heroku login

```
Log in to Container Registry
You must have Docker set up locally to continue. You should see output when you run this command.
```

docker ps

```

Now you can sign into Container Registry.
```

heroku container:login

```

Build the Dockerfile in the current directory and push the Docker image, "pta-hello-world-container-p33" is the heroku application name.
```
heroku container:push -a pta-hello-world-container-p33 web

```

Release the newly pushed images to deploy the app.
```
heroku container:release -a pta-hello-world-container-p33 web

```
