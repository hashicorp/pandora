using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ConnectionGateways;


internal class ConnectionGatewayInstallationDefinitionCollectionModel
{
    [JsonPropertyName("value")]
    public List<ConnectionGatewayInstallationDefinitionModel>? Value { get; set; }
}
