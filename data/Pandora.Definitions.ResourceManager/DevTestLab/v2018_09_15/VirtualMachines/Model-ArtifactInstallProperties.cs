using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualMachines;


internal class ArtifactInstallPropertiesModel
{
    [JsonPropertyName("artifactId")]
    public string? ArtifactId { get; set; }

    [JsonPropertyName("artifactTitle")]
    public string? ArtifactTitle { get; set; }

    [JsonPropertyName("deploymentStatusMessage")]
    public string? DeploymentStatusMessage { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("installTime")]
    public DateTime? InstallTime { get; set; }

    [JsonPropertyName("parameters")]
    public List<ArtifactParameterPropertiesModel>? Parameters { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("vmExtensionStatusMessage")]
    public string? VMExtensionStatusMessage { get; set; }
}
