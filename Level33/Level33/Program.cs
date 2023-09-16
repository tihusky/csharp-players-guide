using Level33.Hamburger;
using Level33.Pizza;

// Example of creating type aliases with using directives
using HamburgerOrder = Level33.Hamburger.Order;
using PizzaOrder = Level33.Pizza.Order;

var order1 = new HamburgerOrder();
var order2 = new PizzaOrder();

// This doesn't work because the compiler doesn't know which Order type we want to use
// var order3 = new Order();