namespace Test.data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class searchResult
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string BloodGroup { get; set; }
        public string Ccity { get; set; }
        public string Cvillage { get; set; }
        public DateTime? DOB { get; set; }
        public string Department { get; set; }
        public string Gender { get; set; }
        public string Profession { get; set; }
        public string MaritulStatus { get; set; }
        public string Cdistrict { get; set; }
        public string Czip { get; set; }
        public DateTime? CreatedDate { get; set;}
        public DateTime? LastActivityDate { get; set;}
        public int TotalCount { get; set;}
        public int PageSize { get; set; }

    }
}