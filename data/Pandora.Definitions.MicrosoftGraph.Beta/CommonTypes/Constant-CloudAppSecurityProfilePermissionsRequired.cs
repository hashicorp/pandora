// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudAppSecurityProfilePermissionsRequiredConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Anonymous")]
    @anonymous,

    [Description("Guest")]
    @guest,

    [Description("User")]
    @user,

    [Description("Administrator")]
    @administrator,

    [Description("System")]
    @system,
}
