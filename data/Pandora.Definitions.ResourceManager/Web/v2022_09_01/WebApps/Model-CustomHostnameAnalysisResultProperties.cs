using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;


internal class CustomHostnameAnalysisResultPropertiesModel
{
    [JsonPropertyName("aRecords")]
    public List<string>? ARecords { get; set; }

    [JsonPropertyName("alternateCNameRecords")]
    public List<string>? AlternateCNameRecords { get; set; }

    [JsonPropertyName("alternateTxtRecords")]
    public List<string>? AlternateTxtRecords { get; set; }

    [JsonPropertyName("cNameRecords")]
    public List<string>? CNameRecords { get; set; }

    [JsonPropertyName("conflictingAppResourceId")]
    public string? ConflictingAppResourceId { get; set; }

    [JsonPropertyName("customDomainVerificationFailureInfo")]
    public ErrorEntityModel? CustomDomainVerificationFailureInfo { get; set; }

    [JsonPropertyName("customDomainVerificationTest")]
    public DnsVerificationTestResultConstant? CustomDomainVerificationTest { get; set; }

    [JsonPropertyName("hasConflictAcrossSubscription")]
    public bool? HasConflictAcrossSubscription { get; set; }

    [JsonPropertyName("hasConflictOnScaleUnit")]
    public bool? HasConflictOnScaleUnit { get; set; }

    [JsonPropertyName("isHostnameAlreadyVerified")]
    public bool? IsHostnameAlreadyVerified { get; set; }

    [JsonPropertyName("txtRecords")]
    public List<string>? TxtRecords { get; set; }
}
