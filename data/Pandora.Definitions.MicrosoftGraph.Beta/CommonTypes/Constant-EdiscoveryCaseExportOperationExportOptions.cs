// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EdiscoveryCaseExportOperationExportOptionsConstant
{
    [Description("OriginalFiles")]
    @originalFiles,

    [Description("Text")]
    @text,

    [Description("PdfReplacement")]
    @pdfReplacement,

    [Description("FileInfo")]
    @fileInfo,

    [Description("Tags")]
    @tags,
}
