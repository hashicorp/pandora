using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.SecurityPINs;


internal class TokenInformationModel
{
    [JsonPropertyName("expiryTimeInUtcTicks")]
    public int? ExpiryTimeInUtcTicks { get; set; }

    [JsonPropertyName("securityPIN")]
    public string? SecurityPIN { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}
