using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductQueries
{
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Product> GetProduct(CatalogContext context, IFilterContext filterContext, ISortingContext sortingContext)
    {
        filterContext.Handled(false);
        sortingContext.Handled(false);

        IQueryable<Product> query = context.Products;
        
        if (!filterContext.IsDefined)
        {
            query = query.Where(t => t.BrandId == 1);
        }

        if (!sortingContext.IsDefined)
        {
            query = query.OrderBy(t => t.Brand!.Name).ThenByDescending(t => t.Price);
        }
        
        
        return query;
    }
    

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Product?> GetProductById(int id, CatalogContext context)
        => context.Products.Where(t => t.Id == id);

}
