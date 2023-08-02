using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2023_04_01.ManagementGroups;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagementGroups";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetDescendantsOperation(),
        new HierarchySettingsCreateOrUpdateOperation(),
        new HierarchySettingsDeleteOperation(),
        new HierarchySettingsGetOperation(),
        new HierarchySettingsListOperation(),
        new HierarchySettingsUpdateOperation(),
        new ListOperation(),
        new UbscriptionsCreateOperation(),
        new UbscriptionsDeleteOperation(),
        new UbscriptionsGetSubscriptionOperation(),
        new UbscriptionsGetSubscriptionsUnderManagementGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ManagementGroupChildTypeConstant),
        typeof(ManagementGroupExpandTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureAsyncOperationResultsModel),
        typeof(CreateManagementGroupChildInfoModel),
        typeof(CreateManagementGroupDetailsModel),
        typeof(CreateManagementGroupPropertiesModel),
        typeof(CreateManagementGroupRequestModel),
        typeof(CreateOrUpdateSettingsPropertiesModel),
        typeof(CreateOrUpdateSettingsRequestModel),
        typeof(CreateParentGroupInfoModel),
        typeof(DescendantInfoModel),
        typeof(DescendantInfoPropertiesModel),
        typeof(DescendantParentGroupInfoModel),
        typeof(HierarchySettingsModel),
        typeof(HierarchySettingsInfoModel),
        typeof(HierarchySettingsListModel),
        typeof(HierarchySettingsPropertiesModel),
        typeof(ManagementGroupModel),
        typeof(ManagementGroupChildInfoModel),
        typeof(ManagementGroupDetailsModel),
        typeof(ManagementGroupInfoModel),
        typeof(ManagementGroupInfoPropertiesModel),
        typeof(ManagementGroupPathElementModel),
        typeof(ManagementGroupPropertiesModel),
        typeof(ParentGroupInfoModel),
        typeof(PatchManagementGroupRequestModel),
        typeof(SubscriptionUnderManagementGroupModel),
        typeof(SubscriptionUnderManagementGroupPropertiesModel),
    };
}
