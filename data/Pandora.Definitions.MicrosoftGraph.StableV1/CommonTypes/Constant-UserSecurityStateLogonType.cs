// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UserSecurityStateLogonTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Interactive")]
    @interactive,

    [Description("RemoteInteractive")]
    @remoteInteractive,

    [Description("Network")]
    @network,

    [Description("Batch")]
    @batch,

    [Description("Service")]
    @service,
}
