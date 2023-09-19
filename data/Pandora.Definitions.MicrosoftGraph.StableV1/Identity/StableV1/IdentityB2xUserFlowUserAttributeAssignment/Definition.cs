// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Identity.StableV1.IdentityB2xUserFlowUserAttributeAssignment;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityB2xUserFlowUserAttributeAssignment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityB2xUserFlowByIdUserAttributeAssignmentOperation(),
        new DeleteIdentityB2xUserFlowByIdUserAttributeAssignmentByIdOperation(),
        new GetIdentityB2xUserFlowByIdUserAttributeAssignmentByIdOperation(),
        new GetIdentityB2xUserFlowByIdUserAttributeAssignmentCountOperation(),
        new ListIdentityB2xUserFlowByIdUserAttributeAssignmentsOperation(),
        new SetIdentityB2xUserFlowByIdUserAttributeAssignmentsOrderOperation(),
        new UpdateIdentityB2xUserFlowByIdUserAttributeAssignmentByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SetIdentityB2xUserFlowByIdUserAttributeAssignmentsOrderRequestModel)
    };
}
