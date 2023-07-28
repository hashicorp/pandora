using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.FeaturesetVersion;

internal class ListMaterializationJobsOperation : Pandora.Definitions.Operations.ListOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new FeaturesetVersionId();

    public override Type NestedItemType() => typeof(FeaturesetJobModel);

    public override Type? OptionsObject() => typeof(ListMaterializationJobsOperation.ListMaterializationJobsOptions);

    public override string? UriSuffix() => "/listMaterializationJobs";

    public override System.Net.Http.HttpMethod Method() => System.Net.Http.HttpMethod.Post;

    internal class ListMaterializationJobsOptions
    {
        [QueryStringName("featureWindowEnd")]
        [Optional]
        public string FeatureWindowEnd { get; set; }

        [QueryStringName("featureWindowStart")]
        [Optional]
        public string FeatureWindowStart { get; set; }

        [QueryStringName("filters")]
        [Optional]
        public string Filters { get; set; }

        [QueryStringName("$skip")]
        [Optional]
        public string Skip { get; set; }
    }
}
