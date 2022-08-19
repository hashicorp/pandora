using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute;

public partial class Service : ServiceDefinition
{
    public string Name => "Compute";
    public string? ResourceProvider => "Microsoft.Compute";
    public string? TerraformPackageName => "compute";

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {

    };
}
