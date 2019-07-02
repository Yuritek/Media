using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class DtTech
    {
        public string DtBaseObjectUid { get; set; }
        public short Version { get; set; }
        public DateTime EntryDate { get; set; }
        public int? AutorId { get; set; }
        public int? FkRefExpositionTypeId { get; set; }
        public int? FkRefSideTypeId { get; set; }
        public int? FkRefSideId { get; set; }
        public int? FkRefSizeId { get; set; }
        public short? FkRefConstrTypeId { get; set; }
        public int? FkVRefInstallationTypeId { get; set; }
        public int? FkVRefPlacementTypeId { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public string Requirements { get; set; }
        public string Image { get; set; }
        public string Materials { get; set; }
        public byte? Light { get; set; }
        public double? Param01 { get; set; }
        public double? Param02 { get; set; }
        public double? Param03 { get; set; }
        public double? Param04 { get; set; }

        public DtBase DtBaseObjectU { get; set; }
    }
}
