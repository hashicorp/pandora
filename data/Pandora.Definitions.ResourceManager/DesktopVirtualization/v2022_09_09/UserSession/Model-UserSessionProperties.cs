using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.UserSession;


internal class UserSessionPropertiesModel
{
    [JsonPropertyName("activeDirectoryUserName")]
    public string? ActiveDirectoryUserName { get; set; }

    [JsonPropertyName("applicationType")]
    public ApplicationTypeConstant? ApplicationType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createTime")]
    public DateTime? CreateTime { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("sessionState")]
    public SessionStateConstant? SessionState { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }
}
