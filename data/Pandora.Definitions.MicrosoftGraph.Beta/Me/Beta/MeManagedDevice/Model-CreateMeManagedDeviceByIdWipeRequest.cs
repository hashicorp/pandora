// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

internal class CreateMeManagedDeviceByIdWipeRequestModel
{
    [JsonPropertyName("keepEnrollmentData")]
    public bool? KeepEnrollmentData { get; set; }

    [JsonPropertyName("keepUserData")]
    public bool? KeepUserData { get; set; }

    [JsonPropertyName("macOsUnlockCode")]
    public string? MacOsUnlockCode { get; set; }

    [JsonPropertyName("obliterationBehavior")]
    public CreateMeManagedDeviceByIdWipeRequestObliterationBehaviorConstant? ObliterationBehavior { get; set; }

    [JsonPropertyName("persistEsimDataPlan")]
    public bool? PersistEsimDataPlan { get; set; }

    [JsonPropertyName("useProtectedWipe")]
    public bool? UseProtectedWipe { get; set; }
}
