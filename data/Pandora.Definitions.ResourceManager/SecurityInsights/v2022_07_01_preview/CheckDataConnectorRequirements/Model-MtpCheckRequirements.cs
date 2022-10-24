using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.CheckDataConnectorRequirements;

[ValueForType("MicrosoftThreatProtection")]
internal class MtpCheckRequirementsModel : DataConnectorsCheckRequirementsModel
{
    [JsonPropertyName("properties")]
    public DataConnectorTenantIdModel? Properties { get; set; }
}
