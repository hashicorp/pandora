// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package discovery

import (
	"reflect"
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func TestDiscoverDataSetForAPIVersion_IgnoresExamples(t *testing.T) {
	apiVersion := "2020-01-01"
	filePaths := []string{
		"specification/compute/Compute.Management/examples/2020-01-01/VirtualMachine_Get.json",
		"specification/compute/resource-manager/stable/2020-01-01/virtualMachines.json",
		"specification/compute/resource-manager/stable/2020-01-01/examples/VirtualMachine_Get.json",
	}
	expected := models.AvailableDataSetForAPIVersion{
		APIVersion:               "2020-01-01",
		ContainsStableAPIVersion: true,
		FilePathsContainingAPIDefinitions: []string{
			"specification/compute/resource-manager/stable/2020-01-01/virtualMachines.json",
		},
	}
	logging.Log = hclog.New(hclog.DefaultOptions)
	actual, err := discoverDataSetForAPIVersion(apiVersion, filePaths)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected a value but got nil")
	}
	if !reflect.DeepEqual(expected, *actual) {
		t.Fatalf("expected and actual did not match - expected |%+v| but got |%+v", expected, *actual)
	}
}

func TestDiscoverDataSetForAPIVersion_IgnoresNonJSONFiles(t *testing.T) {
	apiVersion := "2020-01-01"
	filePaths := []string{
		"specification/compute/resource-manager/stable/2020-01-01/virtualMachines.json",
		"specification/compute/resource-manager/stable/2020-01-01/autorest.md",          // wouldn't be in this directory, but to ensure we ignore it
		"specification/compute/resource-manager/stable/2020-01-01/compute.tsp",          // again wouldn't be in this directory, but good to ensure we ignore it
		"specification/compute/resource-manager/stable/2020-01-01/some/nested/file.md",  // wouldn't be in this directory, but to ensure we ignore it
		"specification/compute/resource-manager/stable/2020-01-01/some/nested/file.tsp", // again wouldn't be in this directory, but good to ensure we ignore it
	}
	expected := models.AvailableDataSetForAPIVersion{
		APIVersion:               "2020-01-01",
		ContainsStableAPIVersion: true,
		FilePathsContainingAPIDefinitions: []string{
			"specification/compute/resource-manager/stable/2020-01-01/virtualMachines.json",
		},
	}
	logging.Log = hclog.New(hclog.DefaultOptions)
	actual, err := discoverDataSetForAPIVersion(apiVersion, filePaths)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected a value but got nil")
	}
	if !reflect.DeepEqual(expected, *actual) {
		t.Fatalf("expected and actual did not match - expected |%+v| but got |%+v", expected, *actual)
	}
}

func TestDiscoverDataSetForAPIVersion_PreviewAPIVersion(t *testing.T) {
	apiVersion := "2020-01-01-preview"
	filePaths := []string{
		"specification/compute/resource-manager/stable/2020-01-01-preview/virtualMachines.json",
		"specification/compute/resource-manager/stable/2023-01-01-preview/virtualMachines.json",
	}
	expected := models.AvailableDataSetForAPIVersion{
		APIVersion:               "2020-01-01-preview",
		ContainsStableAPIVersion: false,
		FilePathsContainingAPIDefinitions: []string{
			"specification/compute/resource-manager/stable/2020-01-01-preview/virtualMachines.json",
		},
	}
	logging.Log = hclog.New(hclog.DefaultOptions)
	actual, err := discoverDataSetForAPIVersion(apiVersion, filePaths)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected a value but got nil")
	}
	if !reflect.DeepEqual(expected, *actual) {
		t.Fatalf("expected and actual did not match - expected |%+v| but got |%+v", expected, *actual)
	}
}

func TestDiscoverDataSetForAPIVersion_StableAPIVersion(t *testing.T) {
	apiVersion := "2020-01-01"
	filePaths := []string{
		"specification/compute/resource-manager/stable/2020-01-01/virtualMachines.json",
		"specification/compute/resource-manager/stable/2023-01-01/virtualMachines.json",
	}
	expected := models.AvailableDataSetForAPIVersion{
		APIVersion:               "2020-01-01",
		ContainsStableAPIVersion: true,
		FilePathsContainingAPIDefinitions: []string{
			"specification/compute/resource-manager/stable/2020-01-01/virtualMachines.json",
		},
	}
	logging.Log = hclog.New(hclog.DefaultOptions)
	actual, err := discoverDataSetForAPIVersion(apiVersion, filePaths)
	if err != nil {
		t.Fatalf("unexpected error: %+v", err)
	}
	if actual == nil {
		t.Fatalf("expected a value but got nil")
	}
	if !reflect.DeepEqual(expected, *actual) {
		t.Fatalf("expected and actual did not match - expected |%+v| but got |%+v", expected, *actual)
	}
}
