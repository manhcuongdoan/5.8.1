using System.Collections.Generic;

namespace Metech.SimpleTaskApp.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
