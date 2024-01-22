// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2022_08_01.Image;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OsStateConstant
{
    [Description("Generalized")]
    Generalized,

    [Description("Specialized")]
    Specialized,
}
