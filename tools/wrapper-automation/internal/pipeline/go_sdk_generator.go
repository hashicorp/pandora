// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"context"
	"fmt"
	"log"
	"os"
	"os/exec"
)

// RunGoSDKGenerator launches an instance of the Data API and runs the Go SDK Generator against it.
func RunGoSDKGenerator(ctx context.Context, opts Options) error {
	pipeline := Pipeline{
		logger: opts.Logger,
	}
	defer pipeline.close()

	pipeline.logger.Info("Launching the Data API..")
	if err := pipeline.launchDataAPI(ctx, opts); err != nil {
		return fmt.Errorf("launching the Data API: %+v", err)
	}

	pipeline.logger.Info("Running the Go SDK Generator..")
	if err := pipeline.runGoSDKGenerator(opts); err != nil {
		return fmt.Errorf("running the Go SDK Generator: %+v", err)
	}

	pipeline.logger.Info("My work here is done.")
	return nil
}

// runGoSDKGenerator runs the Go SDK Generator tool against the running instance of the Data API.
func (p *Pipeline) runGoSDKGenerator(opts Options) error {
	if p.endpoint == nil {
		return fmt.Errorf("internal-error: the Data API is not running")
	}

	args := []string{
		string(opts.SourceDataType),
		"generate",
		fmt.Sprintf("-data-api=%s", *p.endpoint),
	}
	if opts.OutputDirectory != "" {
		args = append(args, fmt.Sprintf("-output-dir=%s", opts.OutputDirectory))
	}
	cmd := exec.Command("generator-go-sdk", args...)
	log.Printf("Go SDK Generator Output:")
	log.Printf("----------------------------------------")
	cmd.Stdout = os.Stdout
	cmd.Stderr = os.Stderr
	if err := cmd.Run(); err != nil {
		return fmt.Errorf("running Go SDK Generator: %+v", err)
	}
	log.Printf("----------------------------------------")

	return nil
}
