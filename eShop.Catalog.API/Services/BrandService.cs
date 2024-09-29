using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using eShop.Catalog.API.Types;
using HotChocolate.Pagination;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

public sealed class BrandService(CatalogContext context, IBrandByIdDataLoader brandByIdDataLoader, IBrandByNameDataLoader brandByNameDataLoader)
{
    public async Task<Page<Brand>> GetBrandsAsync(PagingArguments pagingArguments, CancellationToken cancellationToken = default)
    {
        return await context.Brands.OrderBy(x => x.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);

    }

    public async Task<Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await brandByIdDataLoader.LoadAsync(id, cancellationToken);
    }

    public async Task<Brand?> GetBrandByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        if (!string.IsNullOrEmpty(name))
        {
            return await brandByNameDataLoader.LoadAsync(name, cancellationToken);
        }

        return null;
    }
}