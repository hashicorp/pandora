using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationProtectedItems;

[ValueForType("HyperVReplicaAzure")]
internal class HyperVReplicaAzurePlannedFailoverProviderInputModel : PlannedFailoverProviderSpecificFailoverInputModel
{
    [JsonPropertyName("primaryKekCertificatePfx")]
    public string? PrimaryKekCertificatePfx { get; set; }

    [JsonPropertyName("recoveryPointId")]
    public string? RecoveryPointId { get; set; }

    [JsonPropertyName("secondaryKekCertificatePfx")]
    public string? SecondaryKekCertificatePfx { get; set; }
}
