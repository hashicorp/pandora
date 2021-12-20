using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.StoragePool.v2021_08_01.ResourceSkus
{

    internal class ResourceSkuRestrictionsModel
    {
        [JsonPropertyName("reasonCode")]
        public ResourceSkuRestrictionsReasonCodeConstant? ReasonCode { get; set; }

        [JsonPropertyName("restrictionInfo")]
        public ResourceSkuRestrictionInfoModel? RestrictionInfo { get; set; }

        [JsonPropertyName("type")]
        public ResourceSkuRestrictionsTypeConstant? Type { get; set; }

        [JsonPropertyName("values")]
        public List<string>? Values { get; set; }
    }
}
