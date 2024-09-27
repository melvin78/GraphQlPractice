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
public static class BrandQueries
{

    [UsePaging]
    public static async Task<Connection<Brand>> GetBrandsAsync(PagingArguments pagingArguments,
        BrandService brandService,
        CancellationToken cancellationToken)
        => await brandService.GetBrandsAsync(pagingArguments, cancellationToken).ToConnectionAsync();

    [UseFirstOrDefault]
    public static IQueryable<Brand> GetBrandById(int id, CatalogContext context)
        => context.Brands.Where(t => t.Id == id);


}
