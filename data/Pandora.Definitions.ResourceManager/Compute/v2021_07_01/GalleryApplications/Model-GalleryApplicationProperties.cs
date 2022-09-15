using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.GalleryApplications;


internal class GalleryApplicationPropertiesModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("endOfLifeDate")]
    public DateTime? EndOfLifeDate { get; set; }

    [JsonPropertyName("eula")]
    public string? Eula { get; set; }

    [JsonPropertyName("privacyStatementUri")]
    public string? PrivacyStatementUri { get; set; }

    [JsonPropertyName("releaseNoteUri")]
    public string? ReleaseNoteUri { get; set; }

    [JsonPropertyName("supportedOSType")]
    [Required]
    public OperatingSystemTypesConstant SupportedOSType { get; set; }
}
