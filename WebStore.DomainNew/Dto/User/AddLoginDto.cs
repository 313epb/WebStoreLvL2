﻿using Microsoft.AspNetCore.Identity;

namespace WebStore.DomainNew.Dto.User
{
    public class AddLoginDto
    {
        public Entities.User User { get; set; }
        
        public UserLoginInfo UserLoginInfo { get; set; }
    }
}