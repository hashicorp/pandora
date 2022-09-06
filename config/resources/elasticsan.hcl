service "ElasicSan" {
  terraform_package = "elasticsan"

  api "v2021-11-20-preview" {
    package "ElasticSans" {
      definition "elastic_san" {
        id = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ElasticSan/elasticSans/{elasticSanName}"
        display_name = "Elastic San"
      }
    }
  }
}
