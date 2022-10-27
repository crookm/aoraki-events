resource "azurerm_eventgrid_domain_topic" "blog" {
  name = "blog"

  domain_name         = azurerm_eventgrid_domain.domain.name
  resource_group_name = azurerm_resource_group.rg.name
}
