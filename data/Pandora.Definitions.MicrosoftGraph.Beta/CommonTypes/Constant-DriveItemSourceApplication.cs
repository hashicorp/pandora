// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DriveItemSourceApplicationConstant
{
    [Description("Teams")]
    @teams,

    [Description("Yammer")]
    @yammer,

    [Description("SharePoint")]
    @sharePoint,

    [Description("OneDrive")]
    @oneDrive,

    [Description("Stream")]
    @stream,

    [Description("PowerPoint")]
    @powerPoint,

    [Description("Office")]
    @office,
}
