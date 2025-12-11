// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package internal

import (
	"fmt"
	"path/filepath"
	"testing"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
)

const apiDefinitionsDirectory = "../../../api-definitions"

func TestAvailableData(t *testing.T) {
	// This test parses all the available API Definitions within the Data Directory, for each
	// Source Data Type, we discover the available Source Data Origins and load those.
	// This is used to validate that the Data within the `./api-definitions` directory is valid
	// and usable/parsable.
	workingDirectory, err := filepath.Abs(apiDefinitionsDirectory)
	if err != nil {
		t.Fatalf("determining absolute path to %q: %+v", apiDefinitionsDirectory, err)
	}

	sourceDataTypes := v1.AvailableSourceDataTypes()
	for _, sourceDataType := range sourceDataTypes {
		t.Run(fmt.Sprintf("%s Common Types", string(sourceDataType)), func(t *testing.T) {
			repo, err := repository.NewRepository(workingDirectory, sourceDataType, nil, hclog.NewNullLogger())
			if err != nil {
				t.Fatalf("building repository for Source Data Type %q: %+v", sourceDataType, err)
			}

			if _, err := repo.GetCommonTypes(); err != nil {
				t.Fatalf("retrieving the Common Types for Source Data Type %q: %+v", sourceDataType, err)
			}
		})

		t.Run(fmt.Sprintf("%s Services", string(sourceDataType)), func(t *testing.T) {
			repo, err := repository.NewRepository(workingDirectory, sourceDataType, nil, hclog.NewNullLogger())
			if err != nil {
				t.Fatalf("building repository for Source Data Type %q: %+v", sourceDataType, err)
			}

			services, err := repo.GetAllServices()
			if err != nil {
				t.Fatalf("retrieving all Services for Source Data Type %q: %+v", sourceDataType, err)
			}
			t.Logf("Retrieved %d Services", len(*services))
		})
	}
}
