using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.UpdateRuns;


internal class UpdateStatusModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("completedTime")]
    public DateTime? CompletedTime { get; set; }

    [JsonPropertyName("error")]
    public ErrorDetailModel? Error { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("startTime")]
    public DateTime? StartTime { get; set; }

    [JsonPropertyName("state")]
    public UpdateStateConstant? State { get; set; }
}
