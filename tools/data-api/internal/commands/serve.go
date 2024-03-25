// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"flag"
	"fmt"
	"net/http"
	"os"
	"strconv"
	"strings"

	"github.com/go-chi/chi/v5"
	"github.com/go-chi/chi/v5/middleware"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints"
	"github.com/hashicorp/pandora/tools/data-api/internal/logging"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ServeCommand{}

func NewServeCommand() func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ServeCommand{}, nil
	}
}

type ServeCommand struct{}

func (ServeCommand) Help() string {
	return "Launches the Server"
}

func (c ServeCommand) Run(args []string) int {
	var portVar int
	var serviceNamesRaw string
	var dataDirectoryRaw string

	f := flag.NewFlagSet("serve", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service names to load")
	f.IntVar(&portVar, "port", 8080, "The Port the Data API Endpoint will run on (e.g. --port=8080")
	f.StringVar(&dataDirectoryRaw, "data-directory", "../../api-definitions/", "The path to the directory the data will be read from")
	f.Parse(args)

	var serviceNames *[]string
	if serviceNamesRaw != "" {
		serviceNames = pointer.To(strings.Split(serviceNamesRaw, ","))
	}

	var port int
	if portVar != 0 {
		port = portVar
	}

	portEnv := os.Getenv("PANDORA_API_PORT")
	if portEnv != "" {
		var err error
		port, err = strconv.Atoi(portEnv)
		if err != nil {
			logging.Errorf("expected PANDORA_API_PORT to be an int: %+v", err)
			return 1
		}
	}

	var dataDirectory string
	if dataDirectoryRaw != "" {
		dataDirectory = dataDirectoryRaw
	}

	logging.Debugf("Launching Server on port %d", port)
	r := chi.NewRouter()
	r.Use(middleware.Logger)
	r.Route("/", endpoints.Router(dataDirectory, serviceNames))
	logging.Infof("Data API launched at http://localhost:%d", port)
	http.ListenAndServe(fmt.Sprintf(":%d", port), r)
	return 0
}

func (ServeCommand) Synopsis() string {
	return "Launches the Server"
}
