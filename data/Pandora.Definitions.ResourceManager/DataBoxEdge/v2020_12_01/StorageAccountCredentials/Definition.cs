using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.StorageAccountCredentials;

internal class Definition : ResourceDefinition
{
    public string Name => "StorageAccountCredentials";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDataBoxEdgeDeviceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccountTypeConstant),
        typeof(EncryptionAlgorithmConstant),
        typeof(SSLStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsymmetricEncryptedSecretModel),
        typeof(StorageAccountCredentialModel),
        typeof(StorageAccountCredentialPropertiesModel),
    };
}
