// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EndpointSecurityConfigurationApplicablePlatformConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("MacOS")]
    @macOS,

    [Description("Windows10AndLater")]
    @windows10AndLater,

    [Description("Windows10AndWindowsServer")]
    @windows10AndWindowsServer,
}
