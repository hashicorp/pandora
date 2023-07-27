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
		serviceApiVersion := chi.URLParam(r, "serviceApiVersion")
		if serviceApiVersion == "" {
			log.Printf("[DEBUG] Missing Service API Version")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}

		ctx := r.Context()
		service, ok := ctx.Value("service").(*repositories.ServiceDetails)
		if !ok {
			internalServerError(w, fmt.Errorf("service not found in request"))
			return
		}

		apiVersion, ok := service.ApiVersions[serviceApiVersion]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		ctx = context.WithValue(ctx, "serviceApiVersion", apiVersion)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}

func apiResourceNameRouteContext(next http.Handler) http.Handler {
	return http.HandlerFunc(func(w http.ResponseWriter, r *http.Request) {
		resourceName := chi.URLParam(r, "resourceName")
		if resourceName == "" {
			log.Printf("[DEBUG] Missing Resource Name")
			http.Error(w, http.StatusText(http.StatusInternalServerError), http.StatusInternalServerError)
		}

		ctx := r.Context()

		apiVersion, ok := ctx.Value("serviceApiVersion").(*repositories.ServiceApiVersionDetails)
		if !ok {
			internalServerError(w, fmt.Errorf("service api version not found in request"))
			return
		}

		resource, ok := apiVersion.Resources[resourceName]
		if !ok {
			http.Error(w, http.StatusText(http.StatusNotFound), http.StatusNotFound)
			return
		}

		ctx = context.WithValue(ctx, "resourceName", resource)
		next.ServeHTTP(w, r.WithContext(ctx))
	})
}
