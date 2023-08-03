// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceEventLevelConstant
{
    [Description("None")]
    @none,

    [Description("Verbose")]
    @verbose,

    [Description("Information")]
    @information,

    [Description("Warning")]
    @warning,

    [Description("Error")]
    @error,

    [Description("Critical")]
    @critical,
}
