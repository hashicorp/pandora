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
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.OK,
        };

\t\tpublic override bool LongRunning() => true;

\t\tpublic override Type? RequestObject() => null;

\t\tpublic override ResourceID? ResourceId() => new AdvisorId();

\t\tpublic override Type? OptionsObject() => typeof(CreateRecommendedActionSessionOperation.CreateRecommendedActionSessionOptions);

\t\tpublic override string? UriSuffix() => "/createRecommendedActionSession";

    internal class CreateRecommendedActionSessionOptions
    {
        [QueryStringName("databaseName")]
        public string DatabaseName { get; set; }
    }
}
