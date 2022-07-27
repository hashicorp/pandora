package main

import (
	"fmt"
	"log"
	"net/http"
	"os"
	"os/exec"
	"time"
)

func run(args Arguments) error {
	if err := args.Validate(); err != nil {
		return fmt.Errorf("validating arguments: %+v", err)
	}

	// 1: Launch the Data API
	dataApi := exec.Command("dotnet", args.DataApiAssemblyPath)
	env := os.Environ()
	env = append(env, fmt.Sprintf("PANDORA_API_PORT=%d", args.DataApiPort))
	dataApi.Env = env
	log.Printf("Launching Data API on Port %d", args.DataApiPort)
	if err := dataApi.Start(); err != nil {
		return fmt.Errorf("launching Data API: %+v", err)
	}
	log.Printf("Data API is launched on Port %d.", args.DataApiPort)
	defer func() {
		if dataApi.Process == nil {
			return
		}

		dataApi.Process.Kill()
	}()

	dataApiUri := fmt.Sprintf("http://localhost:%d", args.DataApiPort)

	// 2: Wait for it to become available
	log.Printf("Waiting for the Data API to become Available..")
	if err := waitForDataApiToBecomeAvailable(dataApiUri); err != nil {
		return fmt.Errorf("waiting for the Data API to become available: %+v", err)
	}
	log.Printf("Data API is available.")

	// 3: Launch the Go SDK Generator, if enabled
	if args.RunGoSdkGenerator {
		log.Printf("Running the Go SDK Generator..")
		if err := runGoSdkGenerator(dataApiUri, args.OutputDirectory); err != nil {
			return fmt.Errorf("running the Go SDK Generator: %+v", err)
		}
		log.Printf("Go SDK Generator has been run.")
	}

	// 4. Run the Terraform Generator, if enabled
	if args.RunTerraformGenerator {
		log.Printf("Running the Terraform Generator..")
		if err := runTerraformGenerator(dataApiUri, args.OutputDirectory); err != nil {
			return fmt.Errorf("running the Go SDK Generator: %+v", err)
		}
		log.Printf("Terraform Generator has been run.")
	}

	return nil
}

func runGoSdkGenerator(dataApiUri string, outputDirectory string) error {
	args := []string{
		fmt.Sprintf("-data-api=%s", dataApiUri),
	}
	if outputDirectory != "" {
		args = append(args, fmt.Sprintf("-output-dir=%s", outputDirectory))
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

func runTerraformGenerator(dataApiUri string, outputDirectory string) error {
	args := []string{
		fmt.Sprintf("-data-api=%s", dataApiUri),
	}
	if outputDirectory != "" {
		args = append(args, fmt.Sprintf("-output-dir=%s", outputDirectory))
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

func waitForDataApiToBecomeAvailable(dataApiUri string) error {
	for attempts := 0; attempts < 30; attempts++ {
		resp, err := http.Get(fmt.Sprintf("%s/v1/health", dataApiUri))
		if err != nil {
			log.Printf("[DEBUG] API not ready - waiting 1s to try again (%+v)", err)
			time.Sleep(1 * time.Second)
			continue
		}

		if resp.StatusCode == http.StatusOK {
			return nil
		}

		return fmt.Errorf("unexpected status code %d", resp.StatusCode)
	}

	return fmt.Errorf("the Data API didn't return a 200 OK within 30 seconds")
}
