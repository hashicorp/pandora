using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.AutomationAccount;


internal class AutomationAccountCreateOrUpdatePropertiesModel
{
    [JsonPropertyName("encryption")]
    public EncryptionPropertiesModel? Encryption { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public bool? PublicNetworkAccess { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }
}
