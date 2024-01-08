using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.RecoveryPoints;


internal class AzureWorkloadSQLRecoveryPointExtendedInfoModel
{
    [JsonPropertyName("dataDirectoryPaths")]
    public List<SQLDataDirectoryModel>? DataDirectoryPaths { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("dataDirectoryTimeInUTC")]
    public DateTime? DataDirectoryTimeInUTC { get; set; }
}
