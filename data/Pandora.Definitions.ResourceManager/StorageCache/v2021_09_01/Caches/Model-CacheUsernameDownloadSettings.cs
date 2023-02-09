using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageCache.v2021_09_01.Caches;


internal class CacheUsernameDownloadSettingsModel
{
    [JsonPropertyName("autoDownloadCertificate")]
    public bool? AutoDownloadCertificate { get; set; }

    [JsonPropertyName("caCertificateURI")]
    public string? CaCertificateURI { get; set; }

    [JsonPropertyName("credentials")]
    public CacheUsernameDownloadSettingsCredentialsModel? Credentials { get; set; }

    [JsonPropertyName("encryptLdapConnection")]
    public bool? EncryptLdapConnection { get; set; }

    [JsonPropertyName("extendedGroups")]
    public bool? ExtendedGroups { get; set; }

    [JsonPropertyName("groupFileURI")]
    public string? GroupFileURI { get; set; }

    [JsonPropertyName("ldapBaseDN")]
    public string? LdapBaseDN { get; set; }

    [JsonPropertyName("ldapServer")]
    public string? LdapServer { get; set; }

    [JsonPropertyName("requireValidCertificate")]
    public bool? RequireValidCertificate { get; set; }

    [JsonPropertyName("userFileURI")]
    public string? UserFileURI { get; set; }

    [JsonPropertyName("usernameDownloaded")]
    public UsernameDownloadedTypeConstant? UsernameDownloaded { get; set; }

    [JsonPropertyName("usernameSource")]
    public UsernameSourceConstant? UsernameSource { get; set; }
}
