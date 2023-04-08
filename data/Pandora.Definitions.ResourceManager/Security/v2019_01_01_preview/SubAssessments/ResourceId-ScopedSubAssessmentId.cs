using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01_preview.SubAssessments;

internal class ScopedSubAssessmentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{scope}/providers/Microsoft.Security/assessments/{assessmentName}/subAssessments/{subAssessmentName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("scope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSecurity", "Microsoft.Security"),
        ResourceIDSegment.Static("staticAssessments", "assessments"),
        ResourceIDSegment.UserSpecified("assessmentName"),
        ResourceIDSegment.Static("staticSubAssessments", "subAssessments"),
        ResourceIDSegment.UserSpecified("subAssessmentName"),
    };
}
