using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Subscriptions;

internal class ListLocationsOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(LocationListResultModel);

    public override Type? OptionsObject() => typeof(ListLocationsOperation.ListLocationsOptions);

    public override string? UriSuffix() => "/locations";

    internal class ListLocationsOptions
    {
        [QueryStringName("includeExtendedLocations")]
        [Optional]
        public bool IncludeExtendedLocations { get; set; }
    }
}
