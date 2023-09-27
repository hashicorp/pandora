using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.InventoryItems;

[ValueForType("Datastore")]
internal class DatastoreInventoryItemModel : InventoryItemPropertiesModel
{
    [JsonPropertyName("capacityGB")]
    public int? CapacityGB { get; set; }

    [JsonPropertyName("freeSpaceGB")]
    public int? FreeSpaceGB { get; set; }
}
