using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AutoManage;

public partial class Service : ServiceDefinition
{
    public string Name => "AutoManage";
    public string? ResourceProvider => "Microsoft.Automanage";
    public string? TerraformPackageName => null;

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {

    };
}
