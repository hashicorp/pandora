using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01.DiagnosticSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "DiagnosticSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CategoryConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiagnosticSettingsModel),
        typeof(DiagnosticSettingsResourceModel),
        typeof(DiagnosticSettingsResourceCollectionModel),
        typeof(LogSettingsModel),
        typeof(RetentionPolicyModel),
    };
}
