// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class MacOSPrivacyAccessControlItemModel
{
    [JsonPropertyName("accessibility")]
    public MacOSPrivacyAccessControlItemAccessibilityConstant? Accessibility { get; set; }

    [JsonPropertyName("addressBook")]
    public MacOSPrivacyAccessControlItemAddressBookConstant? AddressBook { get; set; }

    [JsonPropertyName("appleEventsAllowedReceivers")]
    public List<MacOSAppleEventReceiverModel>? AppleEventsAllowedReceivers { get; set; }

    [JsonPropertyName("blockCamera")]
    public bool? BlockCamera { get; set; }

    [JsonPropertyName("blockListenEvent")]
    public bool? BlockListenEvent { get; set; }

    [JsonPropertyName("blockMicrophone")]
    public bool? BlockMicrophone { get; set; }

    [JsonPropertyName("blockScreenCapture")]
    public bool? BlockScreenCapture { get; set; }

    [JsonPropertyName("calendar")]
    public MacOSPrivacyAccessControlItemCalendarConstant? Calendar { get; set; }

    [JsonPropertyName("codeRequirement")]
    public string? CodeRequirement { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fileProviderPresence")]
    public MacOSPrivacyAccessControlItemFileProviderPresenceConstant? FileProviderPresence { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("identifierType")]
    public MacOSPrivacyAccessControlItemIdentifierTypeConstant? IdentifierType { get; set; }

    [JsonPropertyName("mediaLibrary")]
    public MacOSPrivacyAccessControlItemMediaLibraryConstant? MediaLibrary { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("photos")]
    public MacOSPrivacyAccessControlItemPhotosConstant? Photos { get; set; }

    [JsonPropertyName("postEvent")]
    public MacOSPrivacyAccessControlItemPostEventConstant? PostEvent { get; set; }

    [JsonPropertyName("reminders")]
    public MacOSPrivacyAccessControlItemRemindersConstant? Reminders { get; set; }

    [JsonPropertyName("speechRecognition")]
    public MacOSPrivacyAccessControlItemSpeechRecognitionConstant? SpeechRecognition { get; set; }

    [JsonPropertyName("staticCodeValidation")]
    public bool? StaticCodeValidation { get; set; }

    [JsonPropertyName("systemPolicyAllFiles")]
    public MacOSPrivacyAccessControlItemSystemPolicyAllFilesConstant? SystemPolicyAllFiles { get; set; }

    [JsonPropertyName("systemPolicyDesktopFolder")]
    public MacOSPrivacyAccessControlItemSystemPolicyDesktopFolderConstant? SystemPolicyDesktopFolder { get; set; }

    [JsonPropertyName("systemPolicyDocumentsFolder")]
    public MacOSPrivacyAccessControlItemSystemPolicyDocumentsFolderConstant? SystemPolicyDocumentsFolder { get; set; }

    [JsonPropertyName("systemPolicyDownloadsFolder")]
    public MacOSPrivacyAccessControlItemSystemPolicyDownloadsFolderConstant? SystemPolicyDownloadsFolder { get; set; }

    [JsonPropertyName("systemPolicyNetworkVolumes")]
    public MacOSPrivacyAccessControlItemSystemPolicyNetworkVolumesConstant? SystemPolicyNetworkVolumes { get; set; }

    [JsonPropertyName("systemPolicyRemovableVolumes")]
    public MacOSPrivacyAccessControlItemSystemPolicyRemovableVolumesConstant? SystemPolicyRemovableVolumes { get; set; }

    [JsonPropertyName("systemPolicySystemAdminFiles")]
    public MacOSPrivacyAccessControlItemSystemPolicySystemAdminFilesConstant? SystemPolicySystemAdminFiles { get; set; }
}
