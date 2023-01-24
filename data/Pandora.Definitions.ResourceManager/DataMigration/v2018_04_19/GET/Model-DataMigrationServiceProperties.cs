using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.GET;


internal class DataMigrationServicePropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public ServiceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicKey")]
    public string? PublicKey { get; set; }

    [JsonPropertyName("virtualSubnetId")]
    [Required]
    public string VirtualSubnetId { get; set; }
}
