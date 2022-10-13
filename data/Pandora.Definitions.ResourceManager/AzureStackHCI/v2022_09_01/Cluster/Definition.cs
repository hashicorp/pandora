using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_09_01.Cluster;

internal class Definition : ResourceDefinition
{
    public string Name => "Cluster";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIdentityOperation(),
        new ExtendSoftwareAssuranceBenefitOperation(),
        new UploadCertificateOperation(),
    };
}
