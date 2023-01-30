using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Shares;


internal class RefreshDetailsModel
{
    [JsonPropertyName("errorManifestFile")]
    public string? ErrorManifestFile { get; set; }

    [JsonPropertyName("inProgressRefreshJobId")]
    public string? InProgressRefreshJobId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastCompletedRefreshJobTimeInUTC")]
    public DateTime? LastCompletedRefreshJobTimeInUTC { get; set; }

    [JsonPropertyName("lastJob")]
    public string? LastJob { get; set; }
}
