using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

internal static class ProductTypeDataLoader
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, ProductType>> GetProductTypeByIdAsync(IReadOnlyList<int> keys,
        CatalogContext catalogContext, CancellationToken cancellationToken)
        => await catalogContext.ProductTypes.Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id, cancellationToken);
    
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<string, ProductType>> GetProductTypeByNameAsync(IReadOnlyList<string> keys,
        CatalogContext catalogContext, CancellationToken cancellationToken)
        => await catalogContext.ProductTypes.Where(x => keys.Contains(x.Name)).ToDictionaryAsync(x => x.Name, cancellationToken);
}