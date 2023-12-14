// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeMailFolderMessageAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeMailFolderMessageAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeMailFolderByIdMessageByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeMailFolderByIdMessageByIdAttachmentOperation(),
        new DeleteMeMailFolderByIdMessageByIdAttachmentByIdOperation(),
        new GetMeMailFolderByIdMessageByIdAttachmentByIdOperation(),
        new GetMeMailFolderByIdMessageByIdAttachmentCountOperation(),
        new ListMeMailFolderByIdMessageByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeMailFolderByIdMessageByIdAttachmentCreateUploadSessionRequestModel)
    };
}
