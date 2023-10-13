// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryDeletedItem;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryDeletedItem";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckDirectoryDeletedItemByIdMemberGroupOperation(),
        new CheckDirectoryDeletedItemByIdMemberObjectOperation(),
        new GetDirectoryDeletedItemByIdMemberGroupOperation(),
        new GetDirectoryDeletedItemByIdMemberObjectOperation(),
        new GetDirectoryDeletedItemByIdOperation(),
        new GetDirectoryDeletedItemCountOperation(),
        new GetDirectoryDeletedItemsByIdsOperation(),
        new ListDirectoryDeletedItemsOperation(),
        new RestoreDirectoryDeletedItemByIdOperation(),
        new ValidateDirectoryDeletedItemsPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckDirectoryDeletedItemByIdMemberGroupRequestModel),
        typeof(CheckDirectoryDeletedItemByIdMemberObjectRequestModel),
        typeof(GetDirectoryDeletedItemByIdMemberGroupRequestModel),
        typeof(GetDirectoryDeletedItemByIdMemberObjectRequestModel),
        typeof(GetDirectoryDeletedItemsByIdsRequestModel),
        typeof(ValidateDirectoryDeletedItemsPropertyRequestModel)
    };
}
