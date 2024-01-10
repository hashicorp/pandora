// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class GroupModel
{
    [JsonPropertyName("acceptedSenders")]
    public List<DirectoryObjectModel>? AcceptedSenders { get; set; }

    [JsonPropertyName("allowExternalSenders")]
    public bool? AllowExternalSenders { get; set; }

    [JsonPropertyName("appRoleAssignments")]
    public List<AppRoleAssignmentModel>? AppRoleAssignments { get; set; }

    [JsonPropertyName("assignedLabels")]
    public List<AssignedLabelModel>? AssignedLabels { get; set; }

    [JsonPropertyName("assignedLicenses")]
    public List<AssignedLicenseModel>? AssignedLicenses { get; set; }

    [JsonPropertyName("autoSubscribeNewMembers")]
    public bool? AutoSubscribeNewMembers { get; set; }

    [JsonPropertyName("calendar")]
    public CalendarModel? Calendar { get; set; }

    [JsonPropertyName("calendarView")]
    public List<EventModel>? CalendarView { get; set; }

    [JsonPropertyName("classification")]
    public string? Classification { get; set; }

    [JsonPropertyName("conversations")]
    public List<ConversationModel>? Conversations { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("createdOnBehalfOf")]
    public DirectoryObjectModel? CreatedOnBehalfOf { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("drive")]
    public DriveModel? Drive { get; set; }

    [JsonPropertyName("drives")]
    public List<DriveModel>? Drives { get; set; }

    [JsonPropertyName("events")]
    public List<EventModel>? Events { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("groupLifecyclePolicies")]
    public List<GroupLifecyclePolicyModel>? GroupLifecyclePolicies { get; set; }

    [JsonPropertyName("groupTypes")]
    public List<string>? GroupTypes { get; set; }

    [JsonPropertyName("hasMembersWithLicenseErrors")]
    public bool? HasMembersWithLicenseErrors { get; set; }

    [JsonPropertyName("hideFromAddressLists")]
    public bool? HideFromAddressLists { get; set; }

    [JsonPropertyName("hideFromOutlookClients")]
    public bool? HideFromOutlookClients { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isArchived")]
    public bool? IsArchived { get; set; }

    [JsonPropertyName("isAssignableToRole")]
    public bool? IsAssignableToRole { get; set; }

    [JsonPropertyName("isSubscribedByMail")]
    public bool? IsSubscribedByMail { get; set; }

    [JsonPropertyName("licenseProcessingState")]
    public LicenseProcessingStateModel? LicenseProcessingState { get; set; }

    [JsonPropertyName("mail")]
    public string? Mail { get; set; }

    [JsonPropertyName("mailEnabled")]
    public bool? MailEnabled { get; set; }

    [JsonPropertyName("mailNickname")]
    public string? MailNickname { get; set; }

    [JsonPropertyName("memberOf")]
    public List<DirectoryObjectModel>? MemberOf { get; set; }

    [JsonPropertyName("members")]
    public List<DirectoryObjectModel>? Members { get; set; }

    [JsonPropertyName("membersWithLicenseErrors")]
    public List<DirectoryObjectModel>? MembersWithLicenseErrors { get; set; }

    [JsonPropertyName("membershipRule")]
    public string? MembershipRule { get; set; }

    [JsonPropertyName("membershipRuleProcessingState")]
    public string? MembershipRuleProcessingState { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("onPremisesDomainName")]
    public string? OnPremisesDomainName { get; set; }

    [JsonPropertyName("onPremisesLastSyncDateTime")]
    public DateTime? OnPremisesLastSyncDateTime { get; set; }

    [JsonPropertyName("onPremisesNetBiosName")]
    public string? OnPremisesNetBiosName { get; set; }

    [JsonPropertyName("onPremisesProvisioningErrors")]
    public List<OnPremisesProvisioningErrorModel>? OnPremisesProvisioningErrors { get; set; }

    [JsonPropertyName("onPremisesSamAccountName")]
    public string? OnPremisesSamAccountName { get; set; }

    [JsonPropertyName("onPremisesSecurityIdentifier")]
    public string? OnPremisesSecurityIdentifier { get; set; }

    [JsonPropertyName("onPremisesSyncEnabled")]
    public bool? OnPremisesSyncEnabled { get; set; }

    [JsonPropertyName("onenote")]
    public OnenoteModel? Onenote { get; set; }

    [JsonPropertyName("owners")]
    public List<DirectoryObjectModel>? Owners { get; set; }

    [JsonPropertyName("permissionGrants")]
    public List<ResourceSpecificPermissionGrantModel>? PermissionGrants { get; set; }

    [JsonPropertyName("photo")]
    public ProfilePhotoModel? Photo { get; set; }

    [JsonPropertyName("photos")]
    public List<ProfilePhotoModel>? Photos { get; set; }

    [JsonPropertyName("planner")]
    public PlannerGroupModel? Planner { get; set; }

    [JsonPropertyName("preferredDataLocation")]
    public string? PreferredDataLocation { get; set; }

    [JsonPropertyName("preferredLanguage")]
    public string? PreferredLanguage { get; set; }

    [JsonPropertyName("proxyAddresses")]
    public List<string>? ProxyAddresses { get; set; }

    [JsonPropertyName("rejectedSenders")]
    public List<DirectoryObjectModel>? RejectedSenders { get; set; }

    [JsonPropertyName("renewedDateTime")]
    public DateTime? RenewedDateTime { get; set; }

    [JsonPropertyName("securityEnabled")]
    public bool? SecurityEnabled { get; set; }

    [JsonPropertyName("securityIdentifier")]
    public string? SecurityIdentifier { get; set; }

    [JsonPropertyName("serviceProvisioningErrors")]
    public List<ServiceProvisioningErrorModel>? ServiceProvisioningErrors { get; set; }

    [JsonPropertyName("settings")]
    public List<GroupSettingModel>? Settings { get; set; }

    [JsonPropertyName("sites")]
    public List<SiteModel>? Sites { get; set; }

    [JsonPropertyName("team")]
    public TeamModel? Team { get; set; }

    [JsonPropertyName("theme")]
    public string? Theme { get; set; }

    [JsonPropertyName("threads")]
    public List<ConversationThreadModel>? Threads { get; set; }

    [JsonPropertyName("transitiveMemberOf")]
    public List<DirectoryObjectModel>? TransitiveMemberOf { get; set; }

    [JsonPropertyName("transitiveMembers")]
    public List<DirectoryObjectModel>? TransitiveMembers { get; set; }

    [JsonPropertyName("unseenCount")]
    public int? UnseenCount { get; set; }

    [JsonPropertyName("visibility")]
    public string? Visibility { get; set; }
}
