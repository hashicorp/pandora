using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_06_15.WebTestsAPIs;


internal class WebTestPropertiesValidationRulesModel
{
    [JsonPropertyName("ContentValidation")]
    public WebTestPropertiesValidationRulesContentValidationModel? ContentValidation { get; set; }

    [JsonPropertyName("ExpectedHttpStatusCode")]
    public int? ExpectedHTTPStatusCode { get; set; }

    [JsonPropertyName("IgnoreHttpsStatusCode")]
    public bool? IgnoreHTTPSStatusCode { get; set; }

    [JsonPropertyName("SSLCertRemainingLifetimeCheck")]
    public int? SSLCertRemainingLifetimeCheck { get; set; }

    [JsonPropertyName("SSLCheck")]
    public bool? SSLCheck { get; set; }
}
