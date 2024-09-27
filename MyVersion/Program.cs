using MyVersion.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<Dog>()
    .AddType<Cat>()
    .AddType<Parrot>()
    .ModifyOptions(o =>
        {
            o.EnableOneOf = true;
            o.StripLeadingIFromInterface = true;
        }
    );

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);




