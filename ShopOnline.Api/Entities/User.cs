﻿namespace ShopOnline.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public DateTime DbCreationDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public int? NumberOfLogins { get; set; }
    }
}
