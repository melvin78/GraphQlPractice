using eShop.Catalog.API.Data;
using eShop.Catalog.API.Models;
using HotChocolate.Pagination;
using Microsoft.EntityFrameworkCore;

namespace eShop.Catalog.API.Services;

public sealed class ProductTypeService(CatalogContext context)
{
    public async Task<Page<ProductType>> GetProductsAsync(PagingArguments pagingArguments, CancellationToken cancellationToken = default)
    {
        return await context.ProductTypes.OrderBy(x => x.Name)
            .ThenBy(t => t.Id)
            .ToPageAsync(pagingArguments, cancellationToken);

    }

    public async Task<ProductType?> GetProductTypeByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await context.ProductTypes.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}