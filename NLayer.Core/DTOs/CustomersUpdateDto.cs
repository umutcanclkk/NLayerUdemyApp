﻿namespace NLayer.Core.DTOs
{
    public class CustomersUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string E_Mail { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime UpdatedDate {  get; set; }
    }
}
