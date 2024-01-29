// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_06_01.Operation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetDiskNetworkAccessOptionConstant
{
    [Description("EnablePrivateAccessForAllDisks")]
    EnablePrivateAccessForAllDisks,

    [Description("EnablePublicAccessForAllDisks")]
    EnablePublicAccessForAllDisks,

    [Description("SameAsOnSourceDisks")]
    SameAsOnSourceDisks,
}
