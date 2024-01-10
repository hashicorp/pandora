// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

internal class UserModel
{
    [JsonPropertyName("aboutMe")]
    public string? AboutMe { get; set; }

    [JsonPropertyName("accountEnabled")]
    public bool? AccountEnabled { get; set; }

    [JsonPropertyName("activities")]
    public List<UserActivityModel>? Activities { get; set; }

    [JsonPropertyName("ageGroup")]
    public string? AgeGroup { get; set; }

    [JsonPropertyName("agreementAcceptances")]
    public List<AgreementAcceptanceModel>? AgreementAcceptances { get; set; }

    [JsonPropertyName("appRoleAssignments")]
    public List<AppRoleAssignmentModel>? AppRoleAssignments { get; set; }

    [JsonPropertyName("assignedLicenses")]
    public List<AssignedLicenseModel>? AssignedLicenses { get; set; }

    [JsonPropertyName("assignedPlans")]
    public List<AssignedPlanModel>? AssignedPlans { get; set; }

    [JsonPropertyName("authentication")]
    public AuthenticationModel? Authentication { get; set; }

    [JsonPropertyName("authorizationInfo")]
    public AuthorizationInfoModel? AuthorizationInfo { get; set; }

    [JsonPropertyName("birthday")]
    public DateTime? Birthday { get; set; }

    [JsonPropertyName("businessPhones")]
    public List<string>? BusinessPhones { get; set; }

    [JsonPropertyName("calendar")]
    public CalendarModel? Calendar { get; set; }

    [JsonPropertyName("calendarGroups")]
    public List<CalendarGroupModel>? CalendarGroups { get; set; }

    [JsonPropertyName("calendarView")]
    public List<EventModel>? CalendarView { get; set; }

    [JsonPropertyName("calendars")]
    public List<CalendarModel>? Calendars { get; set; }

    [JsonPropertyName("chats")]
    public List<ChatModel>? Chats { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("companyName")]
    public string? CompanyName { get; set; }

    [JsonPropertyName("consentProvidedForMinor")]
    public string? ConsentProvidedForMinor { get; set; }

    [JsonPropertyName("contactFolders")]
    public List<ContactFolderModel>? ContactFolders { get; set; }

    [JsonPropertyName("contacts")]
    public List<ContactModel>? Contacts { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("createdObjects")]
    public List<DirectoryObjectModel>? CreatedObjects { get; set; }

    [JsonPropertyName("creationType")]
    public string? CreationType { get; set; }

    [JsonPropertyName("customSecurityAttributes")]
    public CustomSecurityAttributeValueModel? CustomSecurityAttributes { get; set; }

    [JsonPropertyName("deletedDateTime")]
    public DateTime? DeletedDateTime { get; set; }

    [JsonPropertyName("department")]
    public string? Department { get; set; }

    [JsonPropertyName("deviceEnrollmentLimit")]
    public int? DeviceEnrollmentLimit { get; set; }

    [JsonPropertyName("deviceManagementTroubleshootingEvents")]
    public List<DeviceManagementTroubleshootingEventModel>? DeviceManagementTroubleshootingEvents { get; set; }

    [JsonPropertyName("directReports")]
    public List<DirectoryObjectModel>? DirectReports { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("drive")]
    public DriveModel? Drive { get; set; }

    [JsonPropertyName("drives")]
    public List<DriveModel>? Drives { get; set; }

    [JsonPropertyName("employeeExperience")]
    public EmployeeExperienceUserModel? EmployeeExperience { get; set; }

    [JsonPropertyName("employeeHireDate")]
    public DateTime? EmployeeHireDate { get; set; }

    [JsonPropertyName("employeeId")]
    public string? EmployeeId { get; set; }

    [JsonPropertyName("employeeLeaveDateTime")]
    public DateTime? EmployeeLeaveDateTime { get; set; }

    [JsonPropertyName("employeeOrgData")]
    public EmployeeOrgDataModel? EmployeeOrgData { get; set; }

    [JsonPropertyName("employeeType")]
    public string? EmployeeType { get; set; }

    [JsonPropertyName("events")]
    public List<EventModel>? Events { get; set; }

    [JsonPropertyName("extensions")]
    public List<ExtensionModel>? Extensions { get; set; }

    [JsonPropertyName("externalUserState")]
    public string? ExternalUserState { get; set; }

