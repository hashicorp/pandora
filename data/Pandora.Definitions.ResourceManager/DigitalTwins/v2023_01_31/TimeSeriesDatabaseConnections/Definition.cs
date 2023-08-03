using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31.TimeSeriesDatabaseConnections;

internal class Definition : ResourceDefinition
{
    public string Name => "TimeSeriesDatabaseConnections";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CleanupConnectionArtifactsConstant),
        typeof(ConnectionTypeConstant),
        typeof(IdentityTypeConstant),
        typeof(TimeSeriesDatabaseConnectionStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureDataExplorerConnectionPropertiesModel),
        typeof(ManagedIdentityReferenceModel),
        typeof(TimeSeriesDatabaseConnectionModel),
        typeof(TimeSeriesDatabaseConnectionPropertiesModel),
    };
}
