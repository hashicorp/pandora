using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.ReservedInstances;


internal class OperationStatusModel
{
    [JsonPropertyName("properties")]
    public ReportURLModel? Properties { get; set; }

    [JsonPropertyName("status")]
    public OperationStatusTypeConstant? Status { get; set; }
}
