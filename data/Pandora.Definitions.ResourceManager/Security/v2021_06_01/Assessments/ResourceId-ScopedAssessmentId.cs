using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.Assessments;

internal class ScopedAssessmentId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{resourceId}/providers/Microsoft.Security/assessments/{assessmentName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("resourceId"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftSecurity", "Microsoft.Security"),
        ResourceIDSegment.Static("staticAssessments", "assessments"),
        ResourceIDSegment.UserSpecified("assessmentName"),
    };
}
