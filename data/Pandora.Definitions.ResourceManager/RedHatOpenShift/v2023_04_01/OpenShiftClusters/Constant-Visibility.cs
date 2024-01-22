// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2023_04_01.OpenShiftClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VisibilityConstant
{
    [Description("Private")]
    Private,

    [Description("Public")]
    Public,
}
