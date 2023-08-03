// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationRootModel
{
    [JsonPropertyName("classes")]
    public List<EducationClassModel>? Classes { get; set; }

    [JsonPropertyName("me")]
    public EducationUserModel? Me { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("schools")]
    public List<EducationSchoolModel>? Schools { get; set; }

    [JsonPropertyName("synchronizationProfiles")]
    public List<EducationSynchronizationProfileModel>? SynchronizationProfiles { get; set; }

    [JsonPropertyName("users")]
    public List<EducationUserModel>? Users { get; set; }
}
