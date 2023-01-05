using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupInstances;


internal class BackupInstanceModel
{
    [JsonPropertyName("currentProtectionState")]
    public CurrentProtectionStateConstant? CurrentProtectionState { get; set; }

    [JsonPropertyName("dataSourceInfo")]
    [Required]
    public DatasourceModel DataSourceInfo { get; set; }

    [JsonPropertyName("dataSourceSetInfo")]
    public DatasourceSetModel? DataSourceSetInfo { get; set; }

    [JsonPropertyName("datasourceAuthCredentials")]
    public AuthCredentialsModel? DatasourceAuthCredentials { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("objectType")]
    [Required]
    public string ObjectType { get; set; }

    [JsonPropertyName("policyInfo")]
    [Required]
    public PolicyInfoModel PolicyInfo { get; set; }

    [JsonPropertyName("protectionErrorDetails")]
    public UserFacingErrorModel? ProtectionErrorDetails { get; set; }

    [JsonPropertyName("protectionStatus")]
    public ProtectionStatusDetailsModel? ProtectionStatus { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("validationType")]
    public ValidationTypeConstant? ValidationType { get; set; }
}
