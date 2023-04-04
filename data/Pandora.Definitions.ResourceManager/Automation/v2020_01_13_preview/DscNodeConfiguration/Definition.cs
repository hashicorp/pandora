using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.DscNodeConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "DscNodeConfiguration";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByAutomationAccountOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ContentSourceTypeConstant),
        typeof(CountTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ContentHashModel),
        typeof(ContentSourceModel),
        typeof(DscConfigurationAssociationPropertyModel),
        typeof(DscNodeConfigurationModel),
        typeof(DscNodeConfigurationCreateOrUpdateParametersModel),
        typeof(DscNodeConfigurationCreateOrUpdateParametersPropertiesModel),
        typeof(DscNodeConfigurationPropertiesModel),
    };
}
