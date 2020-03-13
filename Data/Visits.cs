using System;
using System.Collections.Generic;

namespace MyFortAPI.Data
{
    public partial class Visits
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OutletId { get; set; }
        public DateTime VisitedOn { get; set; }
        public string MeetingWith { get; set; }
        public string Notes { get; set; }

        public virtual Outlets Outlet { get; set; }
        public virtual Users User { get; set; }
    }
}
