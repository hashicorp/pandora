using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.NetAppAccounts;


internal class AccountPropertiesModel
{
    [JsonPropertyName("activeDirectories")]
    public List<ActiveDirectoryModel>? ActiveDirectories { get; set; }

    [JsonPropertyName("disableShowmount")]
    public bool? DisableShowmount { get; set; }

    [JsonPropertyName("encryption")]
    public AccountEncryptionModel? Encryption { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }
}
