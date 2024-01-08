using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.DataConnectors;


internal class TIDataConnectorPropertiesModel
{
    [JsonPropertyName("dataTypes")]
    public TIDataConnectorDataTypesModel? DataTypes { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("tipLookbackPeriod")]
    public DateTime? TipLookbackPeriod { get; set; }
}
