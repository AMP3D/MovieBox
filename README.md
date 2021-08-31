## Dependencies

Install [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) ([Download Link - Windows](https://dotnet.microsoft.com/download/dotnet/thank-you/sdk-5.0.400-windows-x64-installer))

Install [Node](https://nodejs.org) ([Download Link - Windows](https://nodejs.org/dist/v14.17.6/node-v14.17.6-x64.msi): 

## Install UI Packages

From `.\web`:
```
npm install
```

## Usage

From `.\api\Moviebox`
```
dotnet build
```
```
dotnet run --no-build
```

Go to [http://localhost:5000](http://localhost:5000)

Go to [http://localhost:5000/swagger](http://localhost:5000/swagger) for swagger API

## Login

The `/api​/users​/login` can be used to login with this json-body and credentials:
```
{
  "password": "admin",
  "userName": "@bc123#$456"
}
```

A Bearer access token is generated and returned from the endpoint. In the swagger page, this token can be used to login from the "Authorize" button at the top.
Logging in enables you to create a movie using the `/api/movies/movie` endpoint.

## Project Scope

This project aims to provide a demo imitating a movie rental experience with mocked data. 
The project uses ASP.NET 5 for the back-end API, SQLite for the database, and Vue3 for the front-end UI.

## Design

### API 

For the API, I used the mediatr library to decouple the controller from the logic.

There are several distinct areas/libraries within the API solution:
- **MovieBox**: The main API and entry point containing the controller classes.
- **MovieBox.Common**: Shared objects amongst the solution (e.g. Models and custom Exceptions).
- **MovieBox.DAO**: Data-access layer where the SQLite DB queries are executed using Dapper.
- **MovieBox.Logic**: Business logic using Mediatr which utilizes the query-command-handler pattern.
- **MovieBox.Validation**: Validation of models using FluentValidation.

#### Notes
The login functionality uses a custom JWT token and automatically appends the "admin" role for ease of use and to save time.

Due to time constraints, these features were not (fully) implemented:
- Getting movies by category (e.g. New Release) and genre (e.g. Comedy).
- Updating a movie's info.
- Playing a movie (on-demand).
- Purchasing a movie or renting a movie.
- Managing user information/profiles.

### UI

The UI project is written in TypeScript using Vue3, Vuex, Vue-Router, BootStrap, and FontAwesome.

There are 3 primary views:
- **Movies**: Displays a list of all movies using a "swiper" UI component.
- **MovieDetails**: After clicking on a movie from the Movies page, this page displays the details of the movie. It also simulates (no-functionality) buying, renting, and playing a movie.
- **User**: This page serves as both the "My Profile" page which displays user information (not currently implemented) and the "Login" page. If a user is logged in, the "Login" menu item in the navbar turns into "My Profile" and a "Log Out" button appears. On logout, the "My Profile" page turns back into "Login".

#### Notes
The Vuex store persists its data to local storage, so when you refresh the page, the application doesn't reset.
It currently stores the movies list after fetching it from the API, the current movie (when a user clicks on a movie from the list), and the accessToken when a user logs in.

Due to time constraints, these features were not (fully) implemented:
- User Profile/My Profile.
- Adding a movie.
- Modifying movie data.