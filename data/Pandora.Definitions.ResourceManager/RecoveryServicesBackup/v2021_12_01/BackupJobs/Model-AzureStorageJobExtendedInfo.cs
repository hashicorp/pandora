using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.BackupJobs;


internal class AzureStorageJobExtendedInfoModel
{
    [JsonPropertyName("dynamicErrorMessage")]
    public string? DynamicErrorMessage { get; set; }

    [JsonPropertyName("propertyBag")]
    public Dictionary<string, string>? PropertyBag { get; set; }

    [JsonPropertyName("tasksList")]
    public List<AzureStorageJobTaskDetailsModel>? TasksList { get; set; }
}
