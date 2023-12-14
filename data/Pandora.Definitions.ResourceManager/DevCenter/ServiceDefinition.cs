using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevCenter;

public partial class Service : ServiceDefinition
{
    public string Name => "DevCenter";
    public string? ResourceProvider => "Microsoft.DevCenter";
    public string? TerraformPackageName => "devcenter";

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
        new Terraform.DevCenterProjectResource(),
        new Terraform.DevCenterResource(),
    };
}
