using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

internal static class BrandDataLoader
{
    [DataLoader]
    internal static async Task<IReadOnlyDictionary<int, Brand>> GetBrandByIdAsync(IReadOnlyList<int> keys,
        CatalogContext catalogContext, CancellationToken cancellationToken)
        => await catalogContext.Brands.Where(x => keys.Contains(x.Id)).ToDictionaryAsync(x => x.Id, cancellationToken);

    [DataLoader]
    internal static async Task<IReadOnlyDictionary<string, Brand>> GetBrandByNameAsync(IReadOnlyList<string> keys,
        CatalogContext catalogContext, CancellationToken cancellationToken)
        => await catalogContext.Brands.Where(x => keys.Contains(x.Name)).ToDictionaryAsync(x => x.Name, cancellationToken);
    
}