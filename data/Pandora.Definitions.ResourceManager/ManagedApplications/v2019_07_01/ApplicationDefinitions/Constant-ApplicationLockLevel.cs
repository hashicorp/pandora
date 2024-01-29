// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2019_07_01.ApplicationDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationLockLevelConstant
{
    [Description("CanNotDelete")]
    CanNotDelete,

    [Description("None")]
    None,

    [Description("ReadOnly")]
    ReadOnly,
}
