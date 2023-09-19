// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDeviceAssignmentFilterEvaluationStatusDetail;

internal class UserIdManagedDeviceIdAssignmentFilterEvaluationStatusDetailId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/managedDevices/{managedDeviceId}/assignmentFilterEvaluationStatusDetails/{assignmentFilterEvaluationStatusDetailsId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticManagedDevices", "managedDevices"),
        ResourceIDSegment.UserSpecified("managedDeviceId"),
        ResourceIDSegment.Static("staticAssignmentFilterEvaluationStatusDetails", "assignmentFilterEvaluationStatusDetails"),
        ResourceIDSegment.UserSpecified("assignmentFilterEvaluationStatusDetailsId")
    };
}
