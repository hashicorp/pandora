// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupOnenoteSection;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteSectionByIdCopyToNotebookOperation(),
        new CreateGroupByIdOnenoteSectionByIdCopyToSectionGroupOperation(),
        new CreateGroupByIdOnenoteSectionOperation(),
        new DeleteGroupByIdOnenoteSectionByIdOperation(),
        new GetGroupByIdOnenoteSectionByIdOperation(),
        new GetGroupByIdOnenoteSectionCountOperation(),
        new ListGroupByIdOnenoteSectionsOperation(),
        new UpdateGroupByIdOnenoteSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteSectionByIdCopyToNotebookRequestModel),
        typeof(CreateGroupByIdOnenoteSectionByIdCopyToSectionGroupRequestModel)
    };
}
