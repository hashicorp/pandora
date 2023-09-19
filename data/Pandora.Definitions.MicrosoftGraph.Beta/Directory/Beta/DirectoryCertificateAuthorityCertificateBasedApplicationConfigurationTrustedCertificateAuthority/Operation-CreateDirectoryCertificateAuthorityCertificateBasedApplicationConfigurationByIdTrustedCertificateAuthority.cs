// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryCertificateAuthorityCertificateBasedApplicationConfigurationTrustedCertificateAuthority;

internal class CreateDirectoryCertificateAuthorityCertificateBasedApplicationConfigurationByIdTrustedCertificateAuthorityOperation : Operations.PostOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override Type? RequestObject() => typeof(CertificateAuthorityAsEntityModel);
    public override ResourceID? ResourceId() => new DirectoryCertificateAuthorityCertificateBasedApplicationConfigurationId();
    public override Type? ResponseObject() => typeof(CertificateAuthorityAsEntityModel);
    public override string? UriSuffix() => "/trustedCertificateAuthorities";
}
