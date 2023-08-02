using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.TenantConfigurationSyncState;


internal class TenantConfigurationSyncStateContractPropertiesModel
{
    [JsonPropertyName("branch")]
    public string? Branch { get; set; }

    [JsonPropertyName("commitId")]
    public string? CommitId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("configurationChangeDate")]
    public DateTime? ConfigurationChangeDate { get; set; }

    [JsonPropertyName("isExport")]
    public bool? IsExport { get; set; }

    [JsonPropertyName("isGitEnabled")]
    public bool? IsGitEnabled { get; set; }

    [JsonPropertyName("isSynced")]
    public bool? IsSynced { get; set; }

    [JsonPropertyName("lastOperationId")]
    public string? LastOperationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("syncDate")]
    public DateTime? SyncDate { get; set; }
}
