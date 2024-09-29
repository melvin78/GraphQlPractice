using eShop.Catalog.API.Models;
using eShop.Catalog.API.Services;

namespace eShop.Catalog.API.Types;

[ObjectType<Brand>]
public static partial class BrandNode
{
    static partial void Configure(IObjectTypeDescriptor<Brand> descriptor)
    {
    }

    public static async Task<Product?> GetProductAsync([Parent] Brand brand, ProductService productService)
        => await productService.GetProductByIdAsync(brand.Id);

    public static async Task<Product?> GetProductByBrandNameAsync([Parent] Brand brand, ProductService productService)
        => await productService.GetProductByNameAsync(brand.Name);
}