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
    public EnablementConstant? Accessibility { get; set; }

    [JsonPropertyName("addressBook")]
    public EnablementConstant? AddressBook { get; set; }

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
    public EnablementConstant? Calendar { get; set; }

    [JsonPropertyName("codeRequirement")]
    public string? CodeRequirement { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("fileProviderPresence")]
    public EnablementConstant? FileProviderPresence { get; set; }

    [JsonPropertyName("identifier")]
    public string? Identifier { get; set; }

    [JsonPropertyName("identifierType")]
    public MacOSProcessIdentifierTypeConstant? IdentifierType { get; set; }

    [JsonPropertyName("mediaLibrary")]
    public EnablementConstant? MediaLibrary { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("photos")]
    public EnablementConstant? Photos { get; set; }

    [JsonPropertyName("postEvent")]
    public EnablementConstant? PostEvent { get; set; }

    [JsonPropertyName("reminders")]
    public EnablementConstant? Reminders { get; set; }

    [JsonPropertyName("speechRecognition")]
    public EnablementConstant? SpeechRecognition { get; set; }

    [JsonPropertyName("staticCodeValidation")]
    public bool? StaticCodeValidation { get; set; }

    [JsonPropertyName("systemPolicyAllFiles")]
    public EnablementConstant? SystemPolicyAllFiles { get; set; }

    [JsonPropertyName("systemPolicyDesktopFolder")]
    public EnablementConstant? SystemPolicyDesktopFolder { get; set; }

    [JsonPropertyName("systemPolicyDocumentsFolder")]
    public EnablementConstant? SystemPolicyDocumentsFolder { get; set; }

    [JsonPropertyName("systemPolicyDownloadsFolder")]
    public EnablementConstant? SystemPolicyDownloadsFolder { get; set; }

    [JsonPropertyName("systemPolicyNetworkVolumes")]
    public EnablementConstant? SystemPolicyNetworkVolumes { get; set; }

    [JsonPropertyName("systemPolicyRemovableVolumes")]
    public EnablementConstant? SystemPolicyRemovableVolumes { get; set; }

    [JsonPropertyName("systemPolicySystemAdminFiles")]
    public EnablementConstant? SystemPolicySystemAdminFiles { get; set; }
}
