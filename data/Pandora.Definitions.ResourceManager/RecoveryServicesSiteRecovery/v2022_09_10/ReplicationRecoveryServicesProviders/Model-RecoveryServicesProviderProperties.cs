using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_09_10.ReplicationRecoveryServicesProviders;


internal class RecoveryServicesProviderPropertiesModel
{
    [JsonPropertyName("allowedScenarios")]
    public List<string>? AllowedScenarios { get; set; }

    [JsonPropertyName("authenticationIdentityDetails")]
    public IdentityProviderDetailsModel? AuthenticationIdentityDetails { get; set; }

    [JsonPropertyName("biosId")]
    public string? BiosId { get; set; }

    [JsonPropertyName("connectionStatus")]
    public string? ConnectionStatus { get; set; }

    [JsonPropertyName("dataPlaneAuthenticationIdentityDetails")]
    public IdentityProviderDetailsModel? DataPlaneAuthenticationIdentityDetails { get; set; }

    [JsonPropertyName("draIdentifier")]
    public string? DraIdentifier { get; set; }

    [JsonPropertyName("fabricFriendlyName")]
    public string? FabricFriendlyName { get; set; }

    [JsonPropertyName("fabricType")]
    public string? FabricType { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("healthErrorDetails")]
    public List<HealthErrorModel>? HealthErrorDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastHeartBeat")]
    public DateTime? LastHeartBeat { get; set; }

    [JsonPropertyName("machineId")]
    public string? MachineId { get; set; }

    [JsonPropertyName("machineName")]
    public string? MachineName { get; set; }

    [JsonPropertyName("protectedItemCount")]
    public int? ProtectedItemCount { get; set; }

    [JsonPropertyName("providerVersion")]
    public string? ProviderVersion { get; set; }

    [JsonPropertyName("providerVersionDetails")]
    public VersionDetailsModel? ProviderVersionDetails { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("providerVersionExpiryDate")]
    public DateTime? ProviderVersionExpiryDate { get; set; }

    [JsonPropertyName("providerVersionState")]
    public string? ProviderVersionState { get; set; }

    [JsonPropertyName("resourceAccessIdentityDetails")]
    public IdentityProviderDetailsModel? ResourceAccessIdentityDetails { get; set; }

    [JsonPropertyName("serverVersion")]
    public string? ServerVersion { get; set; }
}
