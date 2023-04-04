using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2022_01_10_preview.VirtualMachines;


internal class VirtualMachineInstallPatchesResultModel
{
    [JsonPropertyName("errorDetails")]
    public ErrorDetailModel? ErrorDetails { get; set; }

    [JsonPropertyName("excludedPatchCount")]
    public int? ExcludedPatchCount { get; set; }

    [JsonPropertyName("failedPatchCount")]
    public int? FailedPatchCount { get; set; }

    [JsonPropertyName("installationActivityId")]
    public string? InstallationActivityId { get; set; }

    [JsonPropertyName("installedPatchCount")]
    public int? InstalledPatchCount { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonPropertyName("maintenanceWindowExceeded")]
    public bool? MaintenanceWindowExceeded { get; set; }

    [JsonPropertyName("notSelectedPatchCount")]
    public int? NotSelectedPatchCount { get; set; }

    [JsonPropertyName("osType")]
    public OsTypeUMConstant? OsType { get; set; }

    [JsonPropertyName("patchServiceUsed")]
    public PatchServiceUsedConstant? PatchServiceUsed { get; set; }

    [JsonPropertyName("pendingPatchCount")]
    public int? PendingPatchCount { get; set; }

    [JsonPropertyName("rebootStatus")]
    public VMGuestPatchRebootStatusConstant? RebootStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startDateTime")]
    public DateTime? StartDateTime { get; set; }

    [JsonPropertyName("startedBy")]
    public PatchOperationStartedByConstant? StartedBy { get; set; }

    [JsonPropertyName("status")]
    public PatchOperationStatusConstant? Status { get; set; }
}
