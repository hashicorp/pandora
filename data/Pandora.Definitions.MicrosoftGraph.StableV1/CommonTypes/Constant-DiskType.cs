// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DiskTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Hdd")]
    @hdd,

    [Description("Ssd")]
    @ssd,
}
