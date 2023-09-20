// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryCertificateAuthorityCertificateBasedApplicationConfigurationTrustedCertificateAuthority;

internal class DirectoryCertificateAuthorityCertificateBasedApplicationConfigurationId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/directory/certificateAuthorities/certificateBasedApplicationConfigurations/{certificateBasedApplicationConfigurationId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticDirectory", "directory"),
        ResourceIDSegment.Static("staticCertificateAuthorities", "certificateAuthorities"),
        ResourceIDSegment.Static("staticCertificateBasedApplicationConfigurations", "certificateBasedApplicationConfigurations"),
        ResourceIDSegment.UserSpecified("certificateBasedApplicationConfigurationId")
    };
}
