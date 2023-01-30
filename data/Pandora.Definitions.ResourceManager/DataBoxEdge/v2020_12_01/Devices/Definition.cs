using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Devices;

internal class Definition : ResourceDefinition
{
    public string Name => "Devices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateSecuritySettingsOperation(),
        new DeleteOperation(),
        new DownloadUpdatesOperation(),
        new GenerateCertificateOperation(),
        new GetOperation(),
        new GetExtendedInformationOperation(),
        new GetNetworkSettingsOperation(),
        new GetUpdateSummaryOperation(),
        new InstallUpdatesOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ScanForUpdatesOperation(),
        new UpdateOperation(),
        new UpdateExtendedInformationOperation(),
        new UploadCertificateOperation(),
    };
}
