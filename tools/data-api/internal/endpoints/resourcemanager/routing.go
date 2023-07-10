package resourcemanager

import (
	"context"
	"fmt"
	"log"
	"net/http"

	"github.com/go-chi/chi/v5"
	"github.com/hashicorp/pandora/tools/data-api/internal/repositories"
)

func Router(router chi.Router) {
	router.Route("/services", func(r chi.Router) {
		r.Route("/{serviceName}", func(r chi.Router) {
			r.Use(serviceRouteContext)

			r.Get("/", serviceDetails)

			r.Route("/{serviceApiVersion}", func(r chi.Router) {
				r.Use(serviceApiVersionRouteContext)
				r.Get("/", detailsForApiVersion)

				r.Route("/{resourceName}", func(r chi.Router) {
					r.Use(apiResourceNameRouteContext)

					r.Get("/operations", operationsForApiResource)
					r.Get("/schema", schemaForApiResource)
				})
			})

			r.Get("/terraform", terraform)
		})
		r.NotFound(func(w http.ResponseWriter, r *http.Request) {
			w.WriteHeader(http.StatusNotFound)
		})
		r.Get("/", services)
	})
}

func serviceRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		serviceName := chi.URLParam(r, "serviceName")
		if serviceName == "" {
			log.Printf("[DEBUG] Missing Service Name")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}

		service, err := servicesRepository.GetByName(serviceName, repositories.ResourceManagerServiceType)
		if err != nil {
			internalServerError(w, fmt.Errorf("retrieving service %q: %+v", serviceName, err))
			return
		}

		ctx := context.WithValue(r.Context(), "service", service)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func serviceApiVersionRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		// TODO: implement me
		next.ServeHTTP(w, r)
	})
}

func apiResourceNameRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		// TODO: implement me, add the `Api Resource` to the Request
		// this assumes we have an API Version and a Service pre-populated
		next.ServeHTTP(w, r)
	})
}
