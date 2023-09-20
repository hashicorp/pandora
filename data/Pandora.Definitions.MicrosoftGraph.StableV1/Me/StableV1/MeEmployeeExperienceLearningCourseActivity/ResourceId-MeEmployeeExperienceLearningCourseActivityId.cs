// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Me.StableV1.MeEmployeeExperienceLearningCourseActivity;

internal class MeEmployeeExperienceLearningCourseActivityId : ResourceID
{
    public string? CommonAlias => null;
    public string ID => "/me/employeeExperience/learningCourseActivities/{learningCourseActivityId}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticMe", "me"),
        ResourceIDSegment.Static("staticEmployeeExperience", "employeeExperience"),
        ResourceIDSegment.Static("staticLearningCourseActivities", "learningCourseActivities"),
        ResourceIDSegment.UserSpecified("learningCourseActivityId")
    };
}
