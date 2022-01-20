using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeAnalytics.v2016_11_01.Accounts;


internal class HiveMetastorePropertiesModel
{
    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [JsonPropertyName("nestedResourceProvisioningState")]
    public NestedResourceProvisioningStateConstant? NestedResourceProvisioningState { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("runtimeVersion")]
    public string? RuntimeVersion { get; set; }

    [JsonPropertyName("serverUri")]
    public string? ServerUri { get; set; }

    [JsonPropertyName("userName")]
    public string? UserName { get; set; }
}
