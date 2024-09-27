using eShop.Catalog.API.Data;
using eShop.Catalog.API.Extensions;
using eShop.Catalog.API.Migrations;
using eShop.Catalog.API.Services;
using eShop.Catalog.API.Sorting;
using eShop.Catalog.API.Types;
using HotChocolate.Data.Filters;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddCatalogTypes()
    .AddShippingType()
    .AddGraphQlConventions();

builder.Services
    .AddDbContext<CatalogContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("CatalogDB")));

builder.Services.AddDbContext<CatalogContext>();

builder.Services
    .AddScoped<ProductService>()
    .AddScoped<BrandService>()
    .AddScoped<ProductTypeService>();

builder.Services
    .AddMigration<CatalogContext, CatalogContextSeed>();

var app = builder.Build();

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
