// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_01_01.ReplicationProtectionIntents;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum A2ARecoveryAvailabilityTypeConstant
{
    [Description("AvailabilitySet")]
    AvailabilitySet,

    [Description("AvailabilityZone")]
    AvailabilityZone,

    [Description("Single")]
    Single,
}
