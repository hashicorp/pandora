using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPVirtualInstances;

[ValueForType("FullResourceName")]
internal class ThreeTierFullResourceNamesModel : ThreeTierCustomResourceNamesModel
{
    [JsonPropertyName("applicationServer")]
    public ApplicationServerFullResourceNamesModel? ApplicationServer { get; set; }

    [JsonPropertyName("centralServer")]
    public CentralServerFullResourceNamesModel? CentralServer { get; set; }

    [JsonPropertyName("databaseServer")]
    public DatabaseServerFullResourceNamesModel? DatabaseServer { get; set; }

    [JsonPropertyName("sharedStorage")]
    public SharedStorageResourceNamesModel? SharedStorage { get; set; }
}
