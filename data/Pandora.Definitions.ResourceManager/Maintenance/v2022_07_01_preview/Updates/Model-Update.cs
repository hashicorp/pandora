using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.Updates;


internal class UpdateModel
{
    [JsonPropertyName("impactDurationInSec")]
    public int? ImpactDurationInSec { get; set; }

    [JsonPropertyName("impactType")]
    public ImpactTypeConstant? ImpactType { get; set; }

    [JsonPropertyName("maintenanceScope")]
    public MaintenanceScopeConstant? MaintenanceScope { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("notBefore")]
    public DateTime? NotBefore { get; set; }

    [JsonPropertyName("properties")]
    public UpdatePropertiesModel? Properties { get; set; }

    [JsonPropertyName("status")]
    public UpdateStatusConstant? Status { get; set; }
}
