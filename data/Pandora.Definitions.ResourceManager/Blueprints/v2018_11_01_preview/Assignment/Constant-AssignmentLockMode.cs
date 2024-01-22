// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.Assignment;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssignmentLockModeConstant
{
    [Description("AllResourcesDoNotDelete")]
    AllResourcesDoNotDelete,

    [Description("AllResourcesReadOnly")]
    AllResourcesReadOnly,

    [Description("None")]
    None,
}
