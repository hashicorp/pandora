// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class OnPremisesCurrentExportDataModel
{
    [JsonPropertyName("clientMachineName")]
    public string? ClientMachineName { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("pendingObjectsAddition")]
    public int? PendingObjectsAddition { get; set; }

    [JsonPropertyName("pendingObjectsDeletion")]
    public int? PendingObjectsDeletion { get; set; }

    [JsonPropertyName("pendingObjectsUpdate")]
    public int? PendingObjectsUpdate { get; set; }

    [JsonPropertyName("serviceAccount")]
    public string? ServiceAccount { get; set; }

    [JsonPropertyName("successfulLinksProvisioningCount")]
    public long? SuccessfulLinksProvisioningCount { get; set; }

    [JsonPropertyName("successfulObjectsProvisioningCount")]
    public int? SuccessfulObjectsProvisioningCount { get; set; }

    [JsonPropertyName("totalConnectorSpaceObjects")]
    public int? TotalConnectorSpaceObjects { get; set; }
}
