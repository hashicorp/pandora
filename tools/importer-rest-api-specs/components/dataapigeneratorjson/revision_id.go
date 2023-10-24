package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"path"

	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
)

func OutputMetaData(workingDirectory, swaggerGitSha string) error {
	metaData := dataApiModels.MetaData{
		GitRevision: pointer.To(swaggerGitSha),
	}

	data, err := json.MarshalIndent(&metaData, "", "\t")
	if err != nil {
		return err
	}

	revisionIdFileName := path.Join(workingDirectory, "metadata.json")
	if err := writeJsonToFile(revisionIdFileName, data); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}
