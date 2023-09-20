// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NetworkaccessDeviceLinkDeviceVendorConstant
{
    [Description("BarracudaNetworks")]
    @barracudaNetworks,

    [Description("CheckPoint")]
    @checkPoint,

    [Description("CiscoMeraki")]
    @ciscoMeraki,

    [Description("Citrix")]
    @citrix,

    [Description("Fortinet")]
    @fortinet,

    [Description("HpeAruba")]
    @hpeAruba,

    [Description("NetFoundry")]
    @netFoundry,

    [Description("Nuage")]
    @nuage,

    [Description("OpenSystems")]
    @openSystems,

    [Description("PaloAltoNetworks")]
    @paloAltoNetworks,

    [Description("RiverbedTechnology")]
    @riverbedTechnology,

    [Description("SilverPeak")]
    @silverPeak,

    [Description("VmWareSdWan")]
    @vmWareSdWan,

    [Description("Versa")]
    @versa,

    [Description("Other")]
    @other,
}
