//Creates a webApplication Builder using the CreateBuilder Method
var builder = WebApplication.CreateBuilder(args);
//Build and Return an instance from WebApplication Builder
var app = builder.Build();

//Defines an Endpoint for application , return "Hello world" when the path "/" is callled  -- path: reminder of the request URL after domain remove
app.MapGet("/", () => "Hello World!");

//Runs the Application to start listening for requests and generating responses
app.Run();
