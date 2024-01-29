// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ExternalSecuritySolutions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AadConnectivityStateConstant
{
    [Description("Connected")]
    Connected,

    [Description("Discovered")]
    Discovered,

    [Description("NotLicensed")]
    NotLicensed,
}
