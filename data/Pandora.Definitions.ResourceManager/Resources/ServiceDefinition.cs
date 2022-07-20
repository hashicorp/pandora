using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources;

public partial class Service : ServiceDefinition
{
    public string Name => "Resources";
    public string? ResourceProvider => "Microsoft.Authorization";
    public string? TerraformPackageName => "resource";

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
        new Terraform.ResourceGroupResource(),
    };
}
