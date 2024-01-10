using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_02_01.TemplateSpecs;

internal class GetBuiltInOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new BuiltInTemplateSpecId();

    public override Type? ResponseObject() => typeof(TemplateSpecModel);

    public override Type? OptionsObject() => typeof(GetBuiltInOperation.GetBuiltInOptions);

    internal class GetBuiltInOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public TemplateSpecExpandKindConstant Expand { get; set; }
    }
}
