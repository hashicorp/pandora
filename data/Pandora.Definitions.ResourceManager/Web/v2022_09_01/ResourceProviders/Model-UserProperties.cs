using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;


internal class UserPropertiesModel
{
    [JsonPropertyName("publishingPassword")]
    public string? PublishingPassword { get; set; }

    [JsonPropertyName("publishingPasswordHash")]
    public string? PublishingPasswordHash { get; set; }

    [JsonPropertyName("publishingPasswordHashSalt")]
    public string? PublishingPasswordHashSalt { get; set; }

    [JsonPropertyName("publishingUserName")]
    [Required]
    public string PublishingUserName { get; set; }

    [JsonPropertyName("scmUri")]
    public string? ScmUri { get; set; }
}
