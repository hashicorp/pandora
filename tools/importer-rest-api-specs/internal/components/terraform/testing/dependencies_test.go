// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package testing

import (
	"strings"
	"testing"
)

func TestDependencies_VirtualNetworkID(t *testing.T) {
	dependencies := testDependencies{
		variables: testVariables{},
	}

	ref, deps, err := DetermineDependencies("virtual_network_id", "example", &dependencies)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	if ref == nil {
		t.Fatalf("reference was nil")
	}

	if !strings.EqualFold(*ref, "example_virtual_network.test.id") {
		t.Fatalf("expected %s got %s for dependency reference", "example_virtual_network.test.id", *ref)
	}

	if !deps.needsResourceGroup {
		t.Fatalf("expected Resource Group dependency to be set")
	}

	if !deps.needsVirtualNetwork {
		t.Fatalf("expected Virtual Network dependency to be set")
	}
}

func TestDependencies_NonExistentID(t *testing.T) {
	dependencies := testDependencies{
		variables: testVariables{},
	}

	_, _, err := DetermineDependencies("non_existent_id", "example", &dependencies)
	if err == nil {
		t.Fatal("expected an error but got none")
	}
}
