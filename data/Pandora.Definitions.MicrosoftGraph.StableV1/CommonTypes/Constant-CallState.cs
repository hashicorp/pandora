// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallStateConstant
{
    [Description("Incoming")]
    @incoming,

    [Description("Establishing")]
    @establishing,

    [Description("Established")]
    @established,

    [Description("Hold")]
    @hold,

    [Description("Transferring")]
    @transferring,

    [Description("TransferAccepted")]
    @transferAccepted,

    [Description("Redirecting")]
    @redirecting,

    [Description("Terminating")]
    @terminating,

    [Description("Terminated")]
    @terminated,
}
