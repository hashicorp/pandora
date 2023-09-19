// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta.DomainVerificationDnsRecord;

internal class ListDomainByIdVerificationDnsRecordsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new DomainId();
    public override Type NestedItemType() => typeof(DomainDnsRecordCollectionResponseModel);
    public override string? UriSuffix() => "/verificationDnsRecords";
}
