// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package normalize

import (
	"testing"
)

func TestDeDuplicate(t *testing.T) {
	testCases := map[string]string{
		// simple duplicate preceding word
		"ApplicationApplicationOwner": "ApplicationOwner",

		// duplicate words from beginning of string
		"ConditionalAccessConditionalAccessDevicePlatform": "ConditionalAccessDevicePlatform",

		// duplicate preceding word + duplicate words from beginning
		"GroupGroupMemberGroupMemberRef": "GroupMemberRef",

		// single duplicate word from beginning should not be removed
		"ServicePrincipalServiceProfile": "ServicePrincipalServiceProfile",

		// non-duplicate - not preceding and not from beginning
		"UserAccountPasswordAccountPolicy": "UserAccountPasswordAccountPolicy",

		// single duplicate word at end of name, so must be retained
		"UserCountCount": "UserCountCount",

		// duplicate from beginning, but at end of name, so must be retained
		"SynchronizationSecretKeyStringValuePairSynchronizationSecret": "SynchronizationSecretKeyStringValuePairSynchronizationSecret",

		// duplicate chain after singularization
		"ConditionalAccessGuestsOrExternalUsersGuestOrExternalUserType": "ConditionalAccessGuestsOrExternalUsersType",
	}

	for input, expected := range testCases {
		result := DeDuplicateName(input)
		if result != expected {
			t.Errorf("DeDuplicateName(%q): got %q, expected %q", input, result, expected)
		}
	}
}
