// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationRecoveryPlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum HyperVReplicaAzureRpRecoveryPointTypeConstant
{
    [Description("Latest")]
    Latest,

    [Description("LatestApplicationConsistent")]
    LatestApplicationConsistent,

    [Description("LatestProcessed")]
    LatestProcessed,
}
