using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.ContentKeyPolicies;

[ValueForType("#Microsoft.Media.ContentKeyPolicyPlayReadyConfiguration")]
internal class ContentKeyPolicyPlayReadyConfigurationModel : ContentKeyPolicyConfigurationModel
{
    [JsonPropertyName("licenses")]
    [Required]
    public List<ContentKeyPolicyPlayReadyLicenseModel> Licenses { get; set; }

    [JsonPropertyName("responseCustomData")]
    public string? ResponseCustomData { get; set; }
}
