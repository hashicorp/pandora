using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter.v2023_04_01.DevBoxDefinitions;


internal class DevBoxDefinitionUpdatePropertiesModel
{
    [JsonPropertyName("hibernateSupport")]
    public HibernateSupportConstant? HibernateSupport { get; set; }

    [JsonPropertyName("imageReference")]
    public ImageReferenceModel? ImageReference { get; set; }

    [JsonPropertyName("osStorageType")]
    public string? OsStorageType { get; set; }

    [JsonPropertyName("sku")]
    public SkuModel? Sku { get; set; }
}
