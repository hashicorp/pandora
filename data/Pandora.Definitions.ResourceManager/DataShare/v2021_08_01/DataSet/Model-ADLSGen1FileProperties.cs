using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.DataSet;


internal class ADLSGen1FilePropertiesModel
{
    [JsonPropertyName("accountName")]
    [Required]
    public string AccountName { get; set; }

    [JsonPropertyName("dataSetId")]
    public string? DataSetId { get; set; }

    [JsonPropertyName("fileName")]
    [Required]
    public string FileName { get; set; }

    [JsonPropertyName("folderPath")]
    [Required]
    public string FolderPath { get; set; }

    [JsonPropertyName("resourceGroup")]
    [Required]
    public string ResourceGroup { get; set; }

    [JsonPropertyName("subscriptionId")]
    [Required]
    public string SubscriptionId { get; set; }
}
