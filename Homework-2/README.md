# LC Waikiki BootCamp 2nd Homework

This project is a simple movie API with two tables

>End points in movie table are:

HTTP|RETURN|DESCRIPTION|
|---|---|---|
|GET|`List<Movie>`| Gets the list of movies|
|POST|`MovieResource`| Adds a movie to the table|
|PUT|`MovieResource`| Updates the movie|
|DELETE|`MovieResource`| Deletes the movie|
|PUT|`SearchMovieResource`| Searches the given parameters|
---

>End points in director table are same as movie table only the parameters are changed
>How To Run

You need to install the MS SQL to your computer than edit the connection string for your liking.
After that you need to run this commands

```sh
dotnet ef migrations add init
dotnet ef database update
```

whit this commands the database will be automatically created

then you can run the project with

```sh
dotnet run
```

this command and you can explore with [swagger ui](https://localhost:5001/swagger/index.html)
Have Fun!
