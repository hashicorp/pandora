using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2019_06_01.RegistrationAssignments;


internal class RegistrationAssignmentPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("registrationDefinition")]
    public RegistrationAssignmentPropertiesRegistrationDefinitionModel? RegistrationDefinition { get; set; }

    [JsonPropertyName("registrationDefinitionId")]
    [Required]
    public string RegistrationDefinitionId { get; set; }
}
