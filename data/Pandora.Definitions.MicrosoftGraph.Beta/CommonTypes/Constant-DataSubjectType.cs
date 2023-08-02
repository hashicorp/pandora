// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataSubjectTypeConstant
{
    [Description("Customer")]
    @customer,

    [Description("CurrentEmployee")]
    @currentEmployee,

    [Description("FormerEmployee")]
    @formerEmployee,

    [Description("ProspectiveEmployee")]
    @prospectiveEmployee,

    [Description("Student")]
    @student,

    [Description("Teacher")]
    @teacher,

    [Description("Faculty")]
    @faculty,

    [Description("Other")]
    @other,
}
