using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.MonitorsResource;


internal class DatadogOrganizationPropertiesModel
{
    [JsonPropertyName("apiKey")]
    public string? ApiKey { get; set; }

    [JsonPropertyName("applicationKey")]
    public string? ApplicationKey { get; set; }

    [JsonPropertyName("enterpriseAppId")]
    public string? EnterpriseAppId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("linkingAuthCode")]
    public string? LinkingAuthCode { get; set; }

    [JsonPropertyName("linkingClientId")]
    public string? LinkingClientId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("redirectUri")]
    public string? RedirectUri { get; set; }
}
