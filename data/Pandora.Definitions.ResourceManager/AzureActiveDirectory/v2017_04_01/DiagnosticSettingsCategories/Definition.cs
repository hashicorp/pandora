using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01.DiagnosticSettingsCategories;

internal class Definition : ResourceDefinition
{
    public string Name => "DiagnosticSettingsCategories";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DiagnosticSettingsCategoryListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CategoryTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiagnosticSettingsCategoryModel),
        typeof(DiagnosticSettingsCategoryResourceModel),
        typeof(DiagnosticSettingsCategoryResourceCollectionModel),
    };
}
