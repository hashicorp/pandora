using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups;


internal class ServerGroupPropertiesDelegatedSubnetArgumentsModel
{
    [JsonPropertyName("subnetArmResourceId")]
    public string? SubnetArmResourceId { get; set; }
}
