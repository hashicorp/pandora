// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserContactFolderChildFolderContact;

internal class ListUserByIdContactFolderByIdChildFolderByIdContactsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdContactFolderIdChildFolderId();
    public override Type NestedItemType() => typeof(ContactCollectionResponseModel);
    public override string? UriSuffix() => "/contacts";
}
