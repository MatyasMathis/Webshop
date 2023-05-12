﻿namespace WebshopAPI.Models
{
    public class Category : IIdentifiableByGuid
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

       // public IEnumerable<Product> Products { get; set; }

    }
}