    [JsonPropertyName("externalUserStateChangeDateTime")]
    public DateTime? ExternalUserStateChangeDateTime { get; set; }

    [JsonPropertyName("faxNumber")]
    public string? FaxNumber { get; set; }

    [JsonPropertyName("followedSites")]
    public List<SiteModel>? FollowedSites { get; set; }

    [JsonPropertyName("givenName")]
    public string? GivenName { get; set; }

    [JsonPropertyName("hireDate")]
    public DateTime? HireDate { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identities")]
    public List<ObjectIdentityModel>? Identities { get; set; }

    [JsonPropertyName("imAddresses")]
    public List<string>? ImAddresses { get; set; }

    [JsonPropertyName("inferenceClassification")]
    public InferenceClassificationModel? InferenceClassification { get; set; }

    [JsonPropertyName("insights")]
    public OfficeGraphInsightsModel? Insights { get; set; }

    [JsonPropertyName("interests")]
    public List<string>? Interests { get; set; }

    [JsonPropertyName("isResourceAccount")]
    public bool? IsResourceAccount { get; set; }

    [JsonPropertyName("jobTitle")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("joinedTeams")]
    public List<TeamModel>? JoinedTeams { get; set; }

    [JsonPropertyName("lastPasswordChangeDateTime")]
    public DateTime? LastPasswordChangeDateTime { get; set; }

    [JsonPropertyName("legalAgeGroupClassification")]
    public string? LegalAgeGroupClassification { get; set; }

    [JsonPropertyName("licenseAssignmentStates")]
    public List<LicenseAssignmentStateModel>? LicenseAssignmentStates { get; set; }

    [JsonPropertyName("licenseDetails")]
    public List<LicenseDetailsModel>? LicenseDetails { get; set; }

    [JsonPropertyName("mail")]
    public string? Mail { get; set; }

    [JsonPropertyName("mailFolders")]
    public List<MailFolderModel>? MailFolders { get; set; }

    [JsonPropertyName("mailNickname")]
    public string? MailNickname { get; set; }

    [JsonPropertyName("mailboxSettings")]
    public MailboxSettingsModel? MailboxSettings { get; set; }

    [JsonPropertyName("managedAppRegistrations")]
    public List<ManagedAppRegistrationModel>? ManagedAppRegistrations { get; set; }

    [JsonPropertyName("managedDevices")]
    public List<ManagedDeviceModel>? ManagedDevices { get; set; }

    [JsonPropertyName("manager")]
    public DirectoryObjectModel? Manager { get; set; }

    [JsonPropertyName("memberOf")]
    public List<DirectoryObjectModel>? MemberOf { get; set; }

    [JsonPropertyName("messages")]
    public List<MessageModel>? Messages { get; set; }

    [JsonPropertyName("mobilePhone")]
    public string? MobilePhone { get; set; }

    [JsonPropertyName("mySite")]
    public string? MySite { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("oauth2PermissionGrants")]
    public List<OAuth2PermissionGrantModel>? Oauth2PermissionGrants { get; set; }

    [JsonPropertyName("officeLocation")]
    public string? OfficeLocation { get; set; }

    [JsonPropertyName("onPremisesDistinguishedName")]
    public string? OnPremisesDistinguishedName { get; set; }

    [JsonPropertyName("onPremisesDomainName")]
    public string? OnPremisesDomainName { get; set; }

    [JsonPropertyName("onPremisesExtensionAttributes")]
    public OnPremisesExtensionAttributesModel? OnPremisesExtensionAttributes { get; set; }

    [JsonPropertyName("onPremisesImmutableId")]
    public string? OnPremisesImmutableId { get; set; }

    [JsonPropertyName("onPremisesLastSyncDateTime")]
    public DateTime? OnPremisesLastSyncDateTime { get; set; }

    [JsonPropertyName("onPremisesProvisioningErrors")]
    public List<OnPremisesProvisioningErrorModel>? OnPremisesProvisioningErrors { get; set; }

    [JsonPropertyName("onPremisesSamAccountName")]
    public string? OnPremisesSamAccountName { get; set; }

    [JsonPropertyName("onPremisesSecurityIdentifier")]
    public string? OnPremisesSecurityIdentifier { get; set; }

    [JsonPropertyName("onPremisesSyncEnabled")]
    public bool? OnPremisesSyncEnabled { get; set; }

    [JsonPropertyName("onPremisesUserPrincipalName")]
    public string? OnPremisesUserPrincipalName { get; set; }

    [JsonPropertyName("onenote")]
    public OnenoteModel? Onenote { get; set; }

    [JsonPropertyName("onlineMeetings")]
    public List<OnlineMeetingModel>? OnlineMeetings { get; set; }

    [JsonPropertyName("otherMails")]
    public List<string>? OtherMails { get; set; }

    [JsonPropertyName("outlook")]
    public OutlookUserModel? Outlook { get; set; }

    [JsonPropertyName("ownedDevices")]
    public List<DirectoryObjectModel>? OwnedDevices { get; set; }

    [JsonPropertyName("ownedObjects")]
    public List<DirectoryObjectModel>? OwnedObjects { get; set; }

    [JsonPropertyName("passwordPolicies")]
    public string? PasswordPolicies { get; set; }

    [JsonPropertyName("passwordProfile")]
    public PasswordProfileModel? PasswordProfile { get; set; }

    [JsonPropertyName("pastProjects")]
    public List<string>? PastProjects { get; set; }

    [JsonPropertyName("people")]
    public List<PersonModel>? People { get; set; }

    [JsonPropertyName("permissionGrants")]
    public List<ResourceSpecificPermissionGrantModel>? PermissionGrants { get; set; }

    [JsonPropertyName("photo")]
    public ProfilePhotoModel? Photo { get; set; }

    [JsonPropertyName("photos")]
    public List<ProfilePhotoModel>? Photos { get; set; }

    [JsonPropertyName("planner")]
    public PlannerUserModel? Planner { get; set; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; set; }

    [JsonPropertyName("preferredDataLocation")]
    public string? PreferredDataLocation { get; set; }

    [JsonPropertyName("preferredLanguage")]
    public string? PreferredLanguage { get; set; }

    [JsonPropertyName("preferredName")]
    public string? PreferredName { get; set; }

    [JsonPropertyName("presence")]
    public PresenceModel? Presence { get; set; }

    [JsonPropertyName("print")]
    public UserPrintModel? Print { get; set; }

    [JsonPropertyName("provisionedPlans")]
    public List<ProvisionedPlanModel>? ProvisionedPlans { get; set; }

    [JsonPropertyName("proxyAddresses")]
    public List<string>? ProxyAddresses { get; set; }

    [JsonPropertyName("registeredDevices")]
    public List<DirectoryObjectModel>? RegisteredDevices { get; set; }

    [JsonPropertyName("responsibilities")]
    public List<string>? Responsibilities { get; set; }

    [JsonPropertyName("schools")]
    public List<string>? Schools { get; set; }

    [JsonPropertyName("scopedRoleMemberOf")]
    public List<ScopedRoleMembershipModel>? ScopedRoleMemberOf { get; set; }

    [JsonPropertyName("securityIdentifier")]
    public string? SecurityIdentifier { get; set; }

    [JsonPropertyName("serviceProvisioningErrors")]
    public List<ServiceProvisioningErrorModel>? ServiceProvisioningErrors { get; set; }

    [JsonPropertyName("settings")]
    public UserSettingsModel? Settings { get; set; }

    [JsonPropertyName("showInAddressList")]
    public bool? ShowInAddressList { get; set; }

    [JsonPropertyName("signInActivity")]
    public SignInActivityModel? SignInActivity { get; set; }

    [JsonPropertyName("signInSessionsValidFromDateTime")]
    public DateTime? SignInSessionsValidFromDateTime { get; set; }

    [JsonPropertyName("skills")]
    public List<string>? Skills { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("streetAddress")]
    public string? StreetAddress { get; set; }

    [JsonPropertyName("surname")]
    public string? Surname { get; set; }

    [JsonPropertyName("teamwork")]
    public UserTeamworkModel? Teamwork { get; set; }

    [JsonPropertyName("todo")]
    public TodoModel? Todo { get; set; }

    [JsonPropertyName("transitiveMemberOf")]
    public List<DirectoryObjectModel>? TransitiveMemberOf { get; set; }

    [JsonPropertyName("usageLocation")]
    public string? UsageLocation { get; set; }

    [JsonPropertyName("userPrincipalName")]
    public string? UserPrincipalName { get; set; }

    [JsonPropertyName("userType")]
    public string? UserType { get; set; }
}
