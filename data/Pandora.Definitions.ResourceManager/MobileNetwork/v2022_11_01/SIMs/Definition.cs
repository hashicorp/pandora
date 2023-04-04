using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIMs;

internal class Definition : ResourceDefinition
{
    public string Name => "SIMs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BulkDeleteOperation(),
        new BulkUploadOperation(),
        new BulkUploadEncryptedOperation(),
        new ListByGroupOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(SimStateConstant),
        typeof(SiteProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsyncOperationStatusModel),
        typeof(AttachedDataNetworkResourceIdModel),
        typeof(EncryptedSimPropertiesFormatModel),
        typeof(EncryptedSimUploadListModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(SimModel),
        typeof(SimDeleteListModel),
        typeof(SimNameAndEncryptedPropertiesModel),
        typeof(SimNameAndPropertiesModel),
        typeof(SimPolicyResourceIdModel),
        typeof(SimPropertiesFormatModel),
        typeof(SimStaticIPPropertiesModel),
        typeof(SimStaticIPPropertiesStaticIPModel),
        typeof(SimUploadListModel),
        typeof(SliceResourceIdModel),
    };
}
