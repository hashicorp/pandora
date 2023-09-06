using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetworkCloud.v2023_07_01.Networkclouds;


internal class BareMetalMachineKeySetPropertiesModel
{
    [JsonPropertyName("azureGroupId")]
    [Required]
    public string AzureGroupId { get; set; }

    [JsonPropertyName("detailedStatus")]
    public BareMetalMachineKeySetDetailedStatusConstant? DetailedStatus { get; set; }

    [JsonPropertyName("detailedStatusMessage")]
    public string? DetailedStatusMessage { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expiration")]
    [Required]
    public DateTime Expiration { get; set; }

    [JsonPropertyName("jumpHostsAllowed")]
    [Required]
    public List<string> JumpHostsAllowed { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastValidation")]
    public DateTime? LastValidation { get; set; }

    [JsonPropertyName("osGroupName")]
    public string? OsGroupName { get; set; }

    [JsonPropertyName("privilegeLevel")]
    [Required]
    public BareMetalMachineKeySetPrivilegeLevelConstant PrivilegeLevel { get; set; }

    [JsonPropertyName("provisioningState")]
    public BareMetalMachineKeySetProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("userList")]
    [Required]
    public List<KeySetUserModel> UserList { get; set; }

    [JsonPropertyName("userListStatus")]
    public List<KeySetUserStatusModel>? UserListStatus { get; set; }
}
