// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceSourceConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("MicrosoftDefenderForEndpoint")]
    @microsoftDefenderForEndpoint,

    [Description("MicrosoftDefenderForIdentity")]
    @microsoftDefenderForIdentity,

    [Description("MicrosoftDefenderForCloudApps")]
    @microsoftDefenderForCloudApps,

    [Description("MicrosoftDefenderForOffice365")]
    @microsoftDefenderForOffice365,

    [Description("Microsoft365Defender")]
    @microsoft365Defender,

    [Description("AzureAdIdentityProtection")]
    @azureAdIdentityProtection,

    [Description("MicrosoftAppGovernance")]
    @microsoftAppGovernance,

    [Description("DataLossPrevention")]
    @dataLossPrevention,

    [Description("MicrosoftDefenderForCloud")]
    @microsoftDefenderForCloud,
}
