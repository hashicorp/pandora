using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiDiagnostic;


internal class DiagnosticContractPropertiesModel
{
    [JsonPropertyName("alwaysLog")]
    public AlwaysLogConstant? AlwaysLog { get; set; }

    [JsonPropertyName("backend")]
    public PipelineDiagnosticSettingsModel? Backend { get; set; }

    [JsonPropertyName("frontend")]
    public PipelineDiagnosticSettingsModel? Frontend { get; set; }

    [JsonPropertyName("httpCorrelationProtocol")]
    public HTTPCorrelationProtocolConstant? HTTPCorrelationProtocol { get; set; }

    [JsonPropertyName("logClientIp")]
    public bool? LogClientIP { get; set; }

    [JsonPropertyName("loggerId")]
    [Required]
    public string LoggerId { get; set; }

    [JsonPropertyName("metrics")]
    public bool? Metrics { get; set; }

    [JsonPropertyName("operationNameFormat")]
    public OperationNameFormatConstant? OperationNameFormat { get; set; }

    [JsonPropertyName("sampling")]
    public SamplingSettingsModel? Sampling { get; set; }

    [JsonPropertyName("verbosity")]
    public VerbosityConstant? Verbosity { get; set; }
}
