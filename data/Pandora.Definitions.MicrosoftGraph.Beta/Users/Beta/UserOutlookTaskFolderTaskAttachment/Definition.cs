// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserOutlookTaskFolderTaskAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserOutlookTaskFolderTaskAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdOutlookTaskFolderByIdTaskByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdOutlookTaskFolderByIdTaskByIdAttachmentOperation(),
        new DeleteUserByIdOutlookTaskFolderByIdTaskByIdAttachmentByIdOperation(),
        new GetUserByIdOutlookTaskFolderByIdTaskByIdAttachmentByIdOperation(),
        new GetUserByIdOutlookTaskFolderByIdTaskByIdAttachmentCountOperation(),
        new ListUserByIdOutlookTaskFolderByIdTaskByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdOutlookTaskFolderByIdTaskByIdAttachmentCreateUploadSessionRequestModel)
    };
}
