using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_05_01.DppResourceGuardProxies;


internal class UnlockDeleteRequestModel
{
    [JsonPropertyName("resourceGuardOperationRequests")]
    public List<string>? ResourceGuardOperationRequests { get; set; }

    [JsonPropertyName("resourceToBeDeleted")]
    public string? ResourceToBeDeleted { get; set; }
}
