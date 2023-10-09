// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Invitations.Beta.InvitationInvitedUserServiceProvisioningError;

internal class ListInvitationByIdInvitedUserServiceProvisioningErrorsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new InvitationId();
    public override Type NestedItemType() => typeof(ServiceProvisioningErrorCollectionResponseModel);
    public override string? UriSuffix() => "/invitedUser/serviceProvisioningErrors";
}
