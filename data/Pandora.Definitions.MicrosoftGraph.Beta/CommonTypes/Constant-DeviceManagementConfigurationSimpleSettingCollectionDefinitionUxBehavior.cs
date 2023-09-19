// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationSimpleSettingCollectionDefinitionUxBehaviorConstant
{
    [Description("Default")]
    @default,

    [Description("Dropdown")]
    @dropdown,

    [Description("SmallTextBox")]
    @smallTextBox,

    [Description("LargeTextBox")]
    @largeTextBox,

    [Description("Toggle")]
    @toggle,

    [Description("MultiheaderGrid")]
    @multiheaderGrid,

    [Description("ContextPane")]
    @contextPane,
}
