// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class FormsSettingsModel
{
    [JsonPropertyName("isBingImageSearchEnabled")]
    public bool? IsBingImageSearchEnabled { get; set; }

    [JsonPropertyName("isExternalSendFormEnabled")]
    public bool? IsExternalSendFormEnabled { get; set; }

    [JsonPropertyName("isExternalShareCollaborationEnabled")]
    public bool? IsExternalShareCollaborationEnabled { get; set; }

    [JsonPropertyName("isExternalShareResultEnabled")]
    public bool? IsExternalShareResultEnabled { get; set; }

    [JsonPropertyName("isExternalShareTemplateEnabled")]
    public bool? IsExternalShareTemplateEnabled { get; set; }

    [JsonPropertyName("isInOrgFormsPhishingScanEnabled")]
    public bool? IsInOrgFormsPhishingScanEnabled { get; set; }

    [JsonPropertyName("isRecordIdentityByDefaultEnabled")]
    public bool? IsRecordIdentityByDefaultEnabled { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }
}
