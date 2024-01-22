// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2023_08_15.DataConnections;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataConnectionTypeConstant
{
    [Description("Microsoft.Kusto/clusters/databases/dataConnections")]
    MicrosoftPointKustoClustersDatabasesDataConnections,
}
