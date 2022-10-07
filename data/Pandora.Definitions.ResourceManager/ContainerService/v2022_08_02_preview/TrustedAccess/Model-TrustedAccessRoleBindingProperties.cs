using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2022_08_02_preview.TrustedAccess;


internal class TrustedAccessRoleBindingPropertiesModel
{
    [JsonPropertyName("provisioningState")]
    public TrustedAccessRoleBindingProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("roles")]
    [Required]
    public List<string> Roles { get; set; }

    [JsonPropertyName("sourceResourceId")]
    [Required]
    public string SourceResourceId { get; set; }
}
