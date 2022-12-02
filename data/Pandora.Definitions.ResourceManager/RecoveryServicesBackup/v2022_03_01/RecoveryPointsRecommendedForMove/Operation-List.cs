using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.RecoveryPointsRecommendedForMove;

internal class ListOperation : Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(ListRecoveryPointsRecommendedForMoveRequestModel);

    public override ResourceID? ResourceId() => new ProtectedItemId();

    public override Type NestedItemType() => typeof(RecoveryPointResourceModel);

    public override string? UriSuffix() => "/recoveryPointsRecommendedForMove";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
