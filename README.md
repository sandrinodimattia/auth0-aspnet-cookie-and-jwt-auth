# Auth0 ASP.NET Cookie Authentication and Bearer Tokens Sample

This sample implements a scenario requested by a customer where:

 1. The user authenticates using the `Code Flow` in an ASP.NET MVC application (Cookie Authentication)
 2. In a secure zone of the application, the SPA is made available
 3. Then a token is exposed to the user
 4. The user is then able to call the ASP.NET Web API using the token (Bearer Token)

## Configuration

 1. Enter your Auth0 credentials in the `web.config`
 2. Set the callback URL in Auth0 to: http://localhost:4500/signin-auth0

## The Code

 - `Startup.cs`: This is where authentication is configured and the Web API is started.
 - `App_Start\Startup.Auth.cs`: Code for Cookie Authentication and Bearer Tokens
 - `Controllers\AppController.cs`: The ASP.NET MVC controller which is secured. The `Token` endpoint here exposes the token of the current user (and preventing CSRF attacks).
 - `Controllers\DemoApiController.cs`: The ASP.NET Web API controller secured with Bearer Tokens.
 - `Filters\AntiForgeryHeaderAttribute.cs`: A custom filter that will get the anti forgery token from a header and compare it to the anti forgery cookie.
 - `Views/App/Index.cshtml`: the "SPA" with some jQuery code that will first retrieve the token and then call the API with that token
