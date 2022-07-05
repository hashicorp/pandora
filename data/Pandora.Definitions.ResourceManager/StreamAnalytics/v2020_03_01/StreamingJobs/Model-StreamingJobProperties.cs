using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;


internal class StreamingJobPropertiesModel
{
    [JsonPropertyName("cluster")]
    public ClusterInfoModel? Cluster { get; set; }

    [JsonPropertyName("compatibilityLevel")]
    public CompatibilityLevelConstant? CompatibilityLevel { get; set; }

    [JsonPropertyName("contentStoragePolicy")]
    public ContentStoragePolicyConstant? ContentStoragePolicy { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("dataLocale")]
    public string? DataLocale { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("eventsLateArrivalMaxDelayInSeconds")]
    public int? EventsLateArrivalMaxDelayInSeconds { get; set; }

    [JsonPropertyName("eventsOutOfOrderMaxDelayInSeconds")]
    public int? EventsOutOfOrderMaxDelayInSeconds { get; set; }

    [JsonPropertyName("eventsOutOfOrderPolicy")]
    public EventsOutOfOrderPolicyConstant? EventsOutOfOrderPolicy { get; set; }

    [JsonPropertyName("functions")]
    public List<FunctionModel>? Functions { get; set; }

    [JsonPropertyName("inputs")]
    public List<InputModel>? Inputs { get; set; }

    [JsonPropertyName("jobId")]
    public string? JobId { get; set; }

    [JsonPropertyName("jobState")]
    public string? JobState { get; set; }

    [JsonPropertyName("jobStorageAccount")]
    public JobStorageAccountModel? JobStorageAccount { get; set; }

    [JsonPropertyName("jobType")]
    public JobTypeConstant? JobType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastOutputEventTime")]
    public DateTime? LastOutputEventTime { get; set; }

    [JsonPropertyName("outputErrorPolicy")]
    public OutputErrorPolicyConstant? OutputErrorPolicy { get; set; }

    [JsonPropertyName("outputStartMode")]
    public OutputStartModeConstant? OutputStartMode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("outputStartTime")]
    public DateTime? OutputStartTime { get; set; }

    [JsonPropertyName("outputs")]
    public List<OutputModel>? Outputs { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }

    [JsonPropertyName("transformation")]
    public TransformationModel? Transformation { get; set; }
}
