using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.BackupInstances;

internal class TriggerCrossRegionRestoreOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(CrossRegionRestoreRequestObjectModel);

    public override ResourceID? ResourceId() => new ProviderLocationId();

    public override Type? ResponseObject() => typeof(OperationJobExtendedInfoModel);

    public override string? UriSuffix() => "/crossRegionRestore";


}
