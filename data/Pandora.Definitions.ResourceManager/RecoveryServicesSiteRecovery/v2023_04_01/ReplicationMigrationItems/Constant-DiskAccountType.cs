// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_04_01.ReplicationMigrationItems;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskAccountTypeConstant
{
    [Description("Premium_LRS")]
    PremiumLRS,

    [Description("Standard_LRS")]
    StandardLRS,

    [Description("StandardSSD_LRS")]
    StandardSSDLRS,
}
