// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.CustomOperation;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NameCheckFailureReasonConstant
{
    [Description("AlreadyExists")]
    AlreadyExists,

    [Description("Invalid")]
    Invalid,
}
