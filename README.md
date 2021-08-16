# Hello world application
Backend course

## How to create a docker container and image of the project.
TO DO..

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
heroku container:push pta-hello-world-container-p33 web

```

Release the newly pushed images to deploy the app.
```
heroku container:release pta-hello-world-container-p33 web

```
