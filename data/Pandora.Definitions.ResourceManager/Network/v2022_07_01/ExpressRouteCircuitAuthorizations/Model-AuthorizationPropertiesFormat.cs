using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2022_07_01.ExpressRouteCircuitAuthorizations;


internal class AuthorizationPropertiesFormatModel
{
    [JsonPropertyName("authorizationKey")]
    public string? AuthorizationKey { get; set; }

    [JsonPropertyName("authorizationUseStatus")]
    public AuthorizationUseStatusConstant? AuthorizationUseStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
