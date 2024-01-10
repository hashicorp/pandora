using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseAutomaticTuning;


internal class AutomaticTuningOptionsModel
{
    [JsonPropertyName("actualState")]
    public AutomaticTuningOptionModeActualConstant? ActualState { get; set; }

    [JsonPropertyName("desiredState")]
    public AutomaticTuningOptionModeDesiredConstant? DesiredState { get; set; }

    [JsonPropertyName("reasonCode")]
    public int? ReasonCode { get; set; }

    [JsonPropertyName("reasonDesc")]
    public AutomaticTuningDisabledReasonConstant? ReasonDesc { get; set; }
}
