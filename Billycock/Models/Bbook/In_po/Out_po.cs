using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegracionBbook.Api.Models.In_po
{
    public class Out_Po
    {
        public int id_document { get; set; }
        public string purchase_order { get; set; }
        public List<Label> label { get; set; }

        public class Label
        {
            public string Desc1 { get; set; }
            public string Desc2 { get; set; }
            public string Line { get; set; }
        }
    }
}
