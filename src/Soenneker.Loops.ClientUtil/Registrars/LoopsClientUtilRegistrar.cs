using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Loops.Client.Registrars;
using Soenneker.Loops.ClientUtil.Abstract;

namespace Soenneker.Loops.ClientUtil.Registrars;

/// <summary>
/// Registers the lazily created Loops generated-client provider.
/// </summary>
public static class LoopsClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="ILoopsClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLoopsClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddLoopsHttpClientAsSingleton().TryAddSingleton<ILoopsClientUtil, LoopsClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="ILoopsClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLoopsClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddLoopsHttpClientAsSingleton().TryAddScoped<ILoopsClientUtil, LoopsClientUtil>();

        return services;
    }
}
