using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement;

public partial class Service : ServiceDefinition
{
    public string Name => "CostManagement";
    public string? ResourceProvider => "Microsoft.CostManagement";
    public string? TerraformPackageName => "costmanagement";
}
