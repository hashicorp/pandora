using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.EmailTemplates;

internal class Definition : ResourceDefinition
{
    public string Name => "EmailTemplates";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new EmailTemplateCreateOrUpdateOperation(),
        new EmailTemplateDeleteOperation(),
        new EmailTemplateGetOperation(),
        new EmailTemplateGetEntityTagOperation(),
        new EmailTemplateUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TemplateNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EmailTemplateContractModel),
        typeof(EmailTemplateContractPropertiesModel),
        typeof(EmailTemplateParametersContractPropertiesModel),
        typeof(EmailTemplateUpdateParameterPropertiesModel),
        typeof(EmailTemplateUpdateParametersModel),
    };
}
