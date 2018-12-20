using System;
using System.Collections.Generic;

namespace TeapplixAPIAccess.Models
{
    public class TeapplixProducts
    {
        public List<TeapplixProduct> Products { get; set; }
    }

    public class TeapplixProductsForUpdate
    {
        public List<TeapplixProductForUpdate> Products { get; set; }
    }

    public class TeapplixProductForUpdate
    {
        /// <summary>
        /// Max length: 40
        /// </summary>
        public string ItemName { get; set; }
        public TeapplixProduct Product { get; set; }
    }

    public class TeapplixProductResponse
    {
        public List<TeapplixProductOperationResult> Products { get; set; }
    }

    public class TeapplixProductOperationResult
    {
        /// <summary>
        /// Max-Length: 40
        /// </summary>
        public string ItemName { get; set; }
        /// <summary>
        /// Enumeration: Success, Failure, NotFound
        /// </summary>
        public string Status { get; set; }
        public string Message { get; set; }
    }

    public class TeapplixProduct
    {
        public string ItemName { get; set; }    //	string			
        public string ItemType { get; set; }    //	string			
        public string ItemTitle { get; set; }   //	string			
        public string Upc { get; set; } //	string			
        public string Asin { get; set; }    //	string			
        public string Brand { get; set; }   //	string			
        public string Mpn { get; set; } //	string			
        public string Supplier { get; set; }    //	string			
        public string SupplierSku { get; set; } //	string			
        public string Location { get; set; }    //	string			
        public string Xref3 { get; set; }   //	string			
        public Nullable<int> Active { get; set; } //	integer			
        public TeapplixProductMainImage MainImage { get; set; } //	ProductMainImage	Product Main Image		
        public Nullable<decimal> DefaultCost { get; set; }    //	number			
        public Nullable<decimal> DefaultPrice { get; set; }   //	number			
        public Nullable<decimal> MAPPrice { get; set; }   //	number			
        public Nullable<decimal> MSRPPrice { get; set; }  //	number			
        public Nullable<decimal> CustomsValue { get; set; }   //	number			
        public string CustomsDescription { get; set; }  //	string			
        public string LocalizedCustomsDescription { get; set; } //	string			
        public string HarmonizedCode { get; set; }  //	string			
        /// <summary>
        /// 2 letter ISO Code
        /// </summary>
        public string CountryOfOrigin { get; set; } //	string	2 letter ISO code	Pattern: [A-Z]{2}	Min and Max Length: 2
        public string SalesRep { get; set; }    //	string			
        public string CommissionRate { get; set; }  //	number			
        public TeapplixWeightEntity Weight { get; set; }    //	Weight entity			
        /// <summary>
        /// If not set Teapplix will apply 6x6x4 by default
        /// </summary>
        public TeapplixDimensionsOfPackage Dimensions { get; set; } //	Dimensions of package	
        /// <summary>
        /// Enumeration: normal, individual_scan, serial_scan, none
        /// </summary>
        public string ScanControl { get; set; } //	string			
        public Nullable<int> DangerousGoodsType { get; set; } //	integer			
        public TeapplixDangerousGoodsDetails DangerousGoodsDetails { get; set; }    //	DangerousGoodsDetails	Dangerous Goods Details		
        public List<TeapplixProductFeature> Features { get; set; }  //	array<ProductFeature>	Product Features		
        public string Keywords { get; set; }    //	string	Product Keywords		
        public string LongDescriptionBase64 { get; set; }   //	string			
        public List<TeapplixProductImage> AdditionalImages { get; set; }    //	array<ProductImage>	Additional Images		
        /// <summary>
        /// Enumeration: none, root
        /// </summary>
        public string VariationType { get; set; }   //	string			
        public string WalmartCategoryId { get; set; }   //	string			
        public string WalmartCategoryOptionsBase64 { get; set; }    //	string			
        public Nullable<int> JetCategoryId { get; set; }  //	integer			
        public string JetCategoryOptionsBase64 { get; set; }    //	string			
        /// <summary>
        /// Enumeration: 101, 102, 103
        /// </summary>
        public string JetPricingPolicy { get; set; }    //	string			
        public Nullable<int> WalmartTaxCode { get; set; } //	integer			
        public List<TeapplixProductShippingException> ShippingExceptions { get; set; }  //	array<ProductShippingException>	Item Shipping Exceptions		

    }
    public class TeapplixProductMainImage
    {
        public string ImageUrlLarge { get; set; }   //	string	Large Image URL		
        public string ImageUrlSmall { get; set; }   //	string	Small Image URL		
        public string AltText { get; set; } //	string	Alternate Text		
    }

