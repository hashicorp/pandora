using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Repositories;

internal class SourceControllistRepositoriesOperation : Operations.ListOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => typeof(RepoTypeConstant);

\t\tpublic override ResourceID? ResourceId() => new WorkspaceId();

\t\tpublic override Type NestedItemType() => typeof(RepoModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.SecurityInsights/listRepositories";

\t\tpublic override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;


}
