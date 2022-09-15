using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetVMs;


internal class MaintenanceRedeployStatusModel
{
    [JsonPropertyName("isCustomerInitiatedMaintenanceAllowed")]
    public bool? IsCustomerInitiatedMaintenanceAllowed { get; set; }

    [JsonPropertyName("lastOperationMessage")]
    public string? LastOperationMessage { get; set; }

    [JsonPropertyName("lastOperationResultCode")]
    public MaintenanceOperationResultCodeTypesConstant? LastOperationResultCode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("maintenanceWindowEndTime")]
    public DateTime? MaintenanceWindowEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("maintenanceWindowStartTime")]
    public DateTime? MaintenanceWindowStartTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("preMaintenanceWindowEndTime")]
    public DateTime? PreMaintenanceWindowEndTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("preMaintenanceWindowStartTime")]
    public DateTime? PreMaintenanceWindowStartTime { get; set; }
}
