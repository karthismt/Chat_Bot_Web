using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class CommonModelcs
    {  
       

    }

    public class chatbot
    {
        [Key]
        public int QID { get; set; }

        public string Desc { get; set; }

        public int? ParentId { get; set; }

        public int? ContactId { get; set; }

        public int? LevelId { get; set; }

        public int? IsHeader { get; set; }

    }

    public class ContactInfromation
    {
        [Key]
        public int? id { get; set; }

        public string name { get; set; }

        public string Address { get; set; }

        public string website { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

    }
}