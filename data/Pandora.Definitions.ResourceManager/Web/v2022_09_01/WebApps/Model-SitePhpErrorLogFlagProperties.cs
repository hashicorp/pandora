using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class SitePhpErrorLogFlagPropertiesModel
{
    [JsonPropertyName("localLogErrors")]
    public string? LocalLogErrors { get; set; }

    [JsonPropertyName("localLogErrorsMaxLength")]
    public string? LocalLogErrorsMaxLength { get; set; }

    [JsonPropertyName("masterLogErrors")]
    public string? MasterLogErrors { get; set; }

    [JsonPropertyName("masterLogErrorsMaxLength")]
    public string? MasterLogErrorsMaxLength { get; set; }
}
