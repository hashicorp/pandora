// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserMailFolderChildFolderMessageAttachment;

internal class Definition : ResourceDefinition
{
    public string Name => "UserMailFolderChildFolderMessageAttachment";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentCreateUploadSessionOperation(),
        new CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentOperation(),
        new DeleteUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentByIdOperation(),
        new GetUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentCountOperation(),
        new ListUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdMailFolderByIdChildFolderByIdMessageByIdAttachmentCreateUploadSessionRequestModel)
    };
}
