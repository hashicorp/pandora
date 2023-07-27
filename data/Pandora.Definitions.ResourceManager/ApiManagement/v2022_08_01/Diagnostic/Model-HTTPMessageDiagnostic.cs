using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.Diagnostic;


internal class HTTPMessageDiagnosticModel
{
    [JsonPropertyName("body")]
    public BodyDiagnosticSettingsModel? Body { get; set; }

    [JsonPropertyName("dataMasking")]
    public DataMaskingModel? DataMasking { get; set; }

    [JsonPropertyName("headers")]
    public List<string>? Headers { get; set; }
}
