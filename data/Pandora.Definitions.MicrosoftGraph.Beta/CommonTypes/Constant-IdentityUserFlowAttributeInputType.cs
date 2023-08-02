// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IdentityUserFlowAttributeInputTypeConstant
{
    [Description("TextBox")]
    @textBox,

    [Description("DateTimeDropdown")]
    @dateTimeDropdown,

    [Description("RadioSingleSelect")]
    @radioSingleSelect,

    [Description("DropdownSingleSelect")]
    @dropdownSingleSelect,

    [Description("EmailBox")]
    @emailBox,

    [Description("CheckboxMultiSelect")]
    @checkboxMultiSelect,
}
