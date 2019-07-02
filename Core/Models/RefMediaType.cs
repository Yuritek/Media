using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Core.Models
{
	public partial class RefMediaType
    {
        public RefMediaType()
        {
            DtBase = new HashSet<DtBase>();
        }
		public short MediaTypeId { get; set; }
		public short FkRefMediaGroupId { get; set; }
		public string MediaType { get; set; }
		public DateTime LastUpdated { get; set; }
		public bool Deleted { get; set; }
		public ICollection<DtBase> DtBase { get; set; }
    }
}
