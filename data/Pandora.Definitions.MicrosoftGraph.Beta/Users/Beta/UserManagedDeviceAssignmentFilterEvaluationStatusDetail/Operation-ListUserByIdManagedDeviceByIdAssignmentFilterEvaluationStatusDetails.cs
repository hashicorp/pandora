// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDeviceAssignmentFilterEvaluationStatusDetail;

internal class ListUserByIdManagedDeviceByIdAssignmentFilterEvaluationStatusDetailsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdManagedDeviceId();
    public override Type NestedItemType() => typeof(AssignmentFilterEvaluationStatusDetailsCollectionResponseModel);
    public override string? UriSuffix() => "/assignmentFilterEvaluationStatusDetails";
}
