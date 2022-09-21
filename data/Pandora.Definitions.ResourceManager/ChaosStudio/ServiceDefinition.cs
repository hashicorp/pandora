using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio;

public partial class Service : ServiceDefinition
{
    public string Name => "ChaosStudio";
    public string? ResourceProvider => "Microsoft.Chaos";
    public string? TerraformPackageName => "chaos";

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
        new Terraform.ChaosStudioExperimentResource(),
    };
}
