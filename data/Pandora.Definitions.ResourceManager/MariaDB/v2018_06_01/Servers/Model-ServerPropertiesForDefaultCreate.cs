using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.Servers;

[ValueForType("Default")]
internal class ServerPropertiesForDefaultCreateModel : ServerPropertiesForCreateModel
{
    [JsonPropertyName("administratorLogin")]
    [Required]
    public string AdministratorLogin { get; set; }

    [JsonPropertyName("administratorLoginPassword")]
    [Required]
    public string AdministratorLoginPassword { get; set; }
}
