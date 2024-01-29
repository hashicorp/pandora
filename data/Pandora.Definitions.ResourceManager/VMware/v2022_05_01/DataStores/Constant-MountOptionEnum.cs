// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.DataStores;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MountOptionEnumConstant
{
    [Description("ATTACH")]
    ATTACH,

    [Description("MOUNT")]
    MOUNT,
}
