using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeDesignPlus.Core.Abstractions
{
    /// <summary>
    /// Especificación del contrato para la administración de servicios personalizados en el SDK CodeDesignPlus
    /// </summary>
    public interface IStartupServices
    {
        /// <summary>
        /// Este metodo es invocado por el SDK CodeDesignPlus en el momento de iniciar la aplicación para registrar servicios personalizados.
        /// </summary>
        /// <param name="services">Provee acceso al contenedor de dependencias de .net core</param>
        /// <param name="configuration">Provee acceso a las diferentes fuentes de configuración</param>
        void Initialize(IServiceCollection services, IConfiguration configuration);
    }
}
