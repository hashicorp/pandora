using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2022_08_01.ContentKeyPolicies;

[ValueForType("#Microsoft.Media.ContentKeyPolicyFairPlayConfiguration")]
internal class ContentKeyPolicyFairPlayConfigurationModel : ContentKeyPolicyConfigurationModel
{
    [JsonPropertyName("ask")]
    [Required]
    public string Ask { get; set; }

    [JsonPropertyName("fairPlayPfx")]
    [Required]
    public string FairPlayPfx { get; set; }

    [JsonPropertyName("fairPlayPfxPassword")]
    [Required]
    public string FairPlayPfxPassword { get; set; }

    [JsonPropertyName("offlineRentalConfiguration")]
    public ContentKeyPolicyFairPlayOfflineRentalConfigurationModel? OfflineRentalConfiguration { get; set; }

    [JsonPropertyName("rentalAndLeaseKeyType")]
    [Required]
    public ContentKeyPolicyFairPlayRentalAndLeaseKeyTypeConstant RentalAndLeaseKeyType { get; set; }

    [JsonPropertyName("rentalDuration")]
    [Required]
    public int RentalDuration { get; set; }
}
