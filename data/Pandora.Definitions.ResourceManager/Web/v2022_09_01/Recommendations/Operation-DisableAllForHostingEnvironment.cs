using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Recommendations;

internal class DisableAllForHostingEnvironmentOperation : Pandora.Definitions.Operations.PostOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
        };

    public override Type? RequestObject() => null;

    public override ResourceID? ResourceId() => new HostingEnvironmentId();

    public override Type? OptionsObject() => typeof(DisableAllForHostingEnvironmentOperation.DisableAllForHostingEnvironmentOptions);

    public override string? UriSuffix() => "/recommendations/disable";

    internal class DisableAllForHostingEnvironmentOptions
    {
        [QueryStringName("environmentName")]
        public string EnvironmentName { get; set; }
    }
}
