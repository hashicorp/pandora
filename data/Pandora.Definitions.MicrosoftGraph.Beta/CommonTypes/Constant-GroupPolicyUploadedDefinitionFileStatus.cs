// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupPolicyUploadedDefinitionFileStatusConstant
{
    [Description("None")]
    @none,

    [Description("UploadInProgress")]
    @uploadInProgress,

    [Description("Available")]
    @available,

    [Description("Assigned")]
    @assigned,

    [Description("RemovalInProgress")]
    @removalInProgress,

    [Description("UploadFailed")]
    @uploadFailed,

    [Description("RemovalFailed")]
    @removalFailed,
}
