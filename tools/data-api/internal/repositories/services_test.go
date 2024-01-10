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
	repo, err := NewServicesRepository("../../../../api-definitions/", MicrosoftGraphV1StableServiceType, nil)
	if err != nil {
		t.Fatalf(err.Error())
	}

	if _, err := repo.GetAll(MicrosoftGraphV1StableServiceType); err != nil {
		t.Fatalf(err.Error())
	}
}
