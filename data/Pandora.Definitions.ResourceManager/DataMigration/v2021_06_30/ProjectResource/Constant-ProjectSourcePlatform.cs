// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.ProjectResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProjectSourcePlatformConstant
{
    [Description("MongoDb")]
    MongoDb,

    [Description("MySQL")]
    MySQL,

    [Description("PostgreSql")]
    PostgreSql,

    [Description("SQL")]
    SQL,

    [Description("Unknown")]
    Unknown,
}
