using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.ServiceTaskResource;


internal class ProjectTaskPropertiesModel
{
    [JsonPropertyName("clientData")]
    public Dictionary<string, string>? ClientData { get; set; }

    [JsonPropertyName("commands")]
    public List<CommandPropertiesModel>? Commands { get; set; }

    [JsonPropertyName("errors")]
    public List<ODataErrorModel>? Errors { get; set; }

    [JsonPropertyName("state")]
    public TaskStateConstant? State { get; set; }

    [JsonPropertyName("taskType")]
    [Required]
    public string TaskType { get; set; }
}
