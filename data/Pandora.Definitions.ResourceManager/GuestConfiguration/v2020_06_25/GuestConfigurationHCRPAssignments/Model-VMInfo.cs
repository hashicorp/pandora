using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationHCRPAssignments;


internal class VMInfoModel
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("uuid")]
    public string? Uuid { get; set; }
}
