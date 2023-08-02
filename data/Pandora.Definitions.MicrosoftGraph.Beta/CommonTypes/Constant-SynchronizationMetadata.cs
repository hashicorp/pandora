// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SynchronizationMetadataConstant
{
    [Description("GalleryApplicationIdentifier")]
    @galleryApplicationIdentifier,

    [Description("GalleryApplicationKey")]
    @galleryApplicationKey,

    [Description("IsOAuthEnabled")]
    @isOAuthEnabled,

    [Description("IsSynchronizationAgentAssignmentRequired")]
    @IsSynchronizationAgentAssignmentRequired,

    [Description("IsSynchronizationAgentRequired")]
    @isSynchronizationAgentRequired,

    [Description("IsSynchronizationInPreview")]
    @isSynchronizationInPreview,

    [Description("OAuthSettings")]
    @oAuthSettings,

    [Description("SynchronizationLearnMoreIbizaFwLink")]
    @synchronizationLearnMoreIbizaFwLink,

    [Description("ConfigurationFields")]
    @configurationFields,
}
