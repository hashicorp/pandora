// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagementAgentTypeConstant
{
    [Description("Eas")]
    @eas,

    [Description("Mdm")]
    @mdm,

    [Description("EasMdm")]
    @easMdm,

    [Description("IntuneClient")]
    @intuneClient,

    [Description("EasIntuneClient")]
    @easIntuneClient,

    [Description("ConfigurationManagerClient")]
    @configurationManagerClient,

    [Description("ConfigurationManagerClientMdm")]
    @configurationManagerClientMdm,

    [Description("ConfigurationManagerClientMdmEas")]
    @configurationManagerClientMdmEas,

    [Description("Unknown")]
    @unknown,

    [Description("Jamf")]
    @jamf,

    [Description("GoogleCloudDevicePolicyController")]
    @googleCloudDevicePolicyController,

    [Description("Microsoft365ManagedMdm")]
    @microsoft365ManagedMdm,

    [Description("MsSense")]
    @msSense,

    [Description("IntuneAosp")]
    @intuneAosp,
}
