using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationFabrics;


internal class IdentityProviderInputModel
{
    [JsonPropertyName("aadAuthority")]
    [Required]
    public string AadAuthority { get; set; }

    [JsonPropertyName("applicationId")]
    [Required]
    public string ApplicationId { get; set; }

    [JsonPropertyName("audience")]
    [Required]
    public string Audience { get; set; }

    [JsonPropertyName("objectId")]
    [Required]
    public string ObjectId { get; set; }

    [JsonPropertyName("tenantId")]
    [Required]
    public string TenantId { get; set; }
}
