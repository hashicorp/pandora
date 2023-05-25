using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.NetworkSecurityPerimeterConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "NetworkSecurityPerimeterConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByServerOperation(),
        new ReconcileOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NSPConfigAccessRuleModel),
        typeof(NSPConfigAccessRulePropertiesModel),
        typeof(NSPConfigAssociationModel),
        typeof(NSPConfigNetworkSecurityPerimeterRuleModel),
        typeof(NSPConfigPerimeterModel),
        typeof(NSPConfigProfileModel),
        typeof(NSPProvisioningIssueModel),
        typeof(NSPProvisioningIssuePropertiesModel),
        typeof(NetworkSecurityPerimeterConfigurationModel),
        typeof(NetworkSecurityPerimeterConfigurationPropertiesModel),
    };
}
