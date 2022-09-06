using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_11_20.WorkbookTemplatesAPIS;

internal class WorkbookTemplatesCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(WorkbookTemplateModel);

    public override ResourceID? ResourceId() => new WorkbookTemplateId();

    public override Type? ResponseObject() => typeof(WorkbookTemplateModel);


}
