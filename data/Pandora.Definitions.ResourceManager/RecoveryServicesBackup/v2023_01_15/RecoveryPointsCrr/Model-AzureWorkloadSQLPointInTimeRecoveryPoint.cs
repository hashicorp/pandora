using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.RecoveryPointsCrr;

[ValueForType("AzureWorkloadSQLPointInTimeRecoveryPoint")]
internal class AzureWorkloadSQLPointInTimeRecoveryPointModel : RecoveryPointModel
{
    [JsonPropertyName("extendedInfo")]
    public AzureWorkloadSQLRecoveryPointExtendedInfoModel? ExtendedInfo { get; set; }

    [JsonPropertyName("recoveryPointMoveReadinessInfo")]
    public Dictionary<string, RecoveryPointMoveReadinessInfoModel>? RecoveryPointMoveReadinessInfo { get; set; }

    [JsonPropertyName("recoveryPointProperties")]
    public RecoveryPointPropertiesModel? RecoveryPointProperties { get; set; }

    [JsonPropertyName("recoveryPointTierDetails")]
    public List<RecoveryPointTierInformationModel>? RecoveryPointTierDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("recoveryPointTimeInUTC")]
    public DateTime? RecoveryPointTimeInUTC { get; set; }

    [JsonPropertyName("timeRanges")]
    public List<PointInTimeRangeModel>? TimeRanges { get; set; }

    [JsonPropertyName("type")]
    public RestorePointTypeConstant? Type { get; set; }
}
