using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.Certificate;

internal class Definition : ResourceDefinition
{
    public string Name => "Certificate";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelDeletionOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByBatchAccountOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CertificateFormatConstant),
        typeof(CertificateProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CertificateModel),
        typeof(CertificateCreateOrUpdateParametersModel),
        typeof(CertificateCreateOrUpdatePropertiesModel),
        typeof(CertificatePropertiesModel),
        typeof(DeleteCertificateErrorModel),
    };
}
