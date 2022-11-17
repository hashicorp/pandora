using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PrivateDNS.v2020_06_01.RecordSets;


internal class RecordSetPropertiesModel
{
    [JsonPropertyName("aRecords")]
    public List<ARecordModel>? ARecords { get; set; }

    [JsonPropertyName("aaaaRecords")]
    public List<AaaaRecordModel>? AaaaRecords { get; set; }

    [JsonPropertyName("cnameRecord")]
    public CnameRecordModel? CnameRecord { get; set; }

    [JsonPropertyName("fqdn")]
    public string? Fqdn { get; set; }

    [JsonPropertyName("isAutoRegistered")]
    public bool? IsAutoRegistered { get; set; }

    [JsonPropertyName("metadata")]
    public Dictionary<string, string>? Metadata { get; set; }

    [JsonPropertyName("mxRecords")]
    public List<MxRecordModel>? MxRecords { get; set; }

    [JsonPropertyName("ptrRecords")]
    public List<PtrRecordModel>? PtrRecords { get; set; }

    [JsonPropertyName("soaRecord")]
    public SoaRecordModel? SoaRecord { get; set; }

    [JsonPropertyName("srvRecords")]
    public List<SrvRecordModel>? SrvRecords { get; set; }

    [JsonPropertyName("ttl")]
    public int? Ttl { get; set; }

    [JsonPropertyName("txtRecords")]
    public List<TxtRecordModel>? TxtRecords { get; set; }
}
