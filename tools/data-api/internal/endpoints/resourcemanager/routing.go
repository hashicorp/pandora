package resourcemanager

import (
	"context"
	"net/http"

	"github.com/go-chi/chi/v5"
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
		// TODO: implement me
		//articleID := chi.URLParam(r, "articleID")
		//article, err := dbGetArticle(articleID)
		//if err != nil {
		//	http.Error(w, http.StatusText(404), 404)
		//	return
		//}
		service := struct{}{}
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
