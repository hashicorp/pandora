using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.SubAccount;


internal class LogzOrganizationPropertiesModel
{
    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("enterpriseAppId")]
    public string? EnterpriseAppId { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("singleSignOnUrl")]
    public string? SingleSignOnUrl { get; set; }
}
