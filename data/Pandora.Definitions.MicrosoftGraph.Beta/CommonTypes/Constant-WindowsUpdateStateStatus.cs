// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdateStateStatusConstant
{
    [Description("UpToDate")]
    @upToDate,

    [Description("PendingInstallation")]
    @pendingInstallation,

    [Description("PendingReboot")]
    @pendingReboot,

    [Description("Failed")]
    @failed,
}
