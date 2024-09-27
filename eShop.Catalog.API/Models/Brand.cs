// ReSharper disable CollectionNeverUpdated.Global

using System.ComponentModel.DataAnnotations;
using eShop.Catalog.API.Types;
using eShop.Catalog.API.Types.Configuration;

namespace eShop.Catalog.API.Models;

public sealed class Brand
{
    public int Id { get; set; }

    [Required]
    [UseToUpper]
    public string Name { get; set; } = default!;
    
    public string? OtherName { get; set; }

    public ICollection<Product> Products { get; } = new List<Product>();
}
