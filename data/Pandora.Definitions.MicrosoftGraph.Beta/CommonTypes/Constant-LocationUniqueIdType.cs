// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LocationUniqueIdTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("LocationStore")]
    @locationStore,

    [Description("Directory")]
    @directory,

    [Description("Private")]
    @private,

    [Description("Bing")]
    @bing,
}
