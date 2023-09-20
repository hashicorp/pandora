// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EventMessageTypeConstant
{
    [Description("SingleInstance")]
    @singleInstance,

    [Description("Occurrence")]
    @occurrence,

    [Description("Exception")]
    @exception,

    [Description("SeriesMaster")]
    @seriesMaster,
}
