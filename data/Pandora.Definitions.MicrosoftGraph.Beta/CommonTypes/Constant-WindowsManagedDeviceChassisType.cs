// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsManagedDeviceChassisTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Desktop")]
    @desktop,

    [Description("Laptop")]
    @laptop,

    [Description("WorksWorkstation")]
    @worksWorkstation,

    [Description("EnterpriseServer")]
    @enterpriseServer,

    [Description("Phone")]
    @phone,

    [Description("Tablet")]
    @tablet,

    [Description("MobileOther")]
    @mobileOther,

    [Description("MobileUnknown")]
    @mobileUnknown,
}
