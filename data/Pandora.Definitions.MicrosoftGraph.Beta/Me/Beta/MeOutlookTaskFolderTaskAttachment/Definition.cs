// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskFolderTaskAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "MeOutlookTaskFolderTaskAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeOutlookTaskFolderByIdTaskByIdAttachmentCreateUploadSessionOperation(),
        new CreateMeOutlookTaskFolderByIdTaskByIdAttachmentOperation(),
        new DeleteMeOutlookTaskFolderByIdTaskByIdAttachmentByIdOperation(),
        new GetMeOutlookTaskFolderByIdTaskByIdAttachmentByIdOperation(),
        new GetMeOutlookTaskFolderByIdTaskByIdAttachmentCountOperation(),
        new ListMeOutlookTaskFolderByIdTaskByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeOutlookTaskFolderByIdTaskByIdAttachmentCreateUploadSessionRequestModel)
    };
}
