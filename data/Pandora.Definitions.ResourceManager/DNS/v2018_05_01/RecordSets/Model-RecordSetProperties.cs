using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets
{

    internal class RecordSetPropertiesModel
    {
        [JsonPropertyName("AAAARecords")]
        public List<AaaaRecordModel>? AAAARecords { get; set; }

        [JsonPropertyName("ARecords")]
        public List<ARecordModel>? ARecords { get; set; }

        [JsonPropertyName("CNAMERecord")]
        public CnameRecordModel? CNAMERecord { get; set; }

        [JsonPropertyName("caaRecords")]
        public List<CaaRecordModel>? CaaRecords { get; set; }

        [JsonPropertyName("fqdn")]
        public string? Fqdn { get; set; }

        [JsonPropertyName("MXRecords")]
        public List<MxRecordModel>? MXRecords { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, string>? Metadata { get; set; }

        [JsonPropertyName("NSRecords")]
        public List<NsRecordModel>? NSRecords { get; set; }

        [JsonPropertyName("PTRRecords")]
        public List<PtrRecordModel>? PTRRecords { get; set; }

        [JsonPropertyName("provisioningState")]
        public string? ProvisioningState { get; set; }

        [JsonPropertyName("SOARecord")]
        public SoaRecordModel? SOARecord { get; set; }

        [JsonPropertyName("SRVRecords")]
        public List<SrvRecordModel>? SRVRecords { get; set; }

        [JsonPropertyName("TTL")]
        public int? TTL { get; set; }

        [JsonPropertyName("TXTRecords")]
        public List<TxtRecordModel>? TXTRecords { get; set; }

        [JsonPropertyName("targetResource")]
        public SubResourceModel? TargetResource { get; set; }
    }
}
