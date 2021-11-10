using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DataLakeStore.v2016_11_01.Accounts
{

    internal class EncryptionConfigModel
    {
        [JsonPropertyName("keyVaultMetaInfo")]
        public KeyVaultMetaInfoModel? KeyVaultMetaInfo { get; set; }

        [JsonPropertyName("type")]
        [Required]
        public EncryptionConfigTypeConstant Type { get; set; }
    }
}
