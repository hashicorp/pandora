// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Clusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CheckNameAvailabilityResourceTypeConstant
{
    [Description("Microsoft.DBforPostgreSQL/serverGroupsv2")]
    MicrosoftPointDBforPostgreSQLServerGroupsvTwo,
}
