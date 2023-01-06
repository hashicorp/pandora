using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.DataMove;


internal class TriggerDataMoveRequestModel
{
    [JsonPropertyName("correlationId")]
    [Required]
    public string CorrelationId { get; set; }

    [JsonPropertyName("dataMoveLevel")]
    [Required]
    public DataMoveLevelConstant DataMoveLevel { get; set; }

    [JsonPropertyName("pauseGC")]
    public bool? PauseGC { get; set; }

    [JsonPropertyName("sourceContainerArmIds")]
    public List<string>? SourceContainerArmIds { get; set; }

    [JsonPropertyName("sourceRegion")]
    [Required]
    public string SourceRegion { get; set; }

    [JsonPropertyName("sourceResourceId")]
    [Required]
    public string SourceResourceId { get; set; }
}
