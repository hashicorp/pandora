// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.DataConnectorsConnect;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectAuthKindConstant
{
    [Description("APIKey")]
    APIKey,

    [Description("Basic")]
    Basic,

    [Description("OAuth2")]
    OAuthTwo,
}
