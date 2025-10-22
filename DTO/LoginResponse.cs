using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LoginResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = false;
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
