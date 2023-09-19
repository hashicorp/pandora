// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDeviceAssignmentFilterEvaluationStatusDetail;

internal class Definition : ResourceDefinition
{
    public string Name => "MeManagedDeviceAssignmentFilterEvaluationStatusDetail";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeManagedDeviceByIdAssignmentFilterEvaluationStatusDetailOperation(),
        new DeleteMeManagedDeviceByIdAssignmentFilterEvaluationStatusDetailByIdOperation(),
        new GetMeManagedDeviceByIdAssignmentFilterEvaluationStatusDetailByIdOperation(),
        new GetMeManagedDeviceByIdAssignmentFilterEvaluationStatusDetailCountOperation(),
        new ListMeManagedDeviceByIdAssignmentFilterEvaluationStatusDetailsOperation(),
        new UpdateMeManagedDeviceByIdAssignmentFilterEvaluationStatusDetailByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
