// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MicrosoftManagedDesktopTypeConstant
{
    [Description("NotManaged")]
    @notManaged,

    [Description("PremiumManaged")]
    @premiumManaged,

    [Description("StandardManaged")]
    @standardManaged,

    [Description("StarterManaged")]
    @starterManaged,
}
