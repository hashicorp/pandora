// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package dataapi

import (
	"context"
	"fmt"
	"io"
	"os"
	"os/exec"
	"strings"
	"time"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
)

// dataApiCmd is a wrapper for managing Data API V2 which picks a unique port and serves the API.
type dataApiCmd struct {
	cmd      *exec.Cmd
	endpoint string
	port     int
}

// newDataApiCmd prepares the Data API (V2) to be launched.
func newDataApiCmd(binary string, port int, workingDirectory string) *dataApiCmd {
	args := []string{
		"serve",
		fmt.Sprintf("--data-directory=%s", workingDirectory),
	}
	log.Logger.Debug(fmt.Sprintf("Launching %q with args %q..", binary, strings.Join(args, " ")))
	cmd := exec.Command(binary, args...)
	cmd.Env = os.Environ()
	cmd.Env = append(cmd.Env, fmt.Sprintf("PANDORA_API_PORT=%d", port))

	// we could pipe this elsewhere, but this is probably sufficient to ignore for now
	cmd.Stderr = io.Discard
	cmd.Stdout = io.Discard

	return &dataApiCmd{
		cmd:      cmd,
		endpoint: fmt.Sprintf("http://localhost:%d", port),
		port:     port,
	}
}

// launchAndWait launches the Data API and then polls until it's fully available/online.
func (p *dataApiCmd) launchAndWait(ctx context.Context, client *v1.Client) error {
	log.Logger.Trace(fmt.Sprintf("Launching Data API on Port %d", p.port))
	if err := p.cmd.Start(); err != nil {
		return fmt.Errorf("launching Data API: %+v", err)
	}
	log.Logger.Trace(fmt.Sprintf("Data API is launched at %q.", p.endpoint))

	// then ensure it's accepting requests prior to hitting it (e.g. firewalls)
	for attempts := 0; attempts < 50; attempts++ {
		log.Logger.Trace(fmt.Sprintf("Checking the health of the Data API - attempt %d/50", attempts+1))

		if (p.cmd.ProcessState != nil && p.cmd.ProcessState.Exited()) || p.cmd.Process == nil {
			log.Logger.Warn("The Data API doesn't appear to be running, maybe it's crashed?")
			if p.cmd.Err != nil {
				return fmt.Errorf("running the Data API: %+v", p.cmd.Err)
			}
		}

		result, err := client.Health(ctx)
		if err != nil {
			if result != nil && result.HttpResponse != nil {
				return fmt.Errorf("unexpected status code %d", result.HttpResponse.StatusCode)
			}

			log.Logger.Trace(fmt.Sprintf("API not ready - waiting 1s to try again (%+v)", err))
			time.Sleep(1 * time.Second)
			continue
		}
		if result != nil && result.Available {
			log.Logger.Trace("API available")
			return nil
		}

		log.Logger.Trace(fmt.Sprintf("API not ready - waiting 1s to try again (%+v)", err))
		time.Sleep(1 * time.Second)
	}

	return fmt.Errorf("the Data API didn't return a 200 OK within 30 seconds")
}

// shutdown will terminate the Data API process if launched.
func (p *dataApiCmd) shutdown() error {
	if p.cmd.Process != nil {
		p.cmd.Process.Kill()
	}

	return nil
}
