package commands

import (
	"flag"
	"fmt"
	"net/http"
	"strings"
	"time"

	"github.com/go-chi/chi/v5"
	"github.com/go-chi/chi/v5/middleware"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api/internal/endpoints"
	"github.com/mitchellh/cli"
)

var _ cli.Command = ServeCommand{}

func NewServeCommand(definitionsDirectory string) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return ServeCommand{
			DefinitionsDirectory: definitionsDirectory,
			Log: hclog.New(&hclog.LoggerOptions{
				Level:  hclog.DefaultLevel,
				Output: hclog.DefaultOutput,
				TimeFn: time.Now,
			}),
		}, nil
	}
}

type ServeCommand struct {
	DefinitionsDirectory string
	Log                  hclog.Logger
}

func (ServeCommand) Help() string {
	return "Launches the Server"
}

func (c ServeCommand) Run(args []string) int {
	// TODO: dynamic ports from args/env
	port := 8080

	var serviceNamesRaw string

	f := flag.NewFlagSet("serve", flag.ExitOnError)
	f.StringVar(&serviceNamesRaw, "services", "", "A list of comma separated Service names to load")
	f.Parse(args)

	var serviceNames *[]string
	if serviceNamesRaw != "" {
		serviceNames = pointer.To(strings.Split(serviceNamesRaw, ","))
	}

	c.Log.Debug(fmt.Sprintf("Launching Server on port %d", port))
	r := chi.NewRouter()
	r.Use(middleware.Logger)
	r.Route("/", endpoints.Router(c.DefinitionsDirectory, serviceNames))
	http.ListenAndServe(fmt.Sprintf(":%d", port), r)
	return 0
}

func (ServeCommand) Synopsis() string {
	return "Launches the Server"
}
