// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strconv"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
)

type Arguments struct {
	// DataDirectory defines the path to the directory containing the API Definitions.
	DataDirectory string

	// Port defines the port on which the Data API should be run, this can be set dynamically via the
	// environment variable `PANDORA_API_PORT`.
	Port int

	// ServiceNames optionally defines the set of Services to filter to, meaning only these will be imported.
	ServiceNames *[]string
}

func (a *Arguments) Parse(input []string) error {
	logging.Tracef("Parsing arguments (%+v)..", input)

	var portVar int
	var serviceNamesRaw string
	var dataDirectoryRaw string
	f := flag.NewFlagSet("data-api", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service names to load")
	f.IntVar(&portVar, "port", a.Port, "The Port the Data API Endpoint will run on (e.g. --port=8080")
	f.StringVar(&dataDirectoryRaw, "data-directory", a.DataDirectory, "The path to the directory the data will be read from")
	f.Parse(input)

	if dataDirectoryRaw != "" {
		a.DataDirectory = dataDirectoryRaw
	}

	if serviceNamesRaw != "" {
		a.ServiceNames = pointer.To(strings.Split(serviceNamesRaw, ","))
	}

	if portVar != 0 {
		a.Port = portVar
	}

	portEnv := os.Getenv("PANDORA_API_PORT")
	if portEnv != "" {
		var err error
		a.Port, err = strconv.Atoi(portEnv)
		if err != nil {
			log.Fatalf("expected PANDORA_API_PORT to be an int: %+v", err)
		}
	}

	abs, err := filepath.Abs(a.DataDirectory)
	if err != nil {
		return fmt.Errorf("determining the absolute path for %q: %+v", a.DataDirectory, err)
	}
	a.DataDirectory = abs

	logging.Log.Info(fmt.Sprintf("Using Service Names [%+v]..", a.ServiceNames))
	logging.Log.Info(fmt.Sprintf("Using the Port %d..", a.Port))
	logging.Log.Info(fmt.Sprintf("Using the Data Directory %q..", a.DataDirectory))

	return nil
}
