using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.OperationalizationClusters;


internal class VirtualMachineSchemaPropertiesModel
{
    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("administratorAccount")]
    public VirtualMachineSshCredentialsModel? AdministratorAccount { get; set; }

    [JsonPropertyName("isNotebookInstanceCompute")]
    public bool? IsNotebookInstanceCompute { get; set; }

    [JsonPropertyName("notebookServerPort")]
    public int? NotebookServerPort { get; set; }

    [JsonPropertyName("sshPort")]
    public int? SshPort { get; set; }

    [JsonPropertyName("virtualMachineSize")]
    public string? VirtualMachineSize { get; set; }
}
