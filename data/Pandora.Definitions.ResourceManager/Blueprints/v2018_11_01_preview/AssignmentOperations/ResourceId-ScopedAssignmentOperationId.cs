using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Blueprints.v2018_11_01_preview.AssignmentOperations;

internal class ScopedAssignmentOperationId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/{resourceScope}/providers/Microsoft.Blueprint/blueprintAssignments/{blueprintAssignmentName}/assignmentOperations/{assignmentOperationName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Scope("resourceScope"),
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftBlueprint", "Microsoft.Blueprint"),
        ResourceIDSegment.Static("staticBlueprintAssignments", "blueprintAssignments"),
        ResourceIDSegment.UserSpecified("blueprintAssignmentName"),
        ResourceIDSegment.Static("staticAssignmentOperations", "assignmentOperations"),
        ResourceIDSegment.UserSpecified("assignmentOperationName"),
    };
}
