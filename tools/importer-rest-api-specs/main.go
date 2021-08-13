package main

import (
	"fmt"
	"log"
	"os"
	"strings"

	git "github.com/go-git/go-git/v5"
)

const (
	outputDirectory  = "../../data/"
	swaggerDirectory = "../../swagger"
	permissions      = os.FileMode(0755)
)

// Use: `PANDORA_GEN_FOR_REALSIES=true go run main.go`
// or, for redirecting to a file: `PANDORA_GEN_FOR_REALSIES=true go run main.go > ~/tmp/pandora_gen.log 2>&1`

func main() {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	input := GenerationData()

	swaggerGitSha, err := determineGitSha(swaggerDirectory)
	if err != nil {
		log.Printf("determining Git SHA at %q: %+v", swaggerDirectory, err)
		os.Exit(1)
	}

	if !strings.EqualFold(os.Getenv("PANDORA_GENERATE_EVERYTHING"), "true") {
		for _, v := range input {
			if err := run(v, *swaggerGitSha); err != nil {
				log.Printf("error: %+v", err)
				os.Exit(1)
			}
		}
	} else {
		if err := generateEverything(*swaggerGitSha); err != nil {
			log.Printf("error: %+v", err)
			os.Exit(1)
		}
	}

	os.Exit(0)
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

func run(input RunInput, swaggerGitSha string) error {
	debug := strings.TrimSpace(os.ExpandEnv("DEBUG")) != ""

	if debug {
		log.Printf("[STAGE] Parsing Swagger Files..")
	}
	data, err := parseSwaggerFiles(input, debug)
	if err != nil {
		return fmt.Errorf("parsing Swagger files: %+v", err)
	}

	if debug {
		log.Printf("[STAGE] Generating Swagger Definitions..")
	}
	if err := generateServiceDefinitions(*data, input.OutputDirectory, input.RootNamespace, swaggerGitSha, debug); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	if debug {
		log.Printf("[STAGE] Generating API Definitions..")
	}
	if err := generateApiVersions(*data, input.OutputDirectory, input.RootNamespace, swaggerGitSha, debug); err != nil {
		return fmt.Errorf("generating API Versions: %+v", err)
	}

	return nil
}
