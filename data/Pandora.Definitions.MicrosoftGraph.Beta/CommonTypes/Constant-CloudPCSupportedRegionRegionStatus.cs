// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCSupportedRegionRegionStatusConstant
{
    [Description("Available")]
    @available,

    [Description("Restricted")]
    @restricted,

    [Description("Unavailable")]
    @unavailable,
}
