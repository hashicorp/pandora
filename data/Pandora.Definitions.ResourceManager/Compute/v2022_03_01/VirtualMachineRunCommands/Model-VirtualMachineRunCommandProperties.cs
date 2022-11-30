using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.VirtualMachineRunCommands;


internal class VirtualMachineRunCommandPropertiesModel
{
    [JsonPropertyName("asyncExecution")]
    public bool? AsyncExecution { get; set; }

    [JsonPropertyName("errorBlobUri")]
    public string? ErrorBlobUri { get; set; }

    [JsonPropertyName("instanceView")]
    public VirtualMachineRunCommandInstanceViewModel? InstanceView { get; set; }

    [JsonPropertyName("outputBlobUri")]
    public string? OutputBlobUri { get; set; }

    [JsonPropertyName("parameters")]
    public List<RunCommandInputParameterModel>? Parameters { get; set; }

    [JsonPropertyName("protectedParameters")]
    public List<RunCommandInputParameterModel>? ProtectedParameters { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("runAsPassword")]
    public string? RunAsPassword { get; set; }

    [JsonPropertyName("runAsUser")]
    public string? RunAsUser { get; set; }

    [JsonPropertyName("source")]
    public VirtualMachineRunCommandScriptSourceModel? Source { get; set; }

    [JsonPropertyName("timeoutInSeconds")]
    public int? TimeoutInSeconds { get; set; }
}
