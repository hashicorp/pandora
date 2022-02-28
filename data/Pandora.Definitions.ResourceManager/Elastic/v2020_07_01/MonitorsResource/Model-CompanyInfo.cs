using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitorsResource;


internal class CompanyInfoModel
{
    [JsonPropertyName("business")]
    public string? Business { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonPropertyName("employeesNumber")]
    public string? EmployeesNumber { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }
}
