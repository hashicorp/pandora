// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ConnectedVmware.v2023_10_01.VirtualMachineTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskTypeConstant
{
    [Description("flat")]
    Flat,

    [Description("pmem")]
    Pmem,

    [Description("rawphysical")]
    Rawphysical,

    [Description("rawvirtual")]
    Rawvirtual,

    [Description("sesparse")]
    Sesparse,

    [Description("sparse")]
    Sparse,

    [Description("unknown")]
    Unknown,
}
