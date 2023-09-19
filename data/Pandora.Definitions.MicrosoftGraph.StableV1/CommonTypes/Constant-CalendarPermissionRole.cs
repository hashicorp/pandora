// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CalendarPermissionRoleConstant
{
    [Description("None")]
    @none,

    [Description("FreeBusyRead")]
    @freeBusyRead,

    [Description("LimitedRead")]
    @limitedRead,

    [Description("Read")]
    @read,

    [Description("Write")]
    @write,

    [Description("DelegateWithoutPrivateEventAccess")]
    @delegateWithoutPrivateEventAccess,

    [Description("DelegateWithPrivateEventAccess")]
    @delegateWithPrivateEventAccess,

    [Description("Custom")]
    @custom,
}
