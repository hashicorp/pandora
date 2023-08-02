using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Provider;

internal class Definition : ResourceDefinition
{
    public string Name => "Provider";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetAvailableStacksOperation(),
        new GetAvailableStacksOnPremOperation(),
        new GetFunctionAppStacksOperation(),
        new GetFunctionAppStacksForLocationOperation(),
        new GetWebAppStacksOperation(),
        new GetWebAppStacksForLocationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProviderOsTypeSelectedConstant),
        typeof(ProviderStackOsTypeConstant),
        typeof(StackPreferredOsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppInsightsWebAppStackSettingsModel),
        typeof(ApplicationStackModel),
        typeof(ApplicationStackResourceModel),
        typeof(FunctionAppMajorVersionModel),
        typeof(FunctionAppMinorVersionModel),
        typeof(FunctionAppRuntimeSettingsModel),
        typeof(FunctionAppRuntimesModel),
        typeof(FunctionAppStackModel),
        typeof(FunctionAppStackPropertiesModel),
        typeof(GitHubActionWebAppStackSettingsModel),
        typeof(LinuxJavaContainerSettingsModel),
        typeof(SiteConfigPropertiesDictionaryModel),
        typeof(StackMajorVersionModel),
        typeof(StackMinorVersionModel),
        typeof(WebAppMajorVersionModel),
        typeof(WebAppMinorVersionModel),
        typeof(WebAppRuntimeSettingsModel),
        typeof(WebAppRuntimesModel),
        typeof(WebAppStackModel),
        typeof(WebAppStackPropertiesModel),
        typeof(WindowsJavaContainerSettingsModel),
    };
}
