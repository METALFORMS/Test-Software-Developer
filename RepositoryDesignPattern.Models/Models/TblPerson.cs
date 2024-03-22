using System;
using System.Collections.Generic;

namespace RepositoryDesignPattern.Models.Models
{
    public partial class TblPerson
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public long? IdInvoice { get; set; }

        public virtual TblInvoice? IdInvoiceNavigation { get; set; }
    }
}
