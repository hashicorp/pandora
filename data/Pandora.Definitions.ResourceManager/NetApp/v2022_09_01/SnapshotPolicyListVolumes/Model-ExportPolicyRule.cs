using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.SnapshotPolicyListVolumes;


internal class ExportPolicyRuleModel
{
    [JsonPropertyName("allowedClients")]
    public string? AllowedClients { get; set; }

    [JsonPropertyName("chownMode")]
    public ChownModeConstant? ChownMode { get; set; }

    [JsonPropertyName("cifs")]
    public bool? Cifs { get; set; }

    [JsonPropertyName("hasRootAccess")]
    public bool? HasRootAccess { get; set; }

    [JsonPropertyName("kerberos5ReadOnly")]
    public bool? Kerberos5ReadOnly { get; set; }

    [JsonPropertyName("kerberos5ReadWrite")]
    public bool? Kerberos5ReadWrite { get; set; }

    [JsonPropertyName("kerberos5iReadOnly")]
    public bool? Kerberos5iReadOnly { get; set; }

    [JsonPropertyName("kerberos5iReadWrite")]
    public bool? Kerberos5iReadWrite { get; set; }

    [JsonPropertyName("kerberos5pReadOnly")]
    public bool? Kerberos5pReadOnly { get; set; }

    [JsonPropertyName("kerberos5pReadWrite")]
    public bool? Kerberos5pReadWrite { get; set; }

    [JsonPropertyName("nfsv3")]
    public bool? Nfsv3 { get; set; }

    [JsonPropertyName("nfsv41")]
    public bool? Nfsv41 { get; set; }

    [JsonPropertyName("ruleIndex")]
    public int? RuleIndex { get; set; }

    [JsonPropertyName("unixReadOnly")]
    public bool? UnixReadOnly { get; set; }

    [JsonPropertyName("unixReadWrite")]
    public bool? UnixReadWrite { get; set; }
}
