using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedDatabaseSensitivityLabels;

internal class ManagedDatabaseRecommendedSensitivityLabelsUpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(RecommendedSensitivityLabelUpdateListModel);

    public override ResourceID? ResourceId() => new ManagedInstanceDatabaseId();

    public override string? UriSuffix() => "/recommendedSensitivityLabels";


}
