// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MSDeployProvisioningStateConstant
{
    [Description("accepted")]
    Accepted,

    [Description("canceled")]
    Canceled,

    [Description("failed")]
    Failed,

    [Description("running")]
    Running,

    [Description("succeeded")]
    Succeeded,
}
