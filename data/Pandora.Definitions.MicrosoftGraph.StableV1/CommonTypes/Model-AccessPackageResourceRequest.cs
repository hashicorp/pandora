// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class AccessPackageResourceRequestModel
{
    [JsonPropertyName("catalog")]
    public AccessPackageCatalogModel? Catalog { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestType")]
    public AccessPackageResourceRequestRequestTypeConstant? RequestType { get; set; }

    [JsonPropertyName("resource")]
    public AccessPackageResourceModel? Resource { get; set; }

    [JsonPropertyName("state")]
    public AccessPackageResourceRequestStateConstant? State { get; set; }
}
