using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlServersController;


internal class SqlServerV2UpdatePropertiesModel
{
    [JsonPropertyName("createdTimestamp")]
    public string? CreatedTimestamp { get; set; }

    [JsonPropertyName("edition")]
    public string? Edition { get; set; }

    [JsonPropertyName("engineEdition")]
    public string? EngineEdition { get; set; }

    [JsonPropertyName("hostName")]
    public string? HostName { get; set; }

    [JsonPropertyName("hydratedRunAsAccountId")]
    public string? HydratedRunAsAccountId { get; set; }

    [JsonPropertyName("hyperthreadRatio")]
    public int? HyperthreadRatio { get; set; }

    [JsonPropertyName("isClustered")]
    public bool? IsClustered { get; set; }

    [JsonPropertyName("isDeleted")]
    public bool? IsDeleted { get; set; }

    [JsonPropertyName("isHighAvailabilityEnabled")]
    public bool? IsHighAvailabilityEnabled { get; set; }

    [JsonPropertyName("logicalCpuCount")]
    public int? LogicalCPUCount { get; set; }

    [JsonPropertyName("maxServerMemoryInUseInMb")]
    public float? MaxServerMemoryInUseInMb { get; set; }

    [JsonPropertyName("numOfLogins")]
    public int? NumOfLogins { get; set; }

    [JsonPropertyName("numberOfAgDatabases")]
    public int? NumberOfAgDatabases { get; set; }

    [JsonPropertyName("numberOfUserDatabases")]
    public int? NumberOfUserDatabases { get; set; }

    [JsonPropertyName("physicalCpuCount")]
    public float? PhysicalCPUCount { get; set; }

    [JsonPropertyName("portNumber")]
    public int? PortNumber { get; set; }

    [JsonPropertyName("productSupportStatus")]
    public ProductSupportStatusModel? ProductSupportStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("runAsAccountId")]
    public string? RunAsAccountId { get; set; }

    [JsonPropertyName("sqlFciProperties")]
    public SqlFciPropertiesModel? SqlFciProperties { get; set; }

    [JsonPropertyName("sqlServerName")]
    public string? SqlServerName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("sqlStartTime")]
    public DateTime? SqlStartTime { get; set; }

    [JsonPropertyName("status")]
    public SqlServerStatusConstant? Status { get; set; }

    [JsonPropertyName("sumOfUserDatabasesSizeInMb")]
    public float? SumOfUserDatabasesSizeInMb { get; set; }

    [JsonPropertyName("tags")]
    public Dictionary<string, object>? Tags { get; set; }

    [JsonPropertyName("tempDbSizeInMb")]
    public float? TempDbSizeInMb { get; set; }

    [JsonPropertyName("updatedTimestamp")]
    public string? UpdatedTimestamp { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("visibleOnlineCoreCount")]
    public int? VisibleOnlineCoreCount { get; set; }
}
