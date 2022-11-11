using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Findergers1._0.Models
{
    public partial class Missing
    {
        public int IdMissing { get; set; }
        [Display(Name = "Name")]
        public string? NameMissing { get; set; }
        [Display(Name = "Age")]
        public int? AgeMissing { get; set; }
        [Display(Name = "Description")]
        public string? DescriptionMissing { get; set; }
        [Display(Name = "Date of disappearance")]
        public DateTime? DateMissing { get; set; }
        public string? ImageMissing { get; set; }
        [Display(Name = "Last Location")]
        public string? LastlocationMissing { get; set; }
    }
}
