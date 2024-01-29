// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UnauthenticatedClientActionV2Constant
{
    [Description("AllowAnonymous")]
    AllowAnonymous,

    [Description("RedirectToLoginPage")]
    RedirectToLoginPage,

    [Description("Return401")]
    ReturnFourZeroOne,

    [Description("Return403")]
    ReturnFourZeroThree,
}
