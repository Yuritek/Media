using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class RefPartners
    {
        public int PartnerId { get; set; }
        public int? FkRefPartnerId { get; set; }
        public string PartnerName { get; set; }
        public string PartnerNameFull { get; set; }
        public string Synonyms { get; set; }
        public int StatusId { get; set; }
        public bool IsClient { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsOpex { get; set; }
        public bool IsCompetitor { get; set; }
        public bool IsCarrier { get; set; }
        public int MainEmployerId { get; set; }
        public bool WithoutContractSupplier { get; set; }
        public bool WithoutContractClient { get; set; }
        public int? CategoryClntId { get; set; }
        public int? CategorySuppId { get; set; }
        public bool IsPrivatePerson { get; set; }
        public string PpSex { get; set; }
        public DateTime? PpBirthday { get; set; }
        public string Keywords { get; set; }
        public string CategoryClntComment { get; set; }
        public string CategorySuppComment { get; set; }
        public string Comments { get; set; }
        public string Conditions { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public bool Deleted { get; set; }
    }
}
