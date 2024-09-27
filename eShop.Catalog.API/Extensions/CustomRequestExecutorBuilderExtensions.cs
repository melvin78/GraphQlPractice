using eShop.Catalog.API.Filtering;
using HotChocolate.Execution.Configuration;

namespace eShop.Catalog.API.Extensions;

public static class CustomRequestExecutorBuilderExtensions
{
    public static IRequestExecutorBuilder AddGraphQLConventions(this IRequestExecutorBuilder builder)
    {
        builder.AddProjections()
            .AddFiltering(
                c => c.AddDefaults()
                    .BindRuntimeType<string, DefaultStringOperationFilterInputType>())
            .AddSorting();
        
        return builder;
    }
}