using eShop.Catalog.API.Types.Filtering;
using HotChocolate.Execution.Configuration;

namespace eShop.Catalog.API.Extensions;

public static class CustomRequestExecutorBuilderExtensions
{
    public static IRequestExecutorBuilder AddGraphQlConventions(this IRequestExecutorBuilder builder)
    {
        builder.AddProjections()
            .AddFiltering(
                c => c.AddDefaults()
                    .BindRuntimeType<string, DefaultStringOperationFilterInputType>())
            .AddSorting()
            .AddPagingArguments();
        
        return builder;
    }
}