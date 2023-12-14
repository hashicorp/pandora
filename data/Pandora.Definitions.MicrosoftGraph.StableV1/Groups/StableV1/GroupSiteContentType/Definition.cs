// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupSiteContentType;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteContentType";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddGroupByIdSiteByIdContentTypesCopyFromContentTypeHubOperation(),
        new AddGroupByIdSiteByIdContentTypesCopyOperation(),
        new CreateGroupByIdSiteByIdContentTypeByIdAssociateWithHubSiteOperation(),
        new CreateGroupByIdSiteByIdContentTypeByIdCopyToDefaultContentLocationOperation(),
        new CreateGroupByIdSiteByIdContentTypeByIdPublishOperation(),
        new CreateGroupByIdSiteByIdContentTypeByIdUnpublishOperation(),
        new CreateGroupByIdSiteByIdContentTypeOperation(),
        new DeleteGroupByIdSiteByIdContentTypeByIdOperation(),
        new GetGroupByIdSiteByIdContentTypeByIdOperation(),
        new GetGroupByIdSiteByIdContentTypeCountOperation(),
        new ListGroupByIdSiteByIdContentTypesOperation(),
        new UpdateGroupByIdSiteByIdContentTypeByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddGroupByIdSiteByIdContentTypesCopyFromContentTypeHubRequestModel),
        typeof(AddGroupByIdSiteByIdContentTypesCopyRequestModel),
        typeof(CreateGroupByIdSiteByIdContentTypeByIdAssociateWithHubSiteRequestModel),
        typeof(CreateGroupByIdSiteByIdContentTypeByIdCopyToDefaultContentLocationRequestModel)
    };
}
