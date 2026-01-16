// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataapi

import (
	"context"
	"fmt"
	"math/rand"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// ParseDataFromPath launches the Data API using inputPath as the API Definitions directory.
func ParseDataFromPath(ctx context.Context, dataApiBinary, inputPath string, sourceDataType models.SourceDataType) (*v1.LoadAllDataResult, error) {
	port := randomPortNumber()
	log.Logger.Info("Launching Data API..")
	dataApi := newDataApiCmd(dataApiBinary, port, inputPath)

	client := v1.NewClient(dataApi.endpoint, sourceDataType)
	if err := dataApi.launchAndWait(ctx, client); err != nil {
		return nil, fmt.Errorf("launching the Data API: %+v", err)
	}
	defer dataApi.shutdown()

	data, err := client.LoadAllData(ctx, nil)
	if err != nil {
		return nil, fmt.Errorf("loading data: %+v", err)
	}

	return data, nil
}

// randomPortNumber returns a random port number - this allows launching a unique instance each time
func randomPortNumber() int {
	return rand.Intn(50000-10000) + 10000
}
