// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PrinterDocumentConfigurationScalingConstant
{
    [Description("Auto")]
    @auto,

    [Description("ShrinkToFit")]
    @shrinkToFit,

    [Description("Fill")]
    @fill,

    [Description("Fit")]
    @fit,

    [Description("None")]
    @none,
}
