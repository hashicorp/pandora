service "Authorization" {
  terraform_package = "authorization"

  api "2020-10-01" {
    package "Authorization" {
      definition "role_assignment_schedule_request" {
        id = "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/RoleAssignmentScheduleRequests/{roleAssignmentScheduleRequestId}"
        display_name = "Role Assignment Schedule Request"
        website_subcategory = "Authorization"
        description = "Manages a Role Assignment Schedule Request"
      }

      definition "role_eligibility_schedule_request" {
        id = "/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/RoleEligibilityScheduleRequests/{roleEligibilityScheduleRequestId}"
        display_name = "Role Eligibility Schedule Request"
        website_subcategory = "Authorization"
        description = "Manages a Role Eligibility Schedule Request"
      }
    }
  }
}
