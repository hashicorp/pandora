using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDB;


internal class RestoreParametersModel
{
    [JsonPropertyName("databasesToRestore")]
    public List<DatabaseRestoreResourceModel>? DatabasesToRestore { get; set; }

    [JsonPropertyName("restoreMode")]
    public RestoreModeConstant? RestoreMode { get; set; }

    [JsonPropertyName("restoreSource")]
    public string? RestoreSource { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restoreTimestampInUtc")]
    public DateTime? RestoreTimestampInUtc { get; set; }
}
