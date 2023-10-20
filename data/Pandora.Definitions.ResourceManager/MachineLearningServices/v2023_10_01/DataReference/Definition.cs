using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_10_01.DataReference;

internal class Definition : ResourceDefinition
{
    public string Name => "DataReference";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RegistryDataReferencesGetBlobReferenceSASOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataReferenceCredentialTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AnonymousAccessCredentialModel),
        typeof(DataReferenceCredentialModel),
        typeof(DockerCredentialModel),
        typeof(GetBlobReferenceForConsumptionDtoModel),
        typeof(GetBlobReferenceSASRequestDtoModel),
        typeof(GetBlobReferenceSASResponseDtoModel),
        typeof(ManagedIdentityCredentialModel),
        typeof(SASCredentialModel),
    };
}
