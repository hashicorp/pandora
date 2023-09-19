// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CallRecordsNetworkInfoWifiBandConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Frequency24GHz")]
    @frequency24GHz,

    [Description("Frequency50GHz")]
    @frequency50GHz,

    [Description("Frequency60GHz")]
    @frequency60GHz,
}
