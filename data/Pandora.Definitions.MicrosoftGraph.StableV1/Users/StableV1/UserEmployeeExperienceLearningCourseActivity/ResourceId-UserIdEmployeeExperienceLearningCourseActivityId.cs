// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserEmployeeExperienceLearningCourseActivity;

internal class UserIdEmployeeExperienceLearningCourseActivityId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/users/{userId}/employeeExperience/learningCourseActivities/{learningCourseActivityId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticUsers", "users"),
        ResourceIDSegment.UserSpecified("userId"),
        ResourceIDSegment.Static("staticEmployeeExperience", "employeeExperience"),
        ResourceIDSegment.Static("staticLearningCourseActivities", "learningCourseActivities"),
        ResourceIDSegment.UserSpecified("learningCourseActivityId")
    };
}
