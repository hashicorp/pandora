using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.HostPool;


internal class RegistrationInfoModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationTime")]
    public DateTime? ExpirationTime { get; set; }

    [JsonPropertyName("registrationTokenOperation")]
    public RegistrationTokenOperationConstant? RegistrationTokenOperation { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}
