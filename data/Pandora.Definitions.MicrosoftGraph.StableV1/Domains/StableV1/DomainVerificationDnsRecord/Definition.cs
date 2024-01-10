// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Domains.StableV1.DomainVerificationDnsRecord;

internal class Definition : ResourceDefinition
{
    public string Name => "DomainVerificationDnsRecord";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDomainByIdVerificationDnsRecordOperation(),
        new DeleteDomainByIdVerificationDnsRecordByIdOperation(),
        new GetDomainByIdVerificationDnsRecordByIdOperation(),
        new GetDomainByIdVerificationDnsRecordCountOperation(),
        new ListDomainByIdVerificationDnsRecordsOperation(),
        new UpdateDomainByIdVerificationDnsRecordByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
