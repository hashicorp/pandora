using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.HybridRunbookWorkerGroup;


internal class HybridRunbookWorkerGroupModel
{
    [JsonPropertyName("credential")]
    public RunAsCredentialAssociationPropertyModel? Credential { get; set; }

    [JsonPropertyName("groupType")]
    public GroupTypeEnumConstant? GroupType { get; set; }

    [JsonPropertyName("hybridRunbookWorkers")]
    public List<HybridRunbookWorkerModel>? HybridRunbookWorkers { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
