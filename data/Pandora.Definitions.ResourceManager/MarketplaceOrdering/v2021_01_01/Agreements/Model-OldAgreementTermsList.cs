using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MarketplaceOrdering.v2021_01_01.Agreements;


internal class OldAgreementTermsListModel
{
    [JsonPropertyName("value")]
    public List<OldAgreementTermsModel>? Value { get; set; }
}
