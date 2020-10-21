using Abp.AutoMapper;
using Metech.SimpleTaskApp.Authentication.External;

namespace Metech.SimpleTaskApp.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
