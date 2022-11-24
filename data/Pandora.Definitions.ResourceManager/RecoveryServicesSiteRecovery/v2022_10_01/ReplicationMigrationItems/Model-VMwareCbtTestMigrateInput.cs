using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationMigrationItems;

[ValueForType("VMwareCbt")]
internal class VMwareCbtTestMigrateInputModel : TestMigrateProviderSpecificInputModel
{
    [JsonPropertyName("networkId")]
    [Required]
    public string NetworkId { get; set; }

    [JsonPropertyName("recoveryPointId")]
    [Required]
    public string RecoveryPointId { get; set; }

    [JsonPropertyName("vmNics")]
    public List<VMwareCbtNicInputModel>? VmNics { get; set; }
}
