// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPackageCustomExtensionStageConstant
{
    [Description("AssignmentRequestCreated")]
    @assignmentRequestCreated,

    [Description("AssignmentRequestApproved")]
    @assignmentRequestApproved,

    [Description("AssignmentRequestGranted")]
    @assignmentRequestGranted,

    [Description("AssignmentRequestRemoved")]
    @assignmentRequestRemoved,

    [Description("AssignmentFourteenDaysBeforeExpiration")]
    @assignmentFourteenDaysBeforeExpiration,

    [Description("AssignmentOneDayBeforeExpiration")]
    @assignmentOneDayBeforeExpiration,
}
