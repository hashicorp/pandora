// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Databricks.v2022_04_01_preview.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeySourceConstant
{
    [Description("Default")]
    Default,

    [Description("Microsoft.Keyvault")]
    MicrosoftPointKeyvault,
}
