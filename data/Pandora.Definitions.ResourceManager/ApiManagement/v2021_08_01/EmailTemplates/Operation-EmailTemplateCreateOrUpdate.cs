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

internal class EmailTemplateCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(EmailTemplateUpdateParametersModel);

    public override ResourceID? ResourceId() => new TemplateId();

    public override Type? ResponseObject() => typeof(EmailTemplateContractModel);

    public override Type? OptionsObject() => typeof(EmailTemplateCreateOrUpdateOperation.EmailTemplateCreateOrUpdateOptions);

    internal class EmailTemplateCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
