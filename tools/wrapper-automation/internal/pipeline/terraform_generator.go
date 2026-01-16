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

// RunTerraformGenerator launches the Data API and then runs the Terraform Generator using that.
func RunTerraformGenerator(ctx context.Context, opts Options) error {
	pipeline := Pipeline{
		logger: opts.Logger,
	}
	defer pipeline.close()

	pipeline.logger.Info("Launching the Data API..")
	if err := pipeline.launchDataAPI(ctx, opts); err != nil {
		return fmt.Errorf("launching the Data API: %+v", err)
	}

	pipeline.logger.Info("Running the Terraform Generator..")
	if err := pipeline.runTerraformGenerator(opts); err != nil {
		return fmt.Errorf("running the Terraform Generator: %+v", err)
	}

	pipeline.logger.Info("My work here is done.")
	return nil
}

// runTerraformGenerator runs the Terraform Generator tool against the running instance of the Data API.
func (p *Pipeline) runTerraformGenerator(opts Options) error {
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
	cmd := exec.Command("generator-terraform", args...)
	log.Printf("Terraform Generator Output:")
	log.Printf("----------------------------------------")
	cmd.Stdout = os.Stdout
	cmd.Stderr = os.Stderr
	if err := cmd.Run(); err != nil {
		return fmt.Errorf("running Terraform Generator: %+v", err)
	}
	log.Printf("----------------------------------------")

	return nil
}
