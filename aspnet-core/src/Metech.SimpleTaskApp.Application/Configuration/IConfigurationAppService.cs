using System.Threading.Tasks;
using Metech.SimpleTaskApp.Configuration.Dto;

namespace Metech.SimpleTaskApp.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
