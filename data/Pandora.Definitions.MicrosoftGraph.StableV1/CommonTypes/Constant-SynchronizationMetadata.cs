// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SynchronizationMetadataConstant
{
    [Description("GalleryApplicationIdentifier")]
    @GalleryApplicationIdentifier,

    [Description("GalleryApplicationKey")]
    @GalleryApplicationKey,

    [Description("IsOAuthEnabled")]
    @IsOAuthEnabled,

    [Description("IsSynchronizationAgentAssignmentRequired")]
    @IsSynchronizationAgentAssignmentRequired,

    [Description("IsSynchronizationAgentRequired")]
    @IsSynchronizationAgentRequired,

    [Description("IsSynchronizationInPreview")]
    @IsSynchronizationInPreview,

    [Description("OAuthSettings")]
    @OAuthSettings,

    [Description("SynchronizationLearnMoreIbizaFwLink")]
    @SynchronizationLearnMoreIbizaFwLink,

    [Description("ConfigurationFields")]
    @ConfigurationFields,
}
