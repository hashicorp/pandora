using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Devices;


internal class UpdateSummaryPropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("deviceLastScannedDateTime")]
    public DateTime? DeviceLastScannedDateTime { get; set; }

    [JsonPropertyName("deviceVersionNumber")]
    public string? DeviceVersionNumber { get; set; }

    [JsonPropertyName("friendlyDeviceVersionName")]
    public string? FriendlyDeviceVersionName { get; set; }

    [JsonPropertyName("inProgressDownloadJobId")]
    public string? InProgressDownloadJobId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("inProgressDownloadJobStartedDateTime")]
    public DateTime? InProgressDownloadJobStartedDateTime { get; set; }

    [JsonPropertyName("inProgressInstallJobId")]
    public string? InProgressInstallJobId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("inProgressInstallJobStartedDateTime")]
    public DateTime? InProgressInstallJobStartedDateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCompletedDownloadJobDateTime")]
    public DateTime? LastCompletedDownloadJobDateTime { get; set; }

    [JsonPropertyName("lastCompletedDownloadJobId")]
    public string? LastCompletedDownloadJobId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCompletedInstallJobDateTime")]
    public DateTime? LastCompletedInstallJobDateTime { get; set; }

    [JsonPropertyName("lastCompletedInstallJobId")]
    public string? LastCompletedInstallJobId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCompletedScanJobDateTime")]
    public DateTime? LastCompletedScanJobDateTime { get; set; }

    [JsonPropertyName("lastDownloadJobStatus")]
    public JobStatusConstant? LastDownloadJobStatus { get; set; }

    [JsonPropertyName("lastInstallJobStatus")]
    public JobStatusConstant? LastInstallJobStatus { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSuccessfulInstallJobDateTime")]
    public DateTime? LastSuccessfulInstallJobDateTime { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastSuccessfulScanJobTime")]
    public DateTime? LastSuccessfulScanJobTime { get; set; }

    [JsonPropertyName("ongoingUpdateOperation")]
    public UpdateOperationConstant? OngoingUpdateOperation { get; set; }

    [JsonPropertyName("rebootBehavior")]
    public InstallRebootBehaviorConstant? RebootBehavior { get; set; }

    [JsonPropertyName("totalNumberOfUpdatesAvailable")]
    public int? TotalNumberOfUpdatesAvailable { get; set; }

    [JsonPropertyName("totalNumberOfUpdatesPendingDownload")]
    public int? TotalNumberOfUpdatesPendingDownload { get; set; }

    [JsonPropertyName("totalNumberOfUpdatesPendingInstall")]
    public int? TotalNumberOfUpdatesPendingInstall { get; set; }

    [JsonPropertyName("totalTimeInMinutes")]
    public int? TotalTimeInMinutes { get; set; }

    [JsonPropertyName("totalUpdateSizeInBytes")]
    public float? TotalUpdateSizeInBytes { get; set; }

    [JsonPropertyName("updateTitles")]
    public List<string>? UpdateTitles { get; set; }

    [JsonPropertyName("updates")]
    public List<UpdateDetailsModel>? Updates { get; set; }
}
