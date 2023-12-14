using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.NamedValue;

internal class WorkspaceNamedValueDeleteOperation : Pandora.Definitions.Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new WorkspaceNamedValueId();

    public override Type? OptionsObject() => typeof(WorkspaceNamedValueDeleteOperation.WorkspaceNamedValueDeleteOptions);

    internal class WorkspaceNamedValueDeleteOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
