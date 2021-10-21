using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{

    internal class AccessPolicyPropertiesModel
    {
        [JsonPropertyName("authentication")]
        public AuthenticationBaseModel? Authentication { get; set; }

        [JsonPropertyName("role")]
        public AccessPolicyRoleConstant? Role { get; set; }
    }
}
