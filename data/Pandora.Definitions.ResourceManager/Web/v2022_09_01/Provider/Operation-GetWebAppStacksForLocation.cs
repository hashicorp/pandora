using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Provider;

internal class GetWebAppStacksForLocationOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LocationId();

    public override Type NestedItemType() => typeof(WebAppStackModel);

    public override Type? OptionsObject() => typeof(GetWebAppStacksForLocationOperation.GetWebAppStacksForLocationOptions);

    public override string? UriSuffix() => "/webAppStacks";

    internal class GetWebAppStacksForLocationOptions
    {
        [QueryStringName("stackOsType")]
        [Optional]
        public ProviderStackOsTypeConstant StackOsType { get; set; }
    }
}
