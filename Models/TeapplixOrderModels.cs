using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TeapplixAPIAccess.Models
{
    /// <summary>
    /// Query paramters for OrderNotification GET call. Use these with .ToString() so that you don't have to lookup and hard code each query name. 
    /// </summary>
    public enum OrderQueryParameters
    {
        /// <summary>
        /// to pull a single order
        /// </summary>
        TxnId,
        /// <summary>
        /// Unique number assigned by Teapplix
        /// </summary>
        SeqStart,
        SeqEnd,
        /// <summary>
        /// Not Shipped flag (0|1), if you pass this flag, we will only give 'open' orders.
        /// </summary>
        NotShipped,
        /// <summary>
        /// format :2012/01/01 (inclusive)
        /// </summary>
        PaymentDateStart,
        /// <summary>
        /// format :2012/01/01 (inclusive)
        /// </summary>
        PaymentDateEnd, 
        /// <summary>
        /// integer value. 0 - "normal" queue
        /// </summary>
        QueueId,
        /// <summary>
        /// default: combine. 
        /// original: provide all non-cancelled orders. if 2 ordres are combined into 1, the original order will be in the report and not combined result. 
        /// all: both original and combined will be in report
        /// </summary>
        Combine,
        /// <summary>
        /// format :2012/01/01 (inclusive)
        /// </summary>
        ShipDateStart, 
        ShipDateEnd,
        WarehouseId,
        /// <summary>
        /// none, shipping, inventory or shipping|inventory. default: none.
        /// shipping - Teapplix will do remember weight lookup for unshipped orders and then return ShippingDetail and Options Array.
        /// inventory - Teapplix will do inventory lookup and return ItemSKU and ItemLocation.
        /// </summary>
        DetailLevel

    }

    public class TeapplixOrders
    {
        public List<TeapplixOrder> Orders { get; set; }
    }

    public class TeapplixOrder
    {
        public string TxnId { get; set; }
        public string StoreType { get; set; }
        public string StoreKey { get; set; }
        public string SellerID { get; set; }
        public string PaymentStatus { get; set; }
        public TeapplixShippingAddress To { get; set; }
        public TeapplixBillingAddress BillTo { get; set; }
        public TeapplixOrderTotals OrderTotals { get; set; }
        public TeapplixOrderDetails OrderDetails { get; set; }
        public IList<TeapplixOrderItem> OrderItems { get; set; }
        public IList<TeapplixOrderShipment> ShippingDetails { get; set; }
        public TeapplixOptions Options { get; set; }
        public string SeqNumber { get; set; }
        public string RMACode { get; set; }
        /// <summary>
        /// This field is only used in PUT request only. GET request updates OrderDetails.QueueId
        /// </summary>
        public int QueueId { get; set; }
        /// <summary>
        /// This field is only used in PUT request only. GET request updates OrderDetails.Custom
        /// </summary>
        public string Custom { get; set; }
        /// <summary>
        /// This field is only used in PUT request only. GET request updates OrderDetails.Custom2
        /// </summary>
        public string Custom2 { get; set; }
    }

    public class TeapplixOptions
    {
        public bool InsuranceClosed { get; set; }   //	boolean	Insurance Closed flag. Ignored on input.
        public string InsuranceClosedReason { get; set; }   //	string	Insurance Closed Reason message. Ignored on input.
        public string ReasonForExport { get; set; } //	string	Reason For Export
        public TeapplixDelivery Delivery { get; set; }   //	Delivery	Delivery
        public TeapplixService Service { get; set; }    //	Service	
        public TeapplixCod Cod { get; set; }    //	Cod	C.O.D. details
        public TeapplixUps Ups { get; set; }    //	Ups	UPS specific options
        public TeapplixFedex Fedex { get; set; }	//	Fedex	FedEx specific options

    }

    public class TeapplixFedex
    {
        public TeapplixDuty Duty { get; set; }  //	Duty	Duty
        public string CustomsOption { get; set; }   //	string	Customs option
        public string Coverage { get; set; }    //	string	
        public TeapplixExportDetail ExportDetail { get; set; }  //	ExportDetail	Export detail
        public TeapplixPickup Pickup { get; set; }  //	Pickup	Pickup
        public TeapplixRecipient Recipient { get; set; }    //	Recipient	Recipient
        public TeapplixHoldAtLocation HoldAtLocation { get; set; }  //	HoldAtLocation	Hold At Location
        public string SmartPostEndiciaType { get; set; }    //	string	
        public decimal TotalPalletWeight { get; set; }  //	number	
        public string FreightGuaranteeDetailDate { get; set; }  //	string	
        public TeapplixDelivery Delivery { get; set; }  //	Delivery	Delivery
        public TeapplixInstructions Instructions { get; set; }  //	Instructions	Instructions
        public TeapplixFreight Freight { get; set; }    //	Freight	Freight
        public string BillAccount { get; set; } //	string	
        public string CollectTermsType { get; set; }    //	string	
        public string BrokerType { get; set; }  //	string	
        public string Billed { get; set; }  //	string	
        public string BilledAccountNumber { get; set; } //	string	
        public string SignatureReleaseNumber { get; set; }  //	string	
        public string HandlingUnits { get; set; }   //	string	
        public string ExpressFreightBookingConfirmationNumber { get; set; } //	string	
        public string B13aFilling { get; set; } //	string	
        public string ExportStatement { get; set; } //	string	
        public string ImportOfRecordAccountNumber { get; set; }	//	string	

    }

    public class TeapplixRecipient
    {
        public TeapplixCustomsId TaxId { get; set; }
        public TeapplixCustomsId CustomsId { get; set; }
    }

    public class TeapplixCustomsId
    {
        public string Type { get; set; }
        public string Number { get; set; }
    }

    public class TeapplixInstructions
    {
        public string Handling { get; set; }
        public string Delivery { get; set; }
        public string HomeDelivery { get; set; }
        public string Pickup { get; set; }
    }

    public class TeapplixHoldAtLocation
    {
        public string Applied { get; set; }
        public string Address { get; set; }
        public string AddressType { get; set; }
    }

    public class TeapplixExportDetail
    {
        public string Kind { get; set; }
        public string ForeignZoneCode { get; set; }
        public string EntryNumber { get; set; }
        public string LicenseNumber { get; set; }
        public string ExpirationDate { get; set; }
    }

    public class TeapplixDuty
    {
        public string Role { get; set; }
        public string AccountNumber { get; set; }
    }

    public class TeapplixUps
    {
        public bool SurepostNonMachineable { get; set; }
        public TeapplixVerbal Verbal { get; set; }
        public TeapplixQvn Qvn { get; set; }
        public TeapplixFreight Freight { get; set; }
    }

    public class TeapplixFreight
    {
        public decimal Class { get; set; }  //	number	Freight Class						
        public string PackageType { get; set; } //	string	Freight Package Type						
        public int PackagesQuantity { get; set; }   //	integer	Packages Quantity						
        public string PayerName { get; set; }   //	string	Payer Name	Max-Length:	40				
        public string PayerAddress { get; set; }    //	string	Payer Address	Max-Length:	255				
        public string PayerCity { get; set; }   //	string	Payer City	Max-Length:	50				
        public string PayerState { get; set; }  //	string	Payer State	Max-Length:	50				
        public string Billed { get; set; }  //	string	Billed	Enumeration:	sender, recipient, third_party				
        public string BilledAccountNumber { get; set; } //	string	Billed Account Number						
        public string BilledAccountPostalCode { get; set; } //	string	Billed Account Postal Code	Max-Length:	10				
        public string BilledAccountCountryCode { get; set; }    //	string	Billed Account Country Code	Pattern:	[A-Z]{2}	Min-Length:	2	Max-Length:	2
        public bool SortingAndSegregating { get; set; } //	boolean	Sorting And Segregating						
        public string SortingQuantity { get; set; } //	string	Sorting Quantity						
        public bool ExtremeLength { get; set; } //	boolean	Extreme Length						
        public bool FreezableProtection { get; set; }   //	boolean	Freezable Protection						
        public TeapplixHandling Handling { get; set; }  //	Handling	Handling						
        public TeapplixDangerousGoods DangerousGoods { get; set; }  //	DangerousGoods	Dangerous Goods Data						
        public TeapplixPickup Pickup { get; set; }	//	Pickup							
    }

    public class TeapplixPickup
    {
        public bool Weekend { get; set; }
        public bool Holiday { get; set; }
        public bool Inside { get; set; }
        public bool Residential { get; set; }
        public bool LimitedAccess { get; set; }
        public bool LiftGate { get; set; }
        public string Instructions { get; set; }
    }

    public class TeapplixDangerousGoods
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneExtension { get; set; }
    }

    public class TeapplixHandling
    {
        public string Charge { get; set; }
        public string ChargeType { get; set; }
        public string ChargeValue { get; set; }
        public string Instructions { get; set; }
    }

    public class TeapplixQvn
    {
        public int Qvn { get; set; }
        public string From { get; set; }
        public string EmailOnFail { get; set; }
        public string Subject { get; set; }
        public string Memo { get; set; }
        public IList<TeapplixObject> Recipients { get; set; }
    }

    public class TeapplixObject
    {
        public string CompanyOrName { get; set; }
        public string ContactName {get; set;}
        public string Email { get; set; }
        public bool ShipNotify { get; set; }
        public bool ExceptionNotify { get; set; }
        public bool DeliveryNotify { get; set; }
        public bool BolNotify { get; set; }
        public string BolEmailSubject { get; set; }
        public string BolEmailText { get; set; }
    }

    public class TeapplixVerbal
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class TeapplixCod
    {
        public TeapplixAmount Amount { get; set; } //	Amount	Declares any amount value		
        public string Kind { get; set; }    //	string	Kind		
        public string CollectionType { get; set; }  //	string	Collection Type	Enumeration:	1, 2, 3, 4, 5
        public TeapplixShippingAddress Address { get; set; }    //	ShippingAddress	Shipping Address structure		
        public string ReferenceIndicator { get; set; }  //	string	Reference indicator		
        public string TransportationChargesDetail { get; set; } //	string	Transportation Charges Detail	Enumeration:	ADD_ACCOUNT_COD_SURCHARGE, ADD_ACCOUNT_NET_CHARGE, ADD_ACCOUNT_NET_FREIGHT, ADD_ACCOUNT_TOTAL_CUSTOMER_CHARGE, ADD_LIST_COD_SURCHARGE, ADD_LIST_NET_CHARGE, ADD_LIST_NET_FREIGHT, ADD_LIST_TOTAL_CUSTOMER_CHARGE
        public string RecipientAccountNumber { get; set; }  //	string	Recipient Account Number	Pattern: \d+	
        public string BillingOption { get; set; }	//	string	Billing Option	Enumeration:	Prepaid, Freight Collect
    }

    public class TeapplixAmount
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class TeapplixService
    {
        public bool RegisteredMail { get; set; }    //	boolean	Registered mail
        public bool AdditionalHandling { get; set; }    //	boolean	Additional handling
        public bool ShipperRelease { get; set; }    //	boolean	Shipper Release
        public bool CarbonNeutral { get; set; } //	boolean	Carbon neutral
        public bool DangerousGoods { get; set; }    //	boolean	Dangerous goods
        public bool HandlingCharge { get; set; }    //	boolean	Handling charge
        public bool ExtremeLength { get; set; } //	boolean	Extreme length
        public bool ReturnsClearance { get; set; }  //	boolean	Returns clearance
        public bool Pickup { get; set; }	//	boolean	Pickup
    }

    public class TeapplixDelivery
    {
        public string Signature { get; set; }   //	string	Signature type	Enumeration:	NOT_REQUIRED, ANY_REQUIRED, ADULT_REQUIRED, DIRECT_REQUIRED, SERVICE_DEFAULT
        public int ConfirmationType { get; set; }   //	integer	Confirmation type		
        public bool Saturday { get; set; }  //	boolean	Saturday delivery		
        public bool Sunday { get; set; }    //	boolean	Sunday delivery		
        public bool Holiday { get; set; }   //	boolean	Holiday delivery		
        public bool Weekend { get; set; }   //	boolean	Weekend delivery		
        public bool Restricted { get; set; }    //	boolean	Restricted area delivery		
        public bool Am { get; set; }    //	boolean	Am		
        public bool Inside { get; set; }    //	boolean	Inside		
        public bool Residential { get; set; }   //	boolean	Residential		
        public bool LiftGate { get; set; }  //	boolean	Lift gate		
        public bool CallBefore { get; set; }    //	boolean	Call before		
        public bool ConstructionSite { get; set; }  //	boolean	Construction site		
        public string Options { get; set; } //	string			
        public bool LimitedAccess { get; set; } //	boolean			
        public string Instructions { get; set; }	//	string	Instructions		
    }

    public class TeapplixOrderShipment
    {
        public TeapplixPackage Package { get; set; }
        public string ShipDate { get; set; }
        public string PostageAccount { get; set; }
    }

    public class TeapplixPackage
    {
        public TeapplixTrackingInfo TrackingInfo { get; set; }
        public TeapplixWeightEntity Weight { get; set; }
        public TeapplixDimensions Dimensions { get; set; }
        public int IdenticalPackageCount { get; set; } //minimum: 1
        public ITeapplixPackageType Type { get; set; } //one of packagetype or custom package name
        public string Reference { get; set; }
        public decimal Postage { get; set; }
        public decimal InsuranceValue { get; set; }
        public decimal InsuranceFee { get; set; }
        public string Method { get; set; }
    }

    public class TeapplixDimensions
    {
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        /// <summary>
        /// IN, CM
        /// </summary>
        public string Unit { get; set; } 
    }

    public class TeapplixPackageType : ITeapplixPackageType
    {
        public int PackageType { get; set; }
        public string ToStringValue()
        {
            return PackageType.ToString();
        }
    }

    public class TeapplixCustomPackageName : ITeapplixPackageType
    {
        public string CustomPackageName { get; set; }
        public string ToStringValue()
        {
            return CustomPackageName;
        }
    }

    public interface ITeapplixPackageType
    {
        string ToStringValue();
    }

    public class TeapplixWeightEntity
    {
        public double Value { get; set; }
        /// <summary>
        /// OZ, LB, GR, KG
        /// </summary>
        public string Unit { get; set; } 
    }

    public class TeapplixTrackingInfo
    {
        public string TrackingNumber { get; set; }
        public string CarrierName { get; set; }
    }

    public class TeapplixOrderItem
    {
        public string Name { get; set; }    //	string	Item's name	Max-Length:	255
        public string ItemId { get; set; }  //	string	Seller item Id. This typically maps to the listing id on catalogs	Max-Length:	127
        public string ItemSKU { get; set; } //	string	Mapped product name in Teapplix	Max-Length:	255
        public string ItemLocation { get; set; }    //	string	Item Location. This is stored on the order line if you set it on inbound POST|PUT		
        public string Description { get; set; } //	string	Item description	Max-Length:	255
        public int Quantity { get; set; }   //	integer	The quantity of this item ordered		
        public decimal Amount { get; set; } //	number	Subtotal for this order line		
        public decimal Shipping { get; set; }   //	number	Shipping cost		
        public decimal Tax { get; set; }    //	number	Handling amount		
        [JsonProperty("Shipping Tax")]
        public decimal ShippingTax	{get; set;}   //	number	Shipping tax amount		

}

    public class TeapplixOrderDetails
    {
        public string Invoice { get; set; } //	string	Invoice number	Max-Length:	127
        /// <summary>
        /// type - string
        /// Date of payment. Format Y-m-D H:i:s or Y-m-d. If not set - current date time will be used
        /// Pattern: ^\d\d\d\d-(0[1-9]|1[0-2])-(0[1-9]|[12][0-9]|3[01])( (0[0-9]|1[0-9]|2[0-3]):([0-9]|[0-5][0-9]):([0-9]|[0-5][0-9])){0,1}$
        /// </summary>
        public string PaymentDate { get; set; } 
        public string Memo { get; set; }    //	string	Memo	Max-Length:	2048
        public string GiftMessage { get; set; } //	string	Gift message	Max-Length:	2048
        public int WarehouseId { get; set; }    //	integer			
        public string WarehouseName { get; set; }   //	string			
        public int QueueId { get; set; }    //	integer			
        public string ShipClass { get; set; }   //	string			
        public string Custom { get; set; }  //	string	Custom	Max-Length:	255
        public string Custom2 { get; set; }	//	string	Custom2	Max-Length:	255

    }

    public class TeapplixOrderTotals
    {
        public decimal Shipping { get; set; }   //	number	Shipping cost	
        public decimal Handling { get; set; }   //	number	Handling	
        public decimal Discount { get; set; }   //	number	Discount amount	
        public decimal Tax { get; set; }    //	number	Tax amount	
        public string Currency { get; set; }    //	string	Order currency	Pattern:
        public string PostageCurrency { get; set; } //	string	Postage currency	Pattern:
        public decimal Fee { get; set; }    //	number	Fee amount	
        public decimal Total { get; set; }	//	number	Total amount	
    }

    public class TeapplixBillingAddress
    {
        public string Name { get; set; } // string Full person's name. Either Name or Company should be set	Max-Length: 128
        public string Company { get; set; }  //string Company name.Either Name or Company should be set Max-Length: 127
        public string Street { get; set; }  //string Street address 1st line Max-Length:255
        public string Street2 { get; set; }  //string Street address 2nd line Max-Length:255
        public string State { get; set; }  //string State code or region name Max-Length:40
        public string City { get; set; }  //string The city or town name. Min-Length:1 Max-Length: 40
        public string ZipCode { get; set; }  //string ZIP or Postal Code 
        public string CountryCode { get; set; }  //string  2 letter ISO code.Default US Pattern: [A-Z]{ 2}  Min-Length:2  Max-Length:2
    }

    public class TeapplixShippingAddress
    {
        public string Name { get; set; } // string Full person's name. Either Name or Company should be set	Max-Length: 128
        public string Company { get; set; }  //string Company name.Either Name or Company should be set Max-Length: 127
        public string Street { get; set; }  //string Street address 1st line Max-Length:255
        public string Street2 { get; set; }  //string Street address 2nd line Max-Length:255
        public string State { get; set; }  //string State code or region name Max-Length:40
        public string City { get; set; }  //string The city or town name. Min-Length:1 Max-Length: 40
        public string ZipCode { get; set; }  //string ZIP or Postal Code 
        public string Country { get; set; }  //string Country name.Default United States 
        public string CountryCode { get; set; }  //string  2 letter ISO code.Default US Pattern: [A-Z]{ 2}  Min-Length:2  Max-Length:2
        public string PhoneNumber { get; set; }  //string Phone number in any format.Can be changed based on carrier Max-Length:20
        public string Email { get; set; }    //string Email if known
        public bool SkipAddressValidation { get; set; }
    }

    public class TeapplixOrderResponse
    {
        public List<TeapplixOrderResult> OrdersResult { get; set; }
    }

    public class TeapplixOrderResult
    {
        public string TxnId { get; set; }
        /// <summary>
        /// Valid Values: Accepted,Declined,Exists,Processed. For Order PUT request, look for Accepted result.
        /// </summary>
        public string Status { get; set; }
        public string Message { get; set; }
    }
}