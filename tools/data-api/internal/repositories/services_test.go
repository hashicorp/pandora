// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package repositories

import (
	"testing"
)

func TestServices_ResourceManager(t *testing.T) {
	repo, err := NewServicesRepository("../../../../api-definitions/", ResourceManagerServiceType, nil)
	if err != nil {
		t.Fatalf(err.Error())
	}

	if _, err := repo.GetAll(ResourceManagerServiceType); err != nil {
		t.Fatalf(err.Error())
	}
}

func TestServices_MicrosoftGraph(t *testing.T) {
	repo, err := NewServicesRepository("../../../../api-definitions/", MicrosoftGraphServiceType, nil)
	if err != nil {
		t.Fatalf(err.Error())
	}

	if _, err := repo.GetAll(MicrosoftGraphServiceType); err != nil {
		t.Fatalf(err.Error())
	}
}
