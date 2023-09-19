// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserRegistrationFeatureSummaryUserRolesConstant
{
    [Description("All")]
    @all,

    [Description("PrivilegedAdmin")]
    @privilegedAdmin,

    [Description("Admin")]
    @admin,

    [Description("User")]
    @user,
}
