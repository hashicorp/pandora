// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsPrivacyDataAccessLevelConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("ForceAllow")]
    @forceAllow,

    [Description("ForceDeny")]
    @forceDeny,

    [Description("UserInControl")]
    @userInControl,
}
