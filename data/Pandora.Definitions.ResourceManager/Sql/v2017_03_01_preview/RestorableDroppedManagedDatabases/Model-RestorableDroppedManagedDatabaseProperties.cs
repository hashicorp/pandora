using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.RestorableDroppedManagedDatabases;


internal class RestorableDroppedManagedDatabasePropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("creationDate")]
    public DateTime? CreationDate { get; set; }

    [JsonPropertyName("databaseName")]
    public string? DatabaseName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deletionDate")]
    public DateTime? DeletionDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("earliestRestoreDate")]
    public DateTime? EarliestRestoreDate { get; set; }
}
