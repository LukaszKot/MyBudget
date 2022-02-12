provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "my_budget_dev_rg" {
  name     = "my-budget-dev-rg"
  location = "westeurope"
}
