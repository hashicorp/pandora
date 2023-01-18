using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class AgreementContentModel
{
    [JsonPropertyName("aS2")]
    public AS2AgreementContentModel? AS2 { get; set; }

    [JsonPropertyName("edifact")]
    public EdifactAgreementContentModel? Edifact { get; set; }

    [JsonPropertyName("x12")]
    public X12AgreementContentModel? X12 { get; set; }
}
