// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosManagedAppProtectionAppActionIfDeviceComplianceRequiredConstant
{
    [Description("Block")]
    @block,

    [Description("Wipe")]
    @wipe,

    [Description("Warn")]
    @warn,
}
