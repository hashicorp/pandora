// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupOnenoteSectionGroupSection;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupOnenoteSectionGroupSection";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdOnenoteSectionGroupByIdSectionByIdCopyToNotebookOperation(),
        new CreateGroupByIdOnenoteSectionGroupByIdSectionByIdCopyToSectionGroupOperation(),
        new CreateGroupByIdOnenoteSectionGroupByIdSectionOperation(),
        new DeleteGroupByIdOnenoteSectionGroupByIdSectionByIdOperation(),
        new GetGroupByIdOnenoteSectionGroupByIdSectionByIdOperation(),
        new GetGroupByIdOnenoteSectionGroupByIdSectionCountOperation(),
        new ListGroupByIdOnenoteSectionGroupByIdSectionsOperation(),
        new UpdateGroupByIdOnenoteSectionGroupByIdSectionByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdOnenoteSectionGroupByIdSectionByIdCopyToNotebookRequestModel),
        typeof(CreateGroupByIdOnenoteSectionGroupByIdSectionByIdCopyToSectionGroupRequestModel)
    };
}
