using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductTypeQueries
{
    
    [UsePaging]
    [UseProjection]
    public static IQueryable<ProductType> GetProductTypes(CatalogContext context)
        => context.ProductTypes;
    
    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public static IQueryable<ProductType?> GetProductTypeById(int id, CatalogContext context)
        => context.ProductTypes.Where(t => t.Id == id);
}
