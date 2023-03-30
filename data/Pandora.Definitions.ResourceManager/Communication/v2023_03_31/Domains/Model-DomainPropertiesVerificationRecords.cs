using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2023_03_31.Domains;


internal class DomainPropertiesVerificationRecordsModel
{
    [JsonPropertyName("DKIM")]
    public DnsRecordModel? DKIM { get; set; }

    [JsonPropertyName("DKIM2")]
    public DnsRecordModel? DKIM2 { get; set; }

    [JsonPropertyName("DMARC")]
    public DnsRecordModel? DMARC { get; set; }

    [JsonPropertyName("Domain")]
    public DnsRecordModel? Domain { get; set; }

    [JsonPropertyName("SPF")]
    public DnsRecordModel? SPF { get; set; }
}
