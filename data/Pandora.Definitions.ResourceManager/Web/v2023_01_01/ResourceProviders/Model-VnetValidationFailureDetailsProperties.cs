using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;


internal class VnetValidationFailureDetailsPropertiesModel
{
    [JsonPropertyName("failed")]
    public bool? Failed { get; set; }

    [JsonPropertyName("failedTests")]
    public List<VnetValidationTestFailureModel>? FailedTests { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("warnings")]
    public List<VnetValidationTestFailureModel>? Warnings { get; set; }
}
