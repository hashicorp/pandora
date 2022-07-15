using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources;

public partial class Service : ServiceDefinition
{
    /*
     * @tombuildsstuff: `Resources` is temporarily disabled for import since we're using it to
     * scaffold our Terraform Data Sources/Resources - if you need an update of this Service
     * please reach out.
     */
    public string Name => "Resources";
    public string? ResourceProvider => "Microsoft.Authorization";
    public string? TerraformPackageName => "resources";
}
