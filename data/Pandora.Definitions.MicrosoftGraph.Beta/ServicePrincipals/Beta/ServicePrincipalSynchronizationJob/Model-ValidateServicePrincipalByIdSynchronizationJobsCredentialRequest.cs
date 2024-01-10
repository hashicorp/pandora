// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.ServicePrincipals.Beta.ServicePrincipalSynchronizationJob;

internal class ValidateServicePrincipalByIdSynchronizationJobsCredentialRequestModel
{
    [JsonPropertyName("applicationIdentifier")]
    public string? ApplicationIdentifier { get; set; }

    [JsonPropertyName("credentials")]
    public List<SynchronizationSecretKeyStringValuePairModel>? Credentials { get; set; }

    [JsonPropertyName("templateId")]
    public string? TemplateId { get; set; }

    [JsonPropertyName("useSavedCredentials")]
    public bool? UseSavedCredentials { get; set; }
}
