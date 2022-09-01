using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MariaDB.v2018_06_01.RecommendedActionSessions;

internal class CreateRecommendedActionSessionOperation : Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new AdvisorId();

    public override Type? OptionsObject() => typeof(CreateRecommendedActionSessionOperation.CreateRecommendedActionSessionOptions);

    public override string? UriSuffix() => "/createRecommendedActionSession";

    internal class CreateRecommendedActionSessionOptions
    {
        [QueryStringName("databaseName")]
        public string DatabaseName { get; set; }
    }
}
