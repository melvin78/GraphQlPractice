using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

public class Query
{

    [UsePaging]
    [UseProjection]
    [UseFiltering]
    public IQueryable<Brand> GetBrands(CatalogContext context)
        => context.Brands;

    [UseFirstOrDefault]
    public IQueryable<Brand> GetBrandById(int id, CatalogContext context)
        => context.Brands.Where(t => t.Id == id);
    
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Product> GetProduct(CatalogContext context, IFilterContext filterContext, ISortingContext sortingContext)
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

    [UsePaging]
    [UseProjection]
    public IQueryable<ProductType> GetProductTypes(CatalogContext context)
        => context.ProductTypes;

    [UseFirstOrDefault]
    [UseProjection]
    public IQueryable<Product?> GetProductById(int id, CatalogContext context)
        => context.Products.Where(t => t.Id == id);

    [UseFirstOrDefault]
    [UseProjection]
    [UseFiltering]
    public IQueryable<ProductType?> GetProductTypeById(int id, CatalogContext context)
        => context.ProductTypes.Where(t => t.Id == id);
}
