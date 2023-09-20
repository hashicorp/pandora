// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ReferenceAttachmentPermissionConstant
{
    [Description("Other")]
    @other,

    [Description("View")]
    @view,

    [Description("Edit")]
    @edit,

    [Description("AnonymousView")]
    @anonymousView,

    [Description("AnonymousEdit")]
    @anonymousEdit,

    [Description("OrganizationView")]
    @organizationView,

    [Description("OrganizationEdit")]
    @organizationEdit,
}
