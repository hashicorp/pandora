// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeAppConsentRequestsForApprovalUserConsentRequest;

internal class Definition : ResourceDefinition
{
    public string Name => "MeAppConsentRequestsForApprovalUserConsentRequest";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeAppConsentRequestsForApprovalByIdUserConsentRequestOperation(),
        new DeleteMeAppConsentRequestsForApprovalByIdUserConsentRequestByIdOperation(),
        new GetMeAppConsentRequestsForApprovalByIdUserConsentRequestByIdOperation(),
        new GetMeAppConsentRequestsForApprovalByIdUserConsentRequestCountOperation(),
        new ListMeAppConsentRequestsForApprovalByIdUserConsentRequestsOperation(),
        new UpdateMeAppConsentRequestsForApprovalByIdUserConsentRequestByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
