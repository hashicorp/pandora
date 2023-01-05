using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.BackupInstances;

[ValueForType("ItemLevelRestoreTargetInfo")]
internal class ItemLevelRestoreTargetInfoModel : RestoreTargetInfoBaseModel
{
    [JsonPropertyName("datasourceAuthCredentials")]
    public AuthCredentialsModel? DatasourceAuthCredentials { get; set; }

    [JsonPropertyName("datasourceInfo")]
    [Required]
    public DatasourceModel DatasourceInfo { get; set; }

    [JsonPropertyName("datasourceSetInfo")]
    public DatasourceSetModel? DatasourceSetInfo { get; set; }

    [JsonPropertyName("restoreCriteria")]
    [Required]
    public List<ItemLevelRestoreCriteriaModel> RestoreCriteria { get; set; }
}
