using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuestRooms.UI.Models
{
    public class UserRegisterModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}