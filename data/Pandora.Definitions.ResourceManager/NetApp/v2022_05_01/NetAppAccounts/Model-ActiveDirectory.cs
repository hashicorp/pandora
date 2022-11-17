using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.NetAppAccounts;


internal class ActiveDirectoryModel
{
    [JsonPropertyName("activeDirectoryId")]
    public string? ActiveDirectoryId { get; set; }

    [JsonPropertyName("adName")]
    public string? AdName { get; set; }

    [JsonPropertyName("administrators")]
    public List<string>? Administrators { get; set; }

    [JsonPropertyName("aesEncryption")]
    public bool? AesEncryption { get; set; }

    [JsonPropertyName("allowLocalNfsUsersWithLdap")]
    public bool? AllowLocalNfsUsersWithLdap { get; set; }

    [JsonPropertyName("backupOperators")]
    public List<string>? BackupOperators { get; set; }

    [JsonPropertyName("dns")]
    public string? Dns { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("encryptDCConnections")]
    public bool? EncryptDCConnections { get; set; }

    [JsonPropertyName("kdcIP")]
    public string? KdcIP { get; set; }

    [JsonPropertyName("ldapOverTLS")]
    public bool? LdapOverTLS { get; set; }

    [JsonPropertyName("ldapSearchScope")]
    public LdapSearchScopeOptModel? LdapSearchScope { get; set; }

    [JsonPropertyName("ldapSigning")]
    public bool? LdapSigning { get; set; }

    [JsonPropertyName("organizationalUnit")]
    public string? OrganizationalUnit { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("securityOperators")]
    public List<string>? SecurityOperators { get; set; }

    [JsonPropertyName("serverRootCACertificate")]
    public string? ServerRootCACertificate { get; set; }

    [JsonPropertyName("site")]
    public string? Site { get; set; }

    [JsonPropertyName("smbServerName")]
    public string? SmbServerName { get; set; }

    [JsonPropertyName("status")]
    public ActiveDirectoryStatusConstant? Status { get; set; }

    [JsonPropertyName("statusDetails")]
    public string? StatusDetails { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }
}
