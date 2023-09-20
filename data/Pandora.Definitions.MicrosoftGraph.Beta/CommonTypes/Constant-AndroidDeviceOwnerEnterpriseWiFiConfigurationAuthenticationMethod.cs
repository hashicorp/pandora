// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerEnterpriseWiFiConfigurationAuthenticationMethodConstant
{
    [Description("Certificate")]
    @certificate,

    [Description("UsernameAndPassword")]
    @usernameAndPassword,

    [Description("DerivedCredential")]
    @derivedCredential,
}
