using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

internal class Definition : ResourceDefinition
{
    public string Name => "ResourceProviders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new GetPublishingUserOperation(),
        new GetSourceControlOperation(),
        new GetSubscriptionDeploymentLocationsOperation(),
        new ListBillingMetersOperation(),
        new ListCustomHostNameSitesOperation(),
        new ListGeoRegionsOperation(),
        new ListPremierAddOnOffersOperation(),
        new ListSiteIdentifiersAssignedToHostNameOperation(),
        new ListSkusOperation(),
        new ListSourceControlsOperation(),
        new MoveOperation(),
        new UpdatePublishingUserOperation(),
        new UpdateSourceControlOperation(),
        new ValidateOperation(),
        new ValidateMoveOperation(),
        new VerifyHostingEnvironmentVnetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AppServicePlanRestrictionsConstant),
        typeof(CheckNameResourceTypesConstant),
        typeof(CustomDnsSuffixProvisioningStateConstant),
        typeof(HostingEnvironmentStatusConstant),
        typeof(InAvailabilityReasonTypeConstant),
        typeof(LoadBalancingModeConstant),
        typeof(ProvisioningStateConstant),
        typeof(SkuNameConstant),
        typeof(UpgradeAvailabilityConstant),
        typeof(UpgradePreferenceConstant),
        typeof(ValidateResourceTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AppServiceEnvironmentModel),
        typeof(AseV3NetworkingConfigurationModel),
        typeof(AseV3NetworkingConfigurationPropertiesModel),
        typeof(BillingMeterModel),
        typeof(BillingMeterPropertiesModel),
        typeof(CapabilityModel),
        typeof(CsmMoveResourceEnvelopeModel),
        typeof(CustomDnsSuffixConfigurationModel),
        typeof(CustomDnsSuffixConfigurationPropertiesModel),
        typeof(CustomHostnameSitesModel),
        typeof(CustomHostnameSitesPropertiesModel),
        typeof(DeploymentLocationsModel),
        typeof(GeoRegionModel),
        typeof(GeoRegionPropertiesModel),
        typeof(GlobalCsmSkuDescriptionModel),
        typeof(HostingEnvironmentDeploymentInfoModel),
        typeof(IdentifierModel),
        typeof(IdentifierPropertiesModel),
        typeof(NameIdentifierModel),
        typeof(NameValuePairModel),
        typeof(PremierAddOnOfferModel),
        typeof(PremierAddOnOfferPropertiesModel),
        typeof(ResourceNameAvailabilityModel),
        typeof(ResourceNameAvailabilityRequestModel),
        typeof(SkuCapacityModel),
        typeof(SkuInfosModel),
        typeof(SourceControlModel),
        typeof(SourceControlPropertiesModel),
        typeof(UserModel),
        typeof(UserPropertiesModel),
        typeof(ValidatePropertiesModel),
        typeof(ValidateRequestModel),
        typeof(ValidateResponseModel),
        typeof(ValidateResponseErrorModel),
        typeof(VirtualNetworkProfileModel),
        typeof(VnetParametersModel),
        typeof(VnetParametersPropertiesModel),
        typeof(VnetValidationFailureDetailsModel),
        typeof(VnetValidationFailureDetailsPropertiesModel),
        typeof(VnetValidationTestFailureModel),
        typeof(VnetValidationTestFailurePropertiesModel),
    };
}
