using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.AppServiceCertificateOrders;

internal class Definition : ResourceDefinition
{
    public string Name => "AppServiceCertificateOrders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new CreateOrUpdateCertificateOperation(),
        new DeleteOperation(),
        new DeleteCertificateOperation(),
        new GetOperation(),
        new GetCertificateOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new ListCertificatesOperation(),
        new ReissueOperation(),
        new RenewOperation(),
        new ResendEmailOperation(),
        new ResendRequestEmailsOperation(),
        new RetrieveCertificateActionsOperation(),
        new RetrieveCertificateEmailHistoryOperation(),
        new RetrieveSiteSealOperation(),
        new UpdateOperation(),
        new UpdateCertificateOperation(),
        new ValidatePurchaseInformationOperation(),
        new VerifyDomainOwnershipOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CertificateOrderActionTypeConstant),
        typeof(CertificateOrderStatusConstant),
        typeof(CertificateProductTypeConstant),
        typeof(KeyVaultSecretStatusConstant),
        typeof(ProvisioningStateConstant),
        typeof(ResourceNotRenewableReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppServiceCertificateModel),
        typeof(AppServiceCertificateOrderModel),
        typeof(AppServiceCertificateOrderPatchResourceModel),
        typeof(AppServiceCertificateOrderPatchResourcePropertiesModel),
        typeof(AppServiceCertificateOrderPropertiesModel),
        typeof(AppServiceCertificatePatchResourceModel),
        typeof(AppServiceCertificateResourceModel),
        typeof(CertificateDetailsModel),
        typeof(CertificateEmailModel),
        typeof(CertificateOrderActionModel),
        typeof(CertificateOrderContactModel),
        typeof(NameIdentifierModel),
        typeof(ReissueCertificateOrderRequestModel),
        typeof(ReissueCertificateOrderRequestPropertiesModel),
        typeof(RenewCertificateOrderRequestModel),
        typeof(RenewCertificateOrderRequestPropertiesModel),
        typeof(SiteSealModel),
        typeof(SiteSealRequestModel),
    };
}
