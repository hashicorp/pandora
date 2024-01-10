// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System.Collections.Generic;
using System.Net;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Domains.StableV1.DomainServiceConfigurationRecord;

internal class GetDomainByIdServiceConfigurationRecordByIdOperation : Operations.GetOperation
{

    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
            HttpStatusCode.OK,
        };
    public override ResourceID? ResourceId() => new DomainIdServiceConfigurationRecordId();
    public override Type? ResponseObject() => typeof(DomainDnsRecordModel);
    public override string? UriSuffix() => null;
}
