using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;

[ValueForType("Microsoft.DataLake/Accounts")]
internal class AzureDataLakeStoreOutputDataSourceModel : OutputDataSourceModel
{
    [JsonPropertyName("properties")]
    public AzureDataLakeStoreOutputDataSourcePropertiesModel? Properties { get; set; }
}
