using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_07_07.Databases;

internal class Definition : ResourceDefinition
{
    public string Name => "Databases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AddPrincipalsOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByClusterOperation(),
        new ListPrincipalsOperation(),
        new RemovePrincipalsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CallerRoleConstant),
        typeof(DatabasePrincipalRoleConstant),
        typeof(DatabasePrincipalTypeConstant),
        typeof(DatabaseShareOriginConstant),
        typeof(KindConstant),
        typeof(PrincipalsModificationKindConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReasonConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameRequestModel),
        typeof(CheckNameResultModel),
        typeof(DatabaseModel),
        typeof(DatabaseListResultModel),
        typeof(DatabasePrincipalModel),
        typeof(DatabasePrincipalListRequestModel),
        typeof(DatabasePrincipalListResultModel),
        typeof(DatabaseStatisticsModel),
        typeof(ReadOnlyFollowingDatabaseModel),
        typeof(ReadOnlyFollowingDatabasePropertiesModel),
        typeof(ReadWriteDatabaseModel),
        typeof(ReadWriteDatabasePropertiesModel),
        typeof(TableLevelSharingPropertiesModel),
    };
}
