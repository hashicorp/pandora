using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.SourceControlConfiguration;


internal class SourceControlConfigurationPropertiesModel
{
    [JsonPropertyName("complianceStatus")]
    public ComplianceStatusModel? ComplianceStatus { get; set; }

    [JsonPropertyName("configurationProtectedSettings")]
    public Dictionary<string, string>? ConfigurationProtectedSettings { get; set; }

    [JsonPropertyName("enableHelmOperator")]
    public bool? EnableHelmOperator { get; set; }

    [JsonPropertyName("helmOperatorProperties")]
    public HelmOperatorPropertiesModel? HelmOperatorProperties { get; set; }

    [JsonPropertyName("operatorInstanceName")]
    public string? OperatorInstanceName { get; set; }

    [JsonPropertyName("operatorNamespace")]
    public string? OperatorNamespace { get; set; }

    [JsonPropertyName("operatorParams")]
    public string? OperatorParams { get; set; }

    [JsonPropertyName("operatorScope")]
    public OperatorScopeTypeConstant? OperatorScope { get; set; }

    [JsonPropertyName("operatorType")]
    public OperatorTypeConstant? OperatorType { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateTypeConstant? ProvisioningState { get; set; }

    [JsonPropertyName("repositoryPublicKey")]
    public string? RepositoryPublicKey { get; set; }

    [JsonPropertyName("repositoryUrl")]
    public string? RepositoryUrl { get; set; }

    [JsonPropertyName("sshKnownHostsContents")]
    public string? SshKnownHostsContents { get; set; }
}
