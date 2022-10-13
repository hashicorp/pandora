using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01.ReplicationRecoveryServicesProviders;


internal class AddRecoveryServicesProviderInputPropertiesModel
{
    [JsonPropertyName("authenticationIdentityInput")]
    [Required]
    public IdentityProviderInputModel AuthenticationIdentityInput { get; set; }

    [JsonPropertyName("biosId")]
    public string? BiosId { get; set; }

    [JsonPropertyName("dataPlaneAuthenticationIdentityInput")]
    public IdentityProviderInputModel? DataPlaneAuthenticationIdentityInput { get; set; }

    [JsonPropertyName("machineId")]
    public string? MachineId { get; set; }

    [JsonPropertyName("machineName")]
    [Required]
    public string MachineName { get; set; }

    [JsonPropertyName("resourceAccessIdentityInput")]
    [Required]
    public IdentityProviderInputModel ResourceAccessIdentityInput { get; set; }
}
