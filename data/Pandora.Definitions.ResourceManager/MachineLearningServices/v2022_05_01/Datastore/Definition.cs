using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2022_05_01.Datastore;

internal class Definition : ResourceDefinition
{
    public string Name => "Datastore";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListSecretsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CredentialsTypeConstant),
        typeof(DatastoreTypeConstant),
        typeof(SecretsTypeConstant),
        typeof(ServiceDataAccessAuthIdentityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccountKeyDatastoreCredentialsModel),
        typeof(AccountKeyDatastoreSecretsModel),
        typeof(AzureBlobDatastoreModel),
        typeof(AzureDataLakeGen1DatastoreModel),
        typeof(AzureDataLakeGen2DatastoreModel),
        typeof(AzureFileDatastoreModel),
        typeof(CertificateDatastoreCredentialsModel),
        typeof(CertificateDatastoreSecretsModel),
        typeof(DatastoreModel),
        typeof(DatastoreCredentialsModel),
        typeof(DatastoreResourceModel),
        typeof(DatastoreSecretsModel),
        typeof(NoneDatastoreCredentialsModel),
        typeof(SasDatastoreCredentialsModel),
        typeof(SasDatastoreSecretsModel),
        typeof(ServicePrincipalDatastoreCredentialsModel),
        typeof(ServicePrincipalDatastoreSecretsModel),
    };
}
