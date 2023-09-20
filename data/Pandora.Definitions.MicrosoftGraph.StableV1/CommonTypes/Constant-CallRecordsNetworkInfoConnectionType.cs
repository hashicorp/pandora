// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallRecordsNetworkInfoConnectionTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Wired")]
    @wired,

    [Description("Wifi")]
    @wifi,

    [Description("Mobile")]
    @mobile,

    [Description("Tunnel")]
    @tunnel,
}
