using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Entities;

internal class QueriesOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new EntityId();

\t\tpublic override Type? ResponseObject() => typeof(GetQueriesResponseModel);

\t\tpublic override Type? OptionsObject() => typeof(QueriesOperation.QueriesOptions);

\t\tpublic override string? UriSuffix() => "/queries";

    internal class QueriesOptions
    {
        [QueryStringName("kind")]
        public EntityItemQueryKindConstant Kind { get; set; }
    }
}
