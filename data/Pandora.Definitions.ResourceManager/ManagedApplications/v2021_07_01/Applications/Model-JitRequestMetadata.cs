using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.Applications;


internal class JitRequestMetadataModel
{
    [JsonPropertyName("originRequestId")]
    public string? OriginRequestId { get; set; }

    [JsonPropertyName("requestorId")]
    public string? RequestorId { get; set; }

    [JsonPropertyName("subjectDisplayName")]
    public string? SubjectDisplayName { get; set; }

    [JsonPropertyName("tenantDisplayName")]
    public string? TenantDisplayName { get; set; }
}
