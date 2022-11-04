using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2022_10_01.RegistrationAssignments;


internal class JustInTimeAccessPolicyModel
{
    [JsonPropertyName("managedByTenantApprovers")]
    public List<EligibleApproverModel>? ManagedByTenantApprovers { get; set; }

    [JsonPropertyName("maximumActivationDuration")]
    public string? MaximumActivationDuration { get; set; }

    [JsonPropertyName("multiFactorAuthProvider")]
    [Required]
    public MultiFactorAuthProviderConstant MultiFactorAuthProvider { get; set; }
}
