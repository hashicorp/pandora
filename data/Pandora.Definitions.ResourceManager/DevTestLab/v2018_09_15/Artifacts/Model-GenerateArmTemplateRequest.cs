using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.Artifacts;


internal class GenerateArmTemplateRequestModel
{
    [JsonPropertyName("fileUploadOptions")]
    public FileUploadOptionsConstant? FileUploadOptions { get; set; }

    [JsonPropertyName("location")]
    public CustomTypes.Location? Location { get; set; }

    [JsonPropertyName("parameters")]
    public List<ParameterInfoModel>? Parameters { get; set; }

    [JsonPropertyName("virtualMachineName")]
    public string? VirtualMachineName { get; set; }
}
