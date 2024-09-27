

using HotChocolate;
using HotChocolate.Types;

[assembly: Module("ShippingType")]

namespace eShop.Shipping.Types;

[QueryType]
public static class Foo
{
    public static string Hello() => "Hello";
}