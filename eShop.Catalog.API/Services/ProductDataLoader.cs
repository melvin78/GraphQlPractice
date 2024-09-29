using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Pagination;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

internal static class ProductDataLoader
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Product>> GetProductByIdAsync(IReadOnlyList<int> keys,
        CatalogContext catalogContext, CancellationToken cancellationToken)
        => await catalogContext.Products.AsNoTracking().Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id, cancellationToken);
    
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<string, Product>> GetProductByNameAsync(IReadOnlyList<string> keys,
        CatalogContext catalogContext, CancellationToken cancellationToken)
        => await catalogContext.Products.Where(x => keys.Contains(x.Name)).ToDictionaryAsync(x => x.Name, cancellationToken);
    


}

public readonly record struct PageKey<T>(T Key, PagingArguments PagingArgs);