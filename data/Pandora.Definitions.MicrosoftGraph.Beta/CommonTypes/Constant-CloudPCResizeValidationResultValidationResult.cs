// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCResizeValidationResultValidationResultConstant
{
    [Description("Success")]
    @success,

    [Description("CloudPCNotFound")]
    @cloudPcNotFound,

    [Description("OperationConflict")]
    @operationConflict,

    [Description("OperationNotSupported")]
    @operationNotSupported,

    [Description("TargetLicenseHasAssigned")]
    @targetLicenseHasAssigned,

    [Description("InternalServerError")]
    @internalServerError,
}
