using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using eShop.Catalog.API.Services;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Sorting;
using HotChocolate.Pagination;
using HotChocolate.Types.Pagination;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Types;

[QueryType]
public static class ProductQueries
{

    [UsePaging]
    public static async Task<Connection<Product>> GetProductsAsync(
        PagingArguments pagingArguments,
        ProductService productService,
        CancellationToken cancellationToken)
        => await productService.GetProductsAsync(pagingArguments,cancellationToken).ToConnectionAsync();
    

    [UseFirstOrDefault]
    [UseProjection]
    public static IQueryable<Product?> GetProductById(int id, CatalogContext context)
        => context.Products.Where(t => t.Id == id);

}
