using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class ViewModel
    {
        public string headerinfo { get; set; }
        public List<ContectLists> ContactList { get; set; }
        public List<QuestionList> QuestionList { get; set; }
    }

    public class ContectLists
    {
        public int? Id { get; set; }
        public string name { get; set; }
        public string Address { get; set; }
        public string website { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }


    }


    public class QuestionList
    {

        public int QID { get; set; }
        public string Desc { get; set; }
        public int? ParentId { get; set; }
        public int? ContactId { get; set; }
        public int? LevelId { get; set; }
        public int? IsHeader { get; set; }

    }

}