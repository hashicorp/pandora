// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEdiscoveryFileProcessingStatusConstant
{
    [Description("Success")]
    @success,

    [Description("InternalError")]
    @internalError,

    [Description("UnknownError")]
    @unknownError,

    [Description("ProcessingTimeout")]
    @processingTimeout,

    [Description("InvalidFileId")]
    @invalidFileId,

    [Description("FileSizeIsZero")]
    @fileSizeIsZero,

    [Description("FileSizeIsTooLarge")]
    @fileSizeIsTooLarge,

    [Description("FileDepthLimitExceeded")]
    @fileDepthLimitExceeded,

    [Description("FileBodyIsTooLong")]
    @fileBodyIsTooLong,

    [Description("FileTypeIsUnknown")]
    @fileTypeIsUnknown,

    [Description("FileTypeIsNotSupported")]
    @fileTypeIsNotSupported,

    [Description("MalformedFile")]
    @malformedFile,

    [Description("ProtectedFile")]
    @protectedFile,

    [Description("PoisonFile")]
    @poisonFile,

    [Description("NoReviewSetSummaryGenerated")]
    @noReviewSetSummaryGenerated,

    [Description("ExtractionException")]
    @extractionException,

    [Description("OcrProcessingTimeout")]
    @ocrProcessingTimeout,

    [Description("OcrFileSizeExceedsLimit")]
    @ocrFileSizeExceedsLimit,
}
