using Microsoft.AspNetCore.HttpLogging;

//Creates a webApplication Builder using the CreateBuilder Method
var builder = WebApplication.CreateBuilder(args);

//Customizing the Sevices of the Application
builder.Services.AddHttpLogging(
        opts => opts.LoggingFields = HttpLoggingFields.RequestProperties);

//Ensure that logs added by Httplogging middleware are visible on the log output
builder.Logging.AddFilter(
        "Miscrosoft.AspNetCore.HttpLogging",LogLevel.Information
    );

//Build and Return an instance from WebApplication Builder
var app = builder.Build();

//add middleware conditionally ,depending on runtime environment
if (app.Environment.IsDevelopment()) 
{
    //Http logging middleware logs each request to your application in the log output
    app.UseHttpLogging();
}

//Defines an Endpoint for application , return "Hello world" when the path "/" is callled  -- path: reminder of the request URL after domain remove
app.MapGet("/", () => "Hello World!");

//Creates a new endpoint that returns the C# object serialized as JSON
app.MapGet("/person", () => new Person("Iman", "Sabet"));

//Runs the Application to start listening for requests and generating responses
app.Run();

//Create a Record Type
public record Person(string FirstName,string LastName);
