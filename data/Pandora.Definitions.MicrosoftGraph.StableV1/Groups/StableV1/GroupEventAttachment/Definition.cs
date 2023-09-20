// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Groups.StableV1.GroupEventAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "GroupEventAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateGroupByIdEventByIdAttachmentCreateUploadSessionOperation(),
        new CreateGroupByIdEventByIdAttachmentOperation(),
        new DeleteGroupByIdEventByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdAttachmentByIdOperation(),
        new GetGroupByIdEventByIdAttachmentCountOperation(),
        new ListGroupByIdEventByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateGroupByIdEventByIdAttachmentCreateUploadSessionRequestModel)
    };
}
