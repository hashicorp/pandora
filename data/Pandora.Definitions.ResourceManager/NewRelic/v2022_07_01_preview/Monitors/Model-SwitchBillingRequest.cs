using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01_preview.Monitors;


internal class SwitchBillingRequestModel
{
    [JsonPropertyName("azureResourceId")]
    public string? AzureResourceId { get; set; }

    [JsonPropertyName("organizationId")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("planData")]
    public PlanDataModel? PlanData { get; set; }

    [JsonPropertyName("userEmail")]
    [Required]
    public string UserEmail { get; set; }
}
