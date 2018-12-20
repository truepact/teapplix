# teapplix
Consume Teapplix V2 API in C# 

This class consumes Teapplix API. It includes a base class that handles crude funtions of GET/POST/PUT/DELETE.
All "business" functions that are implemented can be found in TeapplixAPI.cs

Following functions are implemented: 
- Download Orders 
- Upload and Update Products
- Upload Inventory

Item Mapping is not available in API. 

Note: This project uses new C# 7.0 ValueTuple. You can compile this code in 4.6.x framework by adding System.ValueTuple from Nuget.
Note: This project doesn't have exception handling. Please implement yours before moving to production.

Usage: 

Example 1: 
Teapplix api = new TeapplixAPI(token, url);
TeapplixProducts products = new TeapplixProducts();
//create your products using Models.TeapplixProduct class. All null values are disregarded by Json converter. 
products.Products = products; 
var response = api.UploadProducts(products);

foreach(var p in response.result.Products)
  Console.WriteLine(p.ItemName + " - " + p.status);
  
Example 2: 
Teapplix api = new TeapplixAPI(token, url);
TeapplixProductsForUpdate products = new TeapplixProductsForUpdate();
//create your products using Models.TeapplixProductForUpdate class. All null values are disregarded by Json converter
products.Products = products; 
var response = api.UpdateProducts(products);

foreach(var p in response.result.Products)
  Console.WriteLine(p.ItemName + " - " + p.status);
  
Example 3: 

TeapplixAPI api = new TeapplixAPI(token, url);

List<KeyValuePair<OrderQueryParameters, string>> kvplist = new List<KeyValuePair<OrderQueryParameters, string>>();
//get all unshipped orders
kvplist.Add(new KeyValuePair<OrderQueryParameters, string>(OrderQueryParameters.NotShipped, "1"));
var response = api.DownloadOrders(kvplist);

foreach(var order in response.Orders)
{
  //handle orders
}




  