    /// <summary>
    /// If not set Teapplix will apply 6x6x4 by default
    /// </summary>
    public class TeapplixDimensionsOfPackage
    {
        public decimal Length { get; set; } //	number	Length		
        public decimal Width { get; set; }  //	number	Width		
        public decimal Depth { get; set; }  //	number	Depth		
        /// <summary>
        /// Unit of measurement	Enumeration: IN, CM	
        /// </summary>
        public string Unit { get; set; }    //	string	
    }
    public class TeapplixDangerousGoodsDetails
    {
        /// <summary>
        /// Enumeration: UN, ID, NA	
        /// </summary>
        public string CommodityType { get; set; }   //	string	Commodity Type	
        /// <summary>
        /// Max Length 5
        /// </summary>
        public string CommodityId { get; set; } //	string	Commodity Type	Max-Length: 5	
        /// <summary>
        /// Enumeration: I, II, III
        /// </summary>
        public string PackingGroup { get; set; }    //	string	Packing Group		
        /// <summary>
        /// Max-Length: 60	
        /// </summary>
        public string PackingType { get; set; } //	string	Packing Type	
        public string PackingInstruction { get; set; }  //	string	Packing Instruction	Max-Length: 4	
        /// <summary>
        /// Enumeration: PASSENGER_AND_CARGO_AIRCRAFT, CARGO_AIRCRAFT_ONLY
        /// </summary>
        public string AircraftCategoryType { get; set; }    //	string	Aircraft Category Type		
        /// <summary>
        /// Max-Length: 30	
        /// </summary>
        public string ProperName { get; set; }  //	string	Proper Name	
        /// <summary>
        /// Max-Length: 20	
        /// </summary>
        public string TechnicalName { get; set; }   //	string	Technical Name	
        /// <summary>
        /// Max-Length: 4	
        /// </summary>
        public string PrimaryClass { get; set; }    //	string	Primary Class	
        /// <summary>
        /// Max-Length: 4	
        /// </summary>
        public string SubsidiaryClass { get; set; } //	string	Subsidiary Class	
        public int ReportableQty { get; set; }  //	number	Reportable Quantity		
        /// <summary>
        /// Enumeration: oz, lb, gram, kg
        /// </summary>
        public string ReportableQtyUnit { get; set; }   //	string	Reportable Quantity Unit		
        /// <summary>
        /// Max-Length: 3	
        /// </summary>
        public string Percentage { get; set; }  //	string	Percentage	
        /// <summary>
        /// Max-Length: 40
        /// </summary>
        public string AuthorizationInfo { get; set; }   //	string	AuthorizationInfo		
    }
    public class TeapplixProductFeature
    {
        public string AttributeValue { get; set; }  //	string	Attribute Value		
        public int AttributeValueSeq { get; set; }  //	integer			
    }
    public class TeapplixProductImage
    {
        public string Url { get; set; } //	string	URL		
        public string AltText { get; set; } //	string	Alternate Text		
    }
    public class TeapplixProductShippingException
    {
        public int IsAllowed { get; set; }  //	integer	Is Allowed		
        public string ShipMethod { get; set; }  //	string	Ship Method		
        public string ServiceLevel { get; set; }    //	string			
        public string ShipRegion { get; set; }  //	string	Ship Region		
        public decimal ShipPrice { get; set; }  //	number	Ship Price		
        public string OverrideType { get; set; }    //	string	Override Type		
        public string ExceptionType { get; set; }   //	string	Exception Type		
        public string StoreType { get; set; }   //	string	Store Type		
    }
    public class TeapplixProductVariations
    {
        /// <summary>
        /// Parent Item Name of Product Variations inserted
        /// </summary>
        public string ParentItemName { get; set; }  //	string	
        /// <summary>
        /// Product Variations to be inserted or updated. If you call method again, all variations will be overwritten
        /// </summary>
        public List<TeapplixProductVariation> Variations { get; set; }	//	array<ProductVariation>	

    }

    public class TeapplixProductVariation
    {
        public string ItemName { get; set; }    //	string		Pattern: [\s\S]
        public string Asin { get; set; }    //	string		
        public string Upc { get; set; }    //	string		
        public TeapplixProductMainImage MainImage { get; set; } //	ProductMainImage	Product Main Image	
        public List<TeapplixProductImage> AdditionalImages { get; set; }    //	array<ProductImage>	Additional Images	
        public Nullable<decimal> DefaultPrice { get; set; }   //	number		
        public List<TeapplixProductFeature> Attributes { get; set; }    //	array<ProductFeature>	Variation Attributes	
        public TeapplixDangerousGoodsDetails DangerousGoodsDetails { get; set; }	//	DangerousGoodsDetails	Dangerous Goods Details	

    }
}