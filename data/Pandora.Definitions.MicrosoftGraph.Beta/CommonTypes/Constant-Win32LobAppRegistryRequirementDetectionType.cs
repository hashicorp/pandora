// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Win32LobAppRegistryRequirementDetectionTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Exists")]
    @exists,

    [Description("DoesNotExist")]
    @doesNotExist,

    [Description("String")]
    @string,

    [Description("Integer")]
    @integer,

    [Description("Version")]
    @version,
}
