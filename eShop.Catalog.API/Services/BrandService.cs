using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Pagination;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

public sealed class BrandService(CatalogContext context)
{
    public async Task<Page<Brand>> GetBrandsAsync(PagingArguments pagingArguments, CancellationToken cancellationToken = default)
    {
        return await context.Brands.OrderBy(x => x.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);

    }

    public async Task<Brand?> GetBrandByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.Brands.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}