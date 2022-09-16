using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsBackup;


internal class RestorePointPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("earliestRestoreDate")]
    public DateTime? EarliestRestoreDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("restorePointCreationDate")]
    public DateTime? RestorePointCreationDate { get; set; }

    [JsonPropertyName("restorePointLabel")]
    public string? RestorePointLabel { get; set; }

    [JsonPropertyName("restorePointType")]
    public RestorePointTypeConstant? RestorePointType { get; set; }
}
