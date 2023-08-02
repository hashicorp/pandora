// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OnenoteSourceServiceConstant
{
    [Description("Unknown")]
    @Unknown,

    [Description("OneDrive")]
    @OneDrive,

    [Description("OneDriveForBusiness")]
    @OneDriveForBusiness,

    [Description("OnPremOneDriveForBusiness")]
    @OnPremOneDriveForBusiness,
}
