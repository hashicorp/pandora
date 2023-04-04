using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2023_03_31.Domains;

internal class Definition : ResourceDefinition
{
    public string Name => "Domains";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelVerificationOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new InitiateVerificationOperation(),
        new ListByEmailServiceResourceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DomainManagementConstant),
        typeof(DomainsProvisioningStateConstant),
        typeof(UserEngagementTrackingConstant),
        typeof(VerificationStatusConstant),
        typeof(VerificationTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DnsRecordModel),
        typeof(DomainPropertiesModel),
        typeof(DomainPropertiesVerificationRecordsModel),
        typeof(DomainPropertiesVerificationStatesModel),
        typeof(DomainResourceModel),
        typeof(UpdateDomainPropertiesModel),
        typeof(UpdateDomainRequestParametersModel),
        typeof(VerificationParameterModel),
        typeof(VerificationStatusRecordModel),
    };
}
