﻿using static System.Net.Mime.MediaTypeNames;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace DigitalProducts.Domain.Models
{
    public class User
    {

        
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
    	public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    	public int Role { get; set; }   
    }
}
