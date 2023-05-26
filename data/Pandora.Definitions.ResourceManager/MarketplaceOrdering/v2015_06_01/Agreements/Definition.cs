using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MarketplaceOrdering.v2015_06_01.Agreements;

internal class Definition : ResourceDefinition
{
    public string Name => "Agreements";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MarketplaceAgreementsCancelOperation(),
        new MarketplaceAgreementsCreateOperation(),
        new MarketplaceAgreementsGetOperation(),
        new MarketplaceAgreementsGetAgreementOperation(),
        new MarketplaceAgreementsListOperation(),
        new MarketplaceAgreementsSignOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(StateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AgreementPropertiesModel),
        typeof(AgreementTermsModel),
        typeof(AgreementTermsListModel),
        typeof(OldAgreementPropertiesModel),
        typeof(OldAgreementTermsModel),
    };
}
