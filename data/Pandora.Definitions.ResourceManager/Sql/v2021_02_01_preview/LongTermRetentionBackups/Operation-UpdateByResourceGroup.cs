using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LongTermRetentionBackups;

internal class UpdateByResourceGroupOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(UpdateLongTermRetentionBackupParametersModel);

    public override ResourceID? ResourceId() => new LongTermRetentionDatabaseLongTermRetentionBackupId();

    public override Type? ResponseObject() => typeof(LongTermRetentionBackupOperationResultModel);

    public override string? UriSuffix() => "/update";


}
