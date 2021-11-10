using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{

    internal class DataLakeStoreAccountPropertiesBasicModel
    {
        [JsonPropertyName("accountId")]
        public string? AccountId { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime { get; set; }

        [JsonPropertyName("endpoint")]
        public string? Endpoint { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("lastModifiedTime")]
        public DateTime? LastModifiedTime { get; set; }

        [JsonPropertyName("provisioningState")]
        public DataLakeStoreAccountStatusConstant? ProvisioningState { get; set; }

        [JsonPropertyName("state")]
        public DataLakeStoreAccountStateConstant? State { get; set; }
    }
}
