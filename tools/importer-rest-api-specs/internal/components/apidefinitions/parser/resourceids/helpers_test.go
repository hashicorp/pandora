// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package resourceids

import "testing"

func TestSegmentInScopeDenyList(t *testing.T) {
	t.Parallel()

	testCases := []struct {
		name     string
		segment  string
		uri      string
		expected bool
	}{
		{
			name:     "matches documentdb cassandra role assignment denial",
			segment:  "roleassignmentid",
			uri:      "/subscriptions/{subscriptionid}/resourcegroups/{resourcegroupname}/providers/microsoft.documentdb/databaseaccounts/{accountname}/cassandraroleassignments/{roleassignmentid}",
			expected: true,
		},
		{
			name:     "matches documentdb sql role assignment denial regardless of casing",
			segment:  "roleAssignmentId",
			uri:      "/subscriptions/{subscriptionid}/resourceGroups/{resourceGroupName}/providers/Microsoft.DocumentDB/databaseAccounts/{accountName}/sqlRoleAssignments/{roleAssignmentId}",
			expected: true,
		},
		{
			name:     "does not deny matching segment when uri is a different resource type",
			segment:  "roleAssignmentId",
			uri:      "/subscriptions/{subscriptionid}/resourceGroups/{resourceGroupName}/providers/Microsoft.Authorization/roleAssignments/{roleAssignmentId}",
			expected: false,
		},
		{
			name:     "does not deny unknown segment",
			segment:  "vmName",
			uri:      "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/{vmName}",
			expected: false,
		},
	}

	for _, tc := range testCases {
		t.Run(tc.name, func(t *testing.T) {
			if actual := segmentInScopeDenyList(tc.segment, tc.uri); actual != tc.expected {
				t.Fatalf("segmentInScopeDenyList(%q, %q) = %t, want %t", tc.segment, tc.uri, actual, tc.expected)
			}
		})
	}
}
