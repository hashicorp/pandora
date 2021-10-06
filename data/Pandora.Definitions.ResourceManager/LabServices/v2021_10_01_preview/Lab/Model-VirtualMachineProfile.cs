using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab
{

    internal class VirtualMachineProfileModel
    {
        [JsonPropertyName("additionalCapabilities")]
        public VirtualMachineAdditionalCapabilitiesModel? AdditionalCapabilities { get; set; }

        [JsonPropertyName("adminUser")]
        [Required]
        public CredentialsModel AdminUser { get; set; }

        [JsonPropertyName("createOption")]
        [Required]
        public CreateOptionConstant CreateOption { get; set; }

        [JsonPropertyName("imageReference")]
        [Required]
        public ImageReferenceModel ImageReference { get; set; }

        [JsonPropertyName("nonAdminUser")]
        public CredentialsModel? NonAdminUser { get; set; }

        [JsonPropertyName("osType")]
        public OsTypeConstant? OsType { get; set; }

        [JsonPropertyName("sku")]
        [Required]
        public SkuModel Sku { get; set; }

        [JsonPropertyName("usageQuota")]
        [Required]
        public string UsageQuota { get; set; }

        [JsonPropertyName("useSharedPassword")]
        public EnableStateConstant? UseSharedPassword { get; set; }
    }
}
