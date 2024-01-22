// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.VMCollectionUpdate;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationNameConstant
{
    [Description("Add")]
    Add,

    [Description("Delete")]
    Delete,
}
