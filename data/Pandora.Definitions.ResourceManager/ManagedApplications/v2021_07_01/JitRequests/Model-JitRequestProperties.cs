using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.JitRequests;


internal class JitRequestPropertiesModel
{
    [JsonPropertyName("applicationResourceId")]
    [Required]
    public string ApplicationResourceId { get; set; }

    [JsonPropertyName("createdBy")]
    public ApplicationClientDetailsModel? CreatedBy { get; set; }

    [JsonPropertyName("jitAuthorizationPolicies")]
    [Required]
    public List<JitAuthorizationPoliciesModel> JitAuthorizationPolicies { get; set; }

    [JsonPropertyName("jitRequestState")]
    public JitRequestStateConstant? JitRequestState { get; set; }

    [JsonPropertyName("jitSchedulingPolicy")]
    [Required]
    public JitSchedulingPolicyModel JitSchedulingPolicy { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publisherTenantId")]
    public string? PublisherTenantId { get; set; }

    [JsonPropertyName("updatedBy")]
    public ApplicationClientDetailsModel? UpdatedBy { get; set; }
}
