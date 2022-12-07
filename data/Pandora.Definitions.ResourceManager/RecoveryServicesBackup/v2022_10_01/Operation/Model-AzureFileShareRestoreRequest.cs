using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.Operation;

[ValueForType("AzureFileShareRestoreRequest")]
internal class AzureFileShareRestoreRequestModel : RestoreRequestModel
{
    [JsonPropertyName("copyOptions")]
    public CopyOptionsConstant? CopyOptions { get; set; }

    [JsonPropertyName("recoveryType")]
    public RecoveryTypeConstant? RecoveryType { get; set; }

    [JsonPropertyName("restoreFileSpecs")]
    public List<RestoreFileSpecsModel>? RestoreFileSpecs { get; set; }

    [JsonPropertyName("restoreRequestType")]
    public RestoreRequestTypeConstant? RestoreRequestType { get; set; }

    [JsonPropertyName("sourceResourceId")]
    public string? SourceResourceId { get; set; }

    [JsonPropertyName("targetDetails")]
    public TargetAFSRestoreInfoModel? TargetDetails { get; set; }
}
