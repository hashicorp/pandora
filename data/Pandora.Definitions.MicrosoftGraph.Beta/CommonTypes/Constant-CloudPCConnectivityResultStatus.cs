// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCConnectivityResultStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Available")]
    @available,

    [Description("AvailableWithWarning")]
    @availableWithWarning,

    [Description("Unavailable")]
    @unavailable,
}
