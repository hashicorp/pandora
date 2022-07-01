using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AAD.v2021_05_01.DomainServices;


internal class DomainSecuritySettingsModel
{
    [JsonPropertyName("kerberosArmoring")]
    public KerberosArmoringConstant? KerberosArmoring { get; set; }

    [JsonPropertyName("kerberosRc4Encryption")]
    public KerberosRc4EncryptionConstant? KerberosRc4Encryption { get; set; }

    [JsonPropertyName("ntlmV1")]
    public NtlmV1Constant? NtlmV1 { get; set; }

    [JsonPropertyName("syncKerberosPasswords")]
    public SyncKerberosPasswordsConstant? SyncKerberosPasswords { get; set; }

    [JsonPropertyName("syncNtlmPasswords")]
    public SyncNtlmPasswordsConstant? SyncNtlmPasswords { get; set; }

    [JsonPropertyName("syncOnPremPasswords")]
    public SyncOnPremPasswordsConstant? SyncOnPremPasswords { get; set; }

    [JsonPropertyName("tlsV1")]
    public TlsV1Constant? TlsV1 { get; set; }
}
