using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class BrandQueries
{
    
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    public static IQueryable<Brand> GetBrands(CatalogContext context)
        => context.Brands;

    [UseFirstOrDefault]
    public static IQueryable<Brand> GetBrandById(int id, CatalogContext context)
        => context.Brands.Where(t => t.Id == id);


}
