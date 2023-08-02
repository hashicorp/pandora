// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupPolicyOperationTypeConstant
{
    [Description("None")]
    @none,

    [Description("Upload")]
    @upload,

    [Description("UploadNewVersion")]
    @uploadNewVersion,

    [Description("AddLanguageFiles")]
    @addLanguageFiles,

    [Description("RemoveLanguageFiles")]
    @removeLanguageFiles,

    [Description("UpdateLanguageFiles")]
    @updateLanguageFiles,

    [Description("Remove")]
    @remove,
}
