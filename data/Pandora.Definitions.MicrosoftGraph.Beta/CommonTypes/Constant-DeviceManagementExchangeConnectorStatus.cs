// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementExchangeConnectorStatusConstant
{
    [Description("None")]
    @none,

    [Description("ConnectionPending")]
    @connectionPending,

    [Description("Connected")]
    @connected,

    [Description("Disconnected")]
    @disconnected,
}
