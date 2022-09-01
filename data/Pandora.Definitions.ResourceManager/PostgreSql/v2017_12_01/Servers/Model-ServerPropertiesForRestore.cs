using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2017_12_01.Servers;

[ValueForType("PointInTimeRestore")]
internal class ServerPropertiesForRestoreModel : ServerPropertiesForCreateModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restorePointInTime")]
    [Required]
    public DateTime RestorePointInTime { get; set; }

    [JsonPropertyName("sourceServerId")]
    [Required]
    public string SourceServerId { get; set; }
}
