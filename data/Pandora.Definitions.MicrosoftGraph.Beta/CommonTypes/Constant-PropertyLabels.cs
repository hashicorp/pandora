// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PropertyLabelsConstant
{
    [Description("Title")]
    @title,

    [Description("Url")]
    @url,

    [Description("CreatedBy")]
    @createdBy,

    [Description("LastModifiedBy")]
    @lastModifiedBy,

    [Description("Authors")]
    @authors,

    [Description("CreatedDateTime")]
    @createdDateTime,

    [Description("LastModifiedDateTime")]
    @lastModifiedDateTime,

    [Description("FileName")]
    @fileName,

    [Description("FileExtension")]
    @fileExtension,
}
