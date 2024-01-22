// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31.Runbook;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunbookProvisioningStateConstant
{
    [Description("Succeeded")]
    Succeeded,
}
