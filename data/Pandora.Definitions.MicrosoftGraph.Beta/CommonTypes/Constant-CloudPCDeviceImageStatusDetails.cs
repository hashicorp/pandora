// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCDeviceImageStatusDetailsConstant
{
    [Description("InternalServerError")]
    @internalServerError,

    [Description("SourceImageNotFound")]
    @sourceImageNotFound,

    [Description("OsVersionNotSupported")]
    @osVersionNotSupported,

    [Description("SourceImageInvalid")]
    @sourceImageInvalid,

    [Description("SourceImageNotGeneralized")]
    @sourceImageNotGeneralized,

    [Description("VmAlreadyAzureAdjoined")]
    @vmAlreadyAzureAdjoined,

    [Description("PaidSourceImageNotSupport")]
    @paidSourceImageNotSupport,

    [Description("SourceImageNotSupportCustomizeVMName")]
    @sourceImageNotSupportCustomizeVMName,

    [Description("SourceImageSizeExceedsLimitation")]
    @sourceImageSizeExceedsLimitation,
}
