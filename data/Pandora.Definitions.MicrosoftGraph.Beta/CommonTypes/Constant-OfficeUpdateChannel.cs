// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OfficeUpdateChannelConstant
{
    [Description("None")]
    @none,

    [Description("Current")]
    @current,

    [Description("Deferred")]
    @deferred,

    [Description("FirstReleaseCurrent")]
    @firstReleaseCurrent,

    [Description("FirstReleaseDeferred")]
    @firstReleaseDeferred,

    [Description("MonthlyEnterprise")]
    @monthlyEnterprise,
}
