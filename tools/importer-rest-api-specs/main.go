package main

import (
	"fmt"
	"log"
	"os"
	"strings"
	"sync"

	git "github.com/go-git/go-git/v5"
)

const (
	outputDirectory       = "../../data/"
	swaggerDirectory      = "../../swagger"
	resourceManagerConfig = "../../config/resource-manager.hcl"
	permissions           = os.FileMode(0755)

	// only useful for testing without outputting everything
	justParse = false
)

// Use: `PANDORA_GEN_FOR_REALSIES=true go run main.go`
// or, for redirecting to a file: `PANDORA_GEN_FOR_REALSIES=true go run main.go > ~/tmp/pandora_gen.log 2>&1`

func main() {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	debug := strings.TrimSpace(os.Getenv("DEBUG")) != ""
	if err := run(swaggerDirectory, resourceManagerConfig, debug); err != nil {
		log.Printf("Error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(swaggerDirectory string, configFilePath string, debug bool) error {
	input, err := GenerationData(configFilePath, swaggerDirectory, false)
	if err != nil {
		return fmt.Errorf("loading data: %+v", err)
	}

	swaggerGitSha, err := determineGitSha(swaggerDirectory)
	if err != nil {
		return fmt.Errorf("determining Git SHA at %q: %+v", swaggerDirectory, err)
	}

	var wg sync.WaitGroup
	for _, v := range *input {
		wg.Add(1)
		go func(v RunInput) {
			if err := importService(v, *swaggerGitSha, debug); err != nil {
				log.Printf("importing Service %q / Version %q: %+v", v.ServiceName, v.ApiVersion, err)
				wg.Done()
				return
			}

			wg.Done()
		}(v)
	}

	wg.Wait()
	return nil
}

func determineGitSha(repositoryPath string) (*string, error) {
	repo, err := git.PlainOpen(repositoryPath)
	if err != nil {
		return nil, err
	}

	ref, err := repo.Head()
	if err != nil {
		return nil, err
	}

	commit := ref.Hash().String()
	log.Printf("[DEBUG] Swagger Repository Commit SHA is %q", commit)
	return &commit, nil
}
