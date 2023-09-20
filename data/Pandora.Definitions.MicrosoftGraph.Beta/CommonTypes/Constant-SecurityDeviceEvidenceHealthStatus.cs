// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityDeviceEvidenceHealthStatusConstant
{
    [Description("Active")]
    @active,

    [Description("Inactive")]
    @inactive,

    [Description("ImpairedCommunication")]
    @impairedCommunication,

    [Description("NoSensorData")]
    @noSensorData,

    [Description("NoSensorDataImpairedCommunication")]
    @noSensorDataImpairedCommunication,

    [Description("Unknown")]
    @unknown,
}
