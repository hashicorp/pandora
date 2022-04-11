using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsAuthConfigs;


internal class IdentityProvidersModel
{
    [JsonPropertyName("apple")]
    public AppleModel? Apple { get; set; }

    [JsonPropertyName("azureActiveDirectory")]
    public AzureActiveDirectoryModel? AzureActiveDirectory { get; set; }

    [JsonPropertyName("azureStaticWebApps")]
    public AzureStaticWebAppsModel? AzureStaticWebApps { get; set; }

    [JsonPropertyName("customOpenIdConnectProviders")]
    public Dictionary<string, CustomOpenIdConnectProviderModel>? CustomOpenIdConnectProviders { get; set; }

    [JsonPropertyName("facebook")]
    public FacebookModel? Facebook { get; set; }

    [JsonPropertyName("gitHub")]
    public GitHubModel? GitHub { get; set; }

    [JsonPropertyName("google")]
    public GoogleModel? Google { get; set; }

    [JsonPropertyName("twitter")]
    public TwitterModel? Twitter { get; set; }
}
