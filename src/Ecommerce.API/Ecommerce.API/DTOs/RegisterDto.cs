﻿namespace Ecommerce.API.DTOs
{
    public class RegisterDto
    {
      public string FullName { get; set; }
      public DateTime? BirthDate { get; set; }
      public string Email { get; set; }
      public string Password { get; set; }
    }
}

