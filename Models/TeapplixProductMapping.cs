using System;
using System.Collections.Generic;
using System.Text;

namespace TeapplixAPIAccess.Models
{
    public class TeapplixProductMappings
    {
        /// <summary>
        /// Product Mappings to be inserted
        /// </summary>
        public List<TeapplixProductMapping> ProductXrefs { get; set; }
        /// <summary>
        /// Auto Cleanup flag. false = reject on any issue; true = copy or create of target, followed by deep delete of source, reject if target is QB inventory
        /// </summary>
        public bool AutoCleanup { get; set; }
    }

    public class TeapplixProductMapping
    {
        /// <summary>
        /// This is your channel specific SKU
        /// </summary>
        public string SourceItemName { get; set; }
        /// <summary>
        /// This is ideally your ERP SKU
        /// </summary>
        public string TeapplixSKU { get; set; }
    }

    public class TeapplixProductMappingResponse
    {
        /// <summary>
        /// Product mapping operation details
        /// </summary>
        public List<TeapplixProductMappingResponseDetail> ProductXrefs { get; set; }
    }

    public class TeapplixProductMappingResponseDetail
    {
        /// <summary>
        /// This is your channel specific SKU. Max-Length: 40
        /// </summary>
        public string SourceItemName { get; set; }
        /// <summary>
        /// This is ideally your ERP SKU. Max-Length: 40
        /// </summary>
        public string TeapplixSKU { get; set; }
        /// <summary>
        /// Indicates API success or failure. true | false
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Indicate error code or 0 if success. Codes list and description are located on help page http://www.teapplix.com/help/?page_id=7115
        /// </summary>
        public Nullable<int> Code { get; set; }
        public string Message { get; set; }
    }
}
