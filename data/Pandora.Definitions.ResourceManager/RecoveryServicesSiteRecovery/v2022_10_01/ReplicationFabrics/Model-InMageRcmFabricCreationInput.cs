using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationFabrics;

[ValueForType("InMageRcm")]
internal class InMageRcmFabricCreationInputModel : FabricSpecificCreationInputModel
{
    [JsonPropertyName("physicalSiteId")]
    [Required]
    public string PhysicalSiteId { get; set; }

    [JsonPropertyName("sourceAgentIdentity")]
    [Required]
    public IdentityProviderInputModel SourceAgentIdentity { get; set; }

    [JsonPropertyName("vmwareSiteId")]
    [Required]
    public string VmwareSiteId { get; set; }
}
