// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationSettingAccessTypesConstant
{
    [Description("None")]
    @none,

    [Description("Add")]
    @add,

    [Description("Copy")]
    @copy,

    [Description("Delete")]
    @delete,

    [Description("Get")]
    @get,

    [Description("Replace")]
    @replace,

    [Description("Execute")]
    @execute,
}
