using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.CertificateObjectLocalRulestack;


internal class CertificateObjectModel
{
    [JsonPropertyName("auditComment")]
    public string? AuditComment { get; set; }

    [JsonPropertyName("certificateSelfSigned")]
    [Required]
    public BooleanEnumConstant CertificateSelfSigned { get; set; }

    [JsonPropertyName("certificateSignerResourceId")]
    public string? CertificateSignerResourceId { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("provisioningState")]
    public ProvisioningStateConstant? ProvisioningState { get; set; }
}
