// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CatalogCollationTypeConstant
{
    [Description("DATABASE_DEFAULT")]
    DATABASEDEFAULT,

    [Description("SQL_Latin1_General_CP1_CI_AS")]
    SQLLatinOneGeneralCPOneCIAS,
}
