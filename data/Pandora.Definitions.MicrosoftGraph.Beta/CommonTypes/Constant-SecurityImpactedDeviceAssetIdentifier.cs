// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityImpactedDeviceAssetIdentifierConstant
{
    [Description("DeviceId")]
    @deviceId,

    [Description("DeviceName")]
    @deviceName,

    [Description("RemoteDeviceName")]
    @remoteDeviceName,

    [Description("TargetDeviceName")]
    @targetDeviceName,

    [Description("DestinationDeviceName")]
    @destinationDeviceName,
}
