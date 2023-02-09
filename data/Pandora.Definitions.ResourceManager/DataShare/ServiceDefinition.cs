using Pandora.Definitions.Interfaces;
using System.Collections.Generic;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare;

public partial class Service : ServiceDefinition
{
    public string Name => "DataShare";
    public string? ResourceProvider => "Microsoft.DataShare";
    public string? TerraformPackageName => null;

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {

    };
}
