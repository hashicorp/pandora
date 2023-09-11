using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.NamedValue;

internal class Definition : ResourceDefinition
{
    public string Name => "NamedValue";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new ListValueOperation(),
        new RefreshSecretOperation(),
        new UpdateOperation(),
        new WorkspaceNamedValueCreateOrUpdateOperation(),
        new WorkspaceNamedValueDeleteOperation(),
        new WorkspaceNamedValueGetOperation(),
        new WorkspaceNamedValueGetEntityTagOperation(),
        new WorkspaceNamedValueListByServiceOperation(),
        new WorkspaceNamedValueListValueOperation(),
        new WorkspaceNamedValueRefreshSecretOperation(),
        new WorkspaceNamedValueUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(KeyVaultRefreshStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(KeyVaultContractCreatePropertiesModel),
        typeof(KeyVaultContractPropertiesModel),
        typeof(KeyVaultLastAccessStatusContractPropertiesModel),
        typeof(NamedValueContractModel),
        typeof(NamedValueContractPropertiesModel),
        typeof(NamedValueCreateContractModel),
        typeof(NamedValueCreateContractPropertiesModel),
        typeof(NamedValueSecretContractModel),
        typeof(NamedValueUpdateParameterPropertiesModel),
        typeof(NamedValueUpdateParametersModel),
    };
}
