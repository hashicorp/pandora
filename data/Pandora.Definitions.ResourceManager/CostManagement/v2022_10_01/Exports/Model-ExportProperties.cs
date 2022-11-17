using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.Exports;


internal class ExportPropertiesModel
{
    [JsonPropertyName("definition")]
    [Required]
    public ExportDefinitionModel Definition { get; set; }

    [JsonPropertyName("deliveryInfo")]
    [Required]
    public ExportDeliveryInfoModel DeliveryInfo { get; set; }

    [JsonPropertyName("format")]
    public FormatTypeConstant? Format { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("nextRunTimeEstimate")]
    public DateTime? NextRunTimeEstimate { get; set; }

    [JsonPropertyName("partitionData")]
    public bool? PartitionData { get; set; }

    [JsonPropertyName("runHistory")]
    public ExportExecutionListResultModel? RunHistory { get; set; }

    [JsonPropertyName("schedule")]
    public ExportScheduleModel? Schedule { get; set; }
}
