using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Repositories;

internal class SourceControllistRepositoriesOperation : Pandora.Definitions.Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(RepoTypeConstant);

    public override ResourceID? ResourceId() => new WorkspaceId();

    public override Type NestedItemType() => typeof(RepoModel);

    public override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/listRepositories";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
