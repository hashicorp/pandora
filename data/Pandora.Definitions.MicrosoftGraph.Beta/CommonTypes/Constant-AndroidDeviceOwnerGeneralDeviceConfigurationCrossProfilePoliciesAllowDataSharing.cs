// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AndroidDeviceOwnerGeneralDeviceConfigurationCrossProfilePoliciesAllowDataSharingConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("CrossProfileDataSharingBlocked")]
    @crossProfileDataSharingBlocked,

    [Description("DataSharingFromWorkToPersonalBlocked")]
    @dataSharingFromWorkToPersonalBlocked,

    [Description("CrossProfileDataSharingAllowed")]
    @crossProfileDataSharingAllowed,

    [Description("UnkownFutureValue")]
    @unkownFutureValue,
}
