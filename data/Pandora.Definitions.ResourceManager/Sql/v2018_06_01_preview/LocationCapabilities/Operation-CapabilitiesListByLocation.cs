using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.LocationCapabilities;

internal class CapabilitiesListByLocationOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(LocationCapabilitiesModel);

    public override Type? OptionsObject() => typeof(CapabilitiesListByLocationOperation.CapabilitiesListByLocationOptions);

    public override string? UriSuffix() => "/capabilities";

    internal class CapabilitiesListByLocationOptions
    {
        [QueryStringName("include")]
        [Optional]
        public CapabilityGroupConstant Include { get; set; }
    }
}
