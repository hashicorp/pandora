// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_05_01.VolumeGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationTypeConstant
{
    [Description("ORACLE")]
    ORACLE,

    [Description("SAP-HANA")]
    SAPNegativeHANA,
}
