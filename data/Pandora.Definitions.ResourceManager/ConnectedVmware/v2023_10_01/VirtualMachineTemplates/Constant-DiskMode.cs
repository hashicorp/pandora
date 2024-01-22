// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskModeConstant
{
    [Description("independent_nonpersistent")]
    IndependentNonpersistent,

    [Description("independent_persistent")]
    IndependentPersistent,

    [Description("persistent")]
    Persistent,
}
