using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeapplixAPIAccess.Models
{
    public class TeapplixInventoryQuantities
    {
        public List<TeapplixProductQuantity> Quantities { get; set; }
        /// <summary>
        /// Cleanup old in-stock records that are replaced by current import
        /// </summary>
        public bool Cleanup { get; set; }
        /// <summary>
        /// Automatically create the referenced product if not found
        /// Enumeration:reject, create
        /// </summary>
        public string ProductCrossReference { get; set; }
    }

    public class TeapplixProductQuantity
    {
        public Nullable<int> PONumber { get; set; }   //	integer	PO Number	
        /// <summary>
        /// This is required field. 
        /// </summary>
        public string PostDate { get; set; }    //	string	Post Date	
        /// <summary>
        /// Required. Enumeration: debit, credit, in-stock
        /// </summary>
        public string PostType { get; set; }    //	string		
        public int WarehouseId { get; set; }    //	integer	Warehouse Id. WarehouseId, WarehouseName or both WarehouseId and WarehouseName are accepted, but WarehouseName has higher priority if they does not match.	
        public string WarehouseName { get; set; }   //	string	Warehouse Name. Only allowed for external warehouses. WarehouseId, WarehouseName or both WarehouseId and WarehouseName are accepted, but WarehouseName has higher priority if they does not match.	
        /// <summary>
        /// Required field
        /// </summary>
        public string ItemName { get; set; }    //	string	Item Name	
        /// <summary>
        /// Required field
        /// </summary>
        public int Quantity { get; set; }   //	integer	Quantity	
        /// <summary>
        /// Location
        /// </summary>
        public string Location { get; set; }    //	string	Location	
        public Nullable<decimal> UnitPrice { get; set; }  //	number	Unit Price	
        public string PostComment { get; set; }	//	string	Post Comment	

    }
}
