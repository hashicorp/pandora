// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.ResourceProviders;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CheckNameResourceTypesConstant
{
    [Description("HostingEnvironment")]
    HostingEnvironment,

    [Description("Microsoft.Web/hostingEnvironments")]
    MicrosoftPointWebHostingEnvironments,

    [Description("Microsoft.Web/publishingUsers")]
    MicrosoftPointWebPublishingUsers,

    [Description("Microsoft.Web/sites")]
    MicrosoftPointWebSites,

    [Description("Microsoft.Web/sites/slots")]
    MicrosoftPointWebSitesSlots,

    [Description("PublishingUser")]
    PublishingUser,

    [Description("Site")]
    Site,

    [Description("Slot")]
    Slot,
}
