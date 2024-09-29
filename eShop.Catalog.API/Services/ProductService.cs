using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Pagination;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

public sealed class ProductService(CatalogContext context, IProductByIdDataLoader productByIdDataLoader, IProductByNameDataLoader productByNameDataLoader)
{

    public async Task<Page<Product>> GetProductsAsync(PagingArguments pagingArguments, CancellationToken cancellationToken = default)
    {
        return await context.Products.OrderBy(x => x.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);

    }

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await productByIdDataLoader.LoadAsync(id, cancellationToken);
    }
    
    public async Task<Product?> GetProductByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await productByNameDataLoader.LoadAsync(name, cancellationToken);
    }
    
}