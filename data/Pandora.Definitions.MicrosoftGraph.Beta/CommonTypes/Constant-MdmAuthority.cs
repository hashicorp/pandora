// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MdmAuthorityConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Intune")]
    @intune,

    [Description("Sccm")]
    @sccm,

    [Description("Office365")]
    @office365,
}
