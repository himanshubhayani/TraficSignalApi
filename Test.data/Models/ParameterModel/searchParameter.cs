namespace Test.data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class searchParameter
    {
        public searchParameter()
        {
            columns = new List<SearchColumnName>();
            order = new List<SearchColumnOrderinfo>();
        }
        public Int32 Draw { get; set; }
        public Int32 PageNum { get; set; }
        public int PageSize { get; set; }
        public string orderColumnName { get; set; }
        public string orderColumnDir { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Ccity { get; set; }
        public string Cdistrict { get; set; }
        public string Cvillage { get; set; }
        public string Czip { get; set; }
        public string Profession { get; set; }
        public string BloodGroup { get; set; }
        public string Gender {get; set;}
        public string Male {get; set;}
        public string Female {get; set;}
        public List<SearchColumnName> columns { get; set; }
        public List<SearchColumnOrderinfo> order { get; set; }
    }

    public class SearchColumnName
    {
        public string data { get; set; }
    }

    public class SearchColumnOrderinfo
    {
        public string column { get; set; }
        public string dir { get; set; }
    }
}