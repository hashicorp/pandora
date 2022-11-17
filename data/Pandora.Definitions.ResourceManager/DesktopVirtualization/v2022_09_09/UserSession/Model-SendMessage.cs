using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.UserSession;


internal class SendMessageModel
{
    [JsonPropertyName("messageBody")]
    public string? MessageBody { get; set; }

    [JsonPropertyName("messageTitle")]
    public string? MessageTitle { get; set; }
}
