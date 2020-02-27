using System;
using System.Collections.Generic;

namespace MyFortAPI.Data
{
    public partial class Outlets
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public int LastModifiedBy { get; set; }

        public virtual Users LastModifiedByNavigation { get; set; }
    }
}
