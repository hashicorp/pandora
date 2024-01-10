// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamworkDeviceOperationOperationTypeConstant
{
    [Description("DeviceRestart")]
    @deviceRestart,

    [Description("ConfigUpdate")]
    @configUpdate,

    [Description("DeviceDiagnostics")]
    @deviceDiagnostics,

    [Description("SoftwareUpdate")]
    @softwareUpdate,

    [Description("DeviceManagementAgentConfigUpdate")]
    @deviceManagementAgentConfigUpdate,

    [Description("RemoteLogin")]
    @remoteLogin,

    [Description("RemoteLogout")]
    @remoteLogout,
}
