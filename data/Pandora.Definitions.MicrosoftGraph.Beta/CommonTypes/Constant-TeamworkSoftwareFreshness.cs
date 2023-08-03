// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamworkSoftwareFreshnessConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Latest")]
    @latest,

    [Description("UpdateAvailable")]
    @updateAvailable,
}
