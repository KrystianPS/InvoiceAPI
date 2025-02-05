﻿using System.ComponentModel.DataAnnotations;

namespace InvoiceAPI.Models.CompanyModel
{
    public class CreateCompanyContactDetails
    {
        [Required]
        [Phone]
        public required string Phone { get; set; }
        [Required]
        [EmailAddress]
        public required string EmailAddress { get; set; }
    }
}
