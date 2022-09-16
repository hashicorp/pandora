using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.Workspaces;


internal class CustomerManagedKeyDetailsModel
{
    [JsonPropertyName("kekIdentity")]
    public KekIdentityPropertiesModel? KekIdentity { get; set; }

    [JsonPropertyName("key")]
    public WorkspaceKeyDetailsModel? Key { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
