using System;
using System.Collections.Generic;

#nullable disable

namespace Mikeys_Mummy.Model
{
    public partial class Analysis
    {
        public long Id { get; set; }
        public int? Analysistype { get; set; }
        public string Doneby { get; set; }
        public int? Analysisid { get; set; }
        public DateTime? Date { get; set; }
    }
}
