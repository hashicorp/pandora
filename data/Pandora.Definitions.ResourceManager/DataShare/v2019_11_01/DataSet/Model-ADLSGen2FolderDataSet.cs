using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.DataSet;

[ValueForType("AdlsGen2Folder")]
internal class ADLSGen2FolderDataSetModel : DataSetModel
{
    [JsonPropertyName("properties")]
    [Required]
    public ADLSGen2FolderPropertiesModel Properties { get; set; }
}
