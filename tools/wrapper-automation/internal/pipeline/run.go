// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"context"
	"fmt"
	"log"
	"math/rand"
	"os"
	"os/exec"
	"time"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type Pipeline struct {
	// client is an instance of the Data API SDK client.
	client *v1.Client

	// endpoint is the location where the Data API is available.
	endpoint *string

	// dataApi is an instance of the Data API, if running.
	dataApi *exec.Cmd

	// logger is an instance of a Logger
	logger hclog.Logger
}

type Options struct {
	// APIDefinitionsDirectory specifies the path to the directory containing the API Definitions (e.g. `./api-definitions`).
	APIDefinitionsDirectory string

	// Logger is an instance of a Logger, used for debugging purposes.
	Logger hclog.Logger

	// OutputDirectory specifies the path to the directory where files should be output.
	OutputDirectory string

	// SourceDataType specifies the Source Data Type being queried.
	SourceDataType models.SourceDataType
}

// launchDataAPI launches the Data API
func (p *Pipeline) launchDataAPI(ctx context.Context, opts Options) error {
	port := p.randomPortNumber()

	p.dataApi = exec.Command("data-api", "serve", fmt.Sprintf("--data-directory=%s", opts.APIDefinitionsDirectory))
	env := os.Environ()
	env = append(env, fmt.Sprintf("PANDORA_API_PORT=%d", port))
	p.dataApi.Env = env
	endpoint := fmt.Sprintf("http://localhost:%d", port)
	log.Printf("Launching Data API on Port %d", port)
	if err := p.dataApi.Start(); err != nil {
		return fmt.Errorf("launching Data API: %+v", err)
	}
	log.Printf("Data API is available at %s", endpoint)

	// then build an SDK Client pointing at this endpoint
	p.client = v1.NewClient(endpoint, opts.SourceDataType)
	p.endpoint = pointer.To(endpoint)

	p.logger.Info("Waiting for the Data API to become available..")
	if err := p.waitForDataAPIToBecomeAvailable(ctx); err != nil {
		return fmt.Errorf("waiting for the Data API to become available: %+v", err)
	}

	return nil
}

// waitForDataAPIToBecomeAvailable waits for the Data API to be available
// This means that we will try hitting the `/health` endpoint for 30s, if it's not loaded
// after this time then there's likely a data issue.
func (p *Pipeline) waitForDataAPIToBecomeAvailable(ctx context.Context) error {
	for attempts := 0; attempts < 30; attempts++ {

		resp, err := p.client.Health(ctx)
		if err != nil {
			log.Printf("[DEBUG] API not ready - waiting 1s to try again (%+v)", err)
			time.Sleep(1 * time.Second)
			continue
		}

		if resp.Available {
			p.logger.Trace("Data API available..")
			return nil
		}

		return fmt.Errorf("unexpected status code %d", resp.HttpResponse.StatusCode)
	}

	return fmt.Errorf("the Data API didn't return a 200 OK within 30 seconds")
}

// randomPortNumber returns a random port number - this allows launching a unique instance each time
func (p *Pipeline) randomPortNumber() int {
	return rand.Intn(50000-10000) + 10000
}

func (p *Pipeline) close() error {
	p.client = nil
	p.endpoint = nil
	if p.dataApi == nil || p.dataApi.Process == nil {
		return nil
	}

	return p.dataApi.Process.Kill()
}
