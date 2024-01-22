// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2022_04_01.WorkbooksAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkbookSharedTypeKindConstant
{
    [Description("shared")]
    Shared,
}
