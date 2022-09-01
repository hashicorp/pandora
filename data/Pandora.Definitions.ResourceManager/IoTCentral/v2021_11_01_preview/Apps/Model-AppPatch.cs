using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.IoTCentral.v2021_11_01_preview.Apps;


internal class AppPatchModel
{
    [JsonPropertyName("identity")]
    public CustomTypes.SystemAssignedIdentity? Identity { get; set; }

    [JsonPropertyName("properties")]
    public AppPropertiesModel? Properties { get; set; }

    [JsonPropertyName("sku")]
    public AppSkuInfoModel? Sku { get; set; }

    [JsonPropertyName("tags")]
    public CustomTypes.Tags? Tags { get; set; }
}
