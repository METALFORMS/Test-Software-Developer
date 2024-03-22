using System;
using System.Collections.Generic;

namespace RepositoryDesignPattern.Models.Models
{
    public partial class TblInvoice
    {
        public TblInvoice()
        {
            TblPeople = new HashSet<TblPerson>();
        }

        public long Id { get; set; }
        public string? Date { get; set; }
        public string? Amount { get; set; }

        public virtual ICollection<TblPerson> TblPeople { get; set; }
    }
}
