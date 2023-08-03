// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSourceScopesConstant
{
    [Description("None")]
    @none,

    [Description("AllTenantMailboxes")]
    @allTenantMailboxes,

    [Description("AllTenantSites")]
    @allTenantSites,

    [Description("AllCaseCustodians")]
    @allCaseCustodians,

    [Description("AllCaseNoncustodialDataSources")]
    @allCaseNoncustodialDataSources,
}
