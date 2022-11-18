using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.UserSession;

internal class ListByHostPoolOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new HostPoolId();

\t\tpublic override Type NestedItemType() => typeof(UserSessionModel);

\t\tpublic override Type? OptionsObject() => typeof(ListByHostPoolOperation.ListByHostPoolOptions);

\t\tpublic override string? UriSuffix() => "/userSessions";

    internal class ListByHostPoolOptions
    {
        [QueryStringName("$filter")]
        [Optional]
        public string Filter { get; set; }

        [QueryStringName("initialSkip")]
        [Optional]
        public int InitialSkip { get; set; }

        [QueryStringName("isDescending")]
        [Optional]
        public bool IsDescending { get; set; }

        [QueryStringName("pageSize")]
        [Optional]
        public int PageSize { get; set; }
    }
}
