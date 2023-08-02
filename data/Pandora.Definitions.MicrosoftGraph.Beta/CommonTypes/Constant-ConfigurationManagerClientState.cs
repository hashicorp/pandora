// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationManagerClientStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Installed")]
    @installed,

    [Description("Healthy")]
    @healthy,

    [Description("InstallFailed")]
    @installFailed,

    [Description("UpdateFailed")]
    @updateFailed,

    [Description("CommunicationError")]
    @communicationError,
}
