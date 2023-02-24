using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Entities;

internal class QueriesOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new EntityId();

    public override Type? ResponseObject() => typeof(GetQueriesResponseModel);

    public override Type? OptionsObject() => typeof(QueriesOperation.QueriesOptions);

    public override string? UriSuffix() => "/queries";

    internal class QueriesOptions
    {
        [QueryStringName("kind")]
        public EntityItemQueryKindConstant Kind { get; set; }
    }
}
