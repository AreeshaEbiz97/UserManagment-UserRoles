Feature: Role Management

  As an admin user,
  I want to be able to create roles and assign specific permissions,
  So that I can manage user access levels effectively.

  Scenario: Create a new role and assign permissions
    Given I am logged in as an admin with valid credentials
    When I navigate to the "Roles" page
    And I create a new role named "permission928"
    And I select the role "permission928"
    And I assign the "Create" permission to the role
    And I assign the "Edit" permission to the role
    And I assign the "Delete" permission to the role
    And I assign the "Email" permission to the role
    Then the role permissions should be saved successfully
