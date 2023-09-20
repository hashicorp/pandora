// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MacOSSoftwareUpdateConfigurationCriticalUpdateBehaviorConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Default")]
    @default,

    [Description("DownloadOnly")]
    @downloadOnly,

    [Description("InstallASAP")]
    @installASAP,

    [Description("NotifyOnly")]
    @notifyOnly,

    [Description("InstallLater")]
    @installLater,
}
