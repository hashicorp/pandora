// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageAssignmentRequestorSettingsModel
{
    [JsonPropertyName("allowCustomAssignmentSchedule")]
    public bool? AllowCustomAssignmentSchedule { get; set; }

    [JsonPropertyName("enableOnBehalfRequestorsToAddAccess")]
    public bool? EnableOnBehalfRequestorsToAddAccess { get; set; }

    [JsonPropertyName("enableOnBehalfRequestorsToRemoveAccess")]
    public bool? EnableOnBehalfRequestorsToRemoveAccess { get; set; }

    [JsonPropertyName("enableOnBehalfRequestorsToUpdateAccess")]
    public bool? EnableOnBehalfRequestorsToUpdateAccess { get; set; }

    [JsonPropertyName("enableTargetsToSelfAddAccess")]
    public bool? EnableTargetsToSelfAddAccess { get; set; }

    [JsonPropertyName("enableTargetsToSelfRemoveAccess")]
    public bool? EnableTargetsToSelfRemoveAccess { get; set; }

    [JsonPropertyName("enableTargetsToSelfUpdateAccess")]
    public bool? EnableTargetsToSelfUpdateAccess { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onBehalfRequestors")]
    public List<SubjectSetModel>? OnBehalfRequestors { get; set; }
}
