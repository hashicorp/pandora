// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Win32LobAppFileSystemRequirementDetectionTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Exists")]
    @exists,

    [Description("ModifiedDate")]
    @modifiedDate,

    [Description("CreatedDate")]
    @createdDate,

    [Description("Version")]
    @version,

    [Description("SizeInMB")]
    @sizeInMB,

    [Description("DoesNotExist")]
    @doesNotExist,
}
