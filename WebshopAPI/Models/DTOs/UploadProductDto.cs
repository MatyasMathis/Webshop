﻿namespace WebshopAPI.Models.DTOs
{
    public class UploadProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}