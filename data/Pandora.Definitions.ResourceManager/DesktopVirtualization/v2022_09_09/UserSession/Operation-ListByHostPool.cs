using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_09_09.UserSession;

internal class ListByHostPoolOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new HostPoolId();

    public override Type NestedItemType() => typeof(UserSessionModel);

    public override Type? OptionsObject() => typeof(ListByHostPoolOperation.ListByHostPoolOptions);

    public override string? UriSuffix() => "/userSessions";

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
