using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.FileShares;

internal class Definition : ResourceDefinition
{
    public string Name => "FileShares";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new LeaseOperation(),
        new ListOperation(),
        new RestoreOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnabledProtocolsConstant),
        typeof(LeaseDurationConstant),
        typeof(LeaseShareActionConstant),
        typeof(LeaseStateConstant),
        typeof(LeaseStatusConstant),
        typeof(RootSquashTypeConstant),
        typeof(ShareAccessTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessPolicyModel),
        typeof(DeletedShareModel),
        typeof(FileShareModel),
        typeof(FileShareItemModel),
        typeof(FileSharePropertiesModel),
        typeof(LeaseShareRequestModel),
        typeof(LeaseShareResponseModel),
        typeof(SignedIdentifierModel),
    };
}
