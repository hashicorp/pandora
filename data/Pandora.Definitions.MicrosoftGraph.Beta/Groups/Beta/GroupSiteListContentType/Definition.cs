// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteListContentType;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupSiteListContentType";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddGroupByIdSiteByIdListByIdContentTypesCopyFromContentTypeHubOperation(),
        new AddGroupByIdSiteByIdListByIdContentTypesCopyOperation(),
        new CreateGroupByIdSiteByIdListByIdContentTypeByIdAssociateWithHubSiteOperation(),
        new CreateGroupByIdSiteByIdListByIdContentTypeByIdCopyToDefaultContentLocationOperation(),
        new CreateGroupByIdSiteByIdListByIdContentTypeByIdPublishOperation(),
        new CreateGroupByIdSiteByIdListByIdContentTypeByIdUnpublishOperation(),
        new CreateGroupByIdSiteByIdListByIdContentTypeOperation(),
        new DeleteGroupByIdSiteByIdListByIdContentTypeByIdOperation(),
        new GetGroupByIdSiteByIdListByIdContentTypeByIdOperation(),
        new GetGroupByIdSiteByIdListByIdContentTypeCountOperation(),
        new ListGroupByIdSiteByIdListByIdContentTypesOperation(),
        new UpdateGroupByIdSiteByIdListByIdContentTypeByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddGroupByIdSiteByIdListByIdContentTypesCopyFromContentTypeHubRequestModel),
        typeof(AddGroupByIdSiteByIdListByIdContentTypesCopyRequestModel),
        typeof(CreateGroupByIdSiteByIdListByIdContentTypeByIdAssociateWithHubSiteRequestModel),
        typeof(CreateGroupByIdSiteByIdListByIdContentTypeByIdCopyToDefaultContentLocationRequestModel)
    };
}
