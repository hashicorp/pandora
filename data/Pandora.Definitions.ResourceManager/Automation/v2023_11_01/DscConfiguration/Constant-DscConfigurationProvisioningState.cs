// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.DscConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DscConfigurationProvisioningStateConstant
{
    [Description("Succeeded")]
    Succeeded,
}
