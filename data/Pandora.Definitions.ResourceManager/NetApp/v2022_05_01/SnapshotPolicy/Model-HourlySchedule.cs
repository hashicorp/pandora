using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.SnapshotPolicy;


internal class HourlyScheduleModel
{
    [JsonPropertyName("minute")]
    public int? Minute { get; set; }

    [JsonPropertyName("snapshotsToKeep")]
    public int? SnapshotsToKeep { get; set; }

    [JsonPropertyName("usedBytes")]
    public int? UsedBytes { get; set; }
}
