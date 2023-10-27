using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01.Domains;


internal class DomainPropertiesVerificationStatesModel
{
    [JsonPropertyName("DKIM")]
    public VerificationStatusRecordModel? DKIM { get; set; }

    [JsonPropertyName("DKIM2")]
    public VerificationStatusRecordModel? DKIM2 { get; set; }

    [JsonPropertyName("DMARC")]
    public VerificationStatusRecordModel? DMARC { get; set; }

    [JsonPropertyName("Domain")]
    public VerificationStatusRecordModel? Domain { get; set; }

    [JsonPropertyName("SPF")]
    public VerificationStatusRecordModel? SPF { get; set; }
}
