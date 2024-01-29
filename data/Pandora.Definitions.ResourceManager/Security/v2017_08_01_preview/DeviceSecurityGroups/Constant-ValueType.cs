// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2017_08_01_preview.DeviceSecurityGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValueTypeConstant
{
    [Description("IpCidr")]
    IPCidr,

    [Description("String")]
    String,
}
