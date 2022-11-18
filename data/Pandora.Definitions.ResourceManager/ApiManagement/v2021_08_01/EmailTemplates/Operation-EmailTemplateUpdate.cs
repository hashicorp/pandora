using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.EmailTemplates;

internal class EmailTemplateUpdateOperation : Operations.PatchOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(EmailTemplateUpdateParametersModel);

\t\tpublic override ResourceID? ResourceId() => new TemplateId();

\t\tpublic override Type? ResponseObject() => typeof(EmailTemplateContractModel);

\t\tpublic override Type? OptionsObject() => typeof(EmailTemplateUpdateOperation.EmailTemplateUpdateOptions);

    internal class EmailTemplateUpdateOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
