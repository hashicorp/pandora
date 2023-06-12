using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_04_03.CommunicationsGateways;


internal class CommunicationsGatewayPropertiesModel
{
    [JsonPropertyName("apiBridge")]
    public object? ApiBridge { get; set; }

    [JsonPropertyName("autoGeneratedDomainNameLabel")]
    public string? AutoGeneratedDomainNameLabel { get; set; }

    [JsonPropertyName("autoGeneratedDomainNameLabelScope")]
    public AutoGeneratedDomainNameLabelScopeConstant? AutoGeneratedDomainNameLabelScope { get; set; }

    [JsonPropertyName("codecs")]
    [Required]
    public List<TeamsCodecsConstant> Codecs { get; set; }

    [JsonPropertyName("connectivity")]
    [Required]
    public ConnectivityConstant Connectivity { get; set; }

    [JsonPropertyName("e911Type")]
    [Required]
    public E911TypeConstant E911Type { get; set; }

    [JsonPropertyName("emergencyDialStrings")]
    public List<string>? EmergencyDialStrings { get; set; }

    [JsonPropertyName("integratedMcpEnabled")]
    public bool? IntegratedMcpEnabled { get; set; }

    [JsonPropertyName("onPremMcpEnabled")]
    public bool? OnPremMcpEnabled { get; set; }

    [MinItems(1)]
    [JsonPropertyName("platforms")]
    [Required]
    public List<CommunicationsPlatformConstant> Platforms { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("serviceLocations")]
    [Required]
    public List<ServiceRegionPropertiesModel> ServiceLocations { get; set; }

    [JsonPropertyName("status")]
    public StatusConstant? Status { get; set; }

    [JsonPropertyName("teamsVoicemailPilotNumber")]
    public string? TeamsVoicemailPilotNumber { get; set; }
}
