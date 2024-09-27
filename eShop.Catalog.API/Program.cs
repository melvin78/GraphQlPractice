using eShop.Catalog.API.Data;
using eShop.Catalog.API.Extensions;
using eShop.Catalog.API.Filtering;
using eShop.Catalog.API.Migrations;
using eShop.Catalog.API.Sorting;
using eShop.Catalog.API.Types;
using HotChocolate.Data.Filters;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<ProductFilterInputType>()
    .ModifyRequestOptions(e =>
    {
        e.IncludeExceptionDetails = true;
    })
    .AddType<ProductSortInputType>()
    .AddGraphQLConventions();

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services.AddDbContext<CatalogContext>();

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
