// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.DisasterRecoveryConfigs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateDRConstant
{
    [Description("Accepted")]
    Accepted,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
