// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsPhone81GeneralConfigurationCompliantAppListTypeConstant
{
    [Description("None")]
    @none,

    [Description("AppsInListCompliant")]
    @appsInListCompliant,

    [Description("AppsNotInListCompliant")]
    @appsNotInListCompliant,
}
