using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.DpsCertificate;

internal class Definition : ResourceDefinition
{
    public string Name => "DpsCertificate";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GenerateVerificationCodeOperation(),
        new GetOperation(),
        new ListOperation(),
        new VerifyCertificateOperation(),
    };
}
