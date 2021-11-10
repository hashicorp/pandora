using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{

    internal class CreateDataLakeStoreAccountParametersModel
    {
        [JsonPropertyName("identity")]
        public CustomTypes.SystemAssignedIdentity? Identity { get; set; }

        [JsonPropertyName("location")]
        [Required]
        public CustomTypes.Location Location { get; set; }

        [JsonPropertyName("properties")]
        public CreateDataLakeStoreAccountPropertiesModel? Properties { get; set; }

        [JsonPropertyName("tags")]
        public CustomTypes.Tags? Tags { get; set; }
    }
}
