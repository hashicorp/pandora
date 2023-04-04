using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_12_29.AttachedDatabaseConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "AttachedDatabaseConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByClusterOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AttachedDatabaseTypeConstant),
        typeof(DefaultPrincipalsModificationKindConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AttachedDatabaseConfigurationModel),
        typeof(AttachedDatabaseConfigurationListResultModel),
        typeof(AttachedDatabaseConfigurationPropertiesModel),
        typeof(AttachedDatabaseConfigurationsCheckNameRequestModel),
        typeof(CheckNameResultModel),
        typeof(TableLevelSharingPropertiesModel),
    };
}
