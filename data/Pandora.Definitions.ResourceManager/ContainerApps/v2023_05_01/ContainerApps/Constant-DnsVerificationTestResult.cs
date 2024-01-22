// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DnsVerificationTestResultConstant
{
    [Description("Failed")]
    Failed,

    [Description("Passed")]
    Passed,

    [Description("Skipped")]
    Skipped,
}
