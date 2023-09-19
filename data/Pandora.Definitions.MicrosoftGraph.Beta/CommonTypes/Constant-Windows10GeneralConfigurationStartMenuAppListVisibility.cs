// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10GeneralConfigurationStartMenuAppListVisibilityConstant
{
    [Description("UserDefined")]
    @userDefined,

    [Description("Collapse")]
    @collapse,

    [Description("Remove")]
    @remove,

    [Description("DisableSettingsApp")]
    @disableSettingsApp,
}
