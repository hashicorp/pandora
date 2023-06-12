using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ChangeDataCapture;


internal class MapperSourceConnectionsInfoModel
{
    [JsonPropertyName("Connection")]
    public MapperConnectionModel? Connection { get; set; }

    [JsonPropertyName("SourceEntities")]
    public List<MapperTableModel>? SourceEntities { get; set; }
}
