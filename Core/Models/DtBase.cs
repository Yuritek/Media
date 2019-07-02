using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class DtBase
    {
        public DtBase()
        {
            DtTech = new HashSet<DtTech>();
        }

        public string ObjectUid { get; set; }
        public string ObjectUidOper { get; set; }
        public string DtGeoObjectGeoUid { get; set; }
        public short? FkRefMediaTypeId { get; set; }
        public int? FkRefMediaNetworkId { get; set; }
        public int? FkRefPartnerId { get; set; }
        public int? FkRefUrFaceId { get; set; }
        public int? FkRefLicenseId { get; set; }
        public string LegacyId { get; set; }
        public string CommonId { get; set; }
        public string ObjectName { get; set; }
        public string Reference { get; set; }
        public string UrlPhoto { get; set; }
        public string UrlSchema { get; set; }
        public string UrlPresentation { get; set; }
        public int? AutorId { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Deleted { get; set; }
        public DateTime? DateDelete { get; set; }

        public RefMediaType FkRefMediaType { get; set; }
        public ICollection<DtTech> DtTech { get; set; }
    }
}
