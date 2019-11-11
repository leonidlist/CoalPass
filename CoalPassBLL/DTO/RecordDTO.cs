using System;
using System.Collections.Generic;
using System.Text;

namespace CoalPassBLL.DTO
{
    public class RecordDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Website { get; set; }
        public int Category { get; set; }
        public string ImageUrl { get; set; }
    }
}
