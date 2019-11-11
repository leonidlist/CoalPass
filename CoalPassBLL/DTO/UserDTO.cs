using System;
using System.Collections.Generic;
using System.Text;

namespace CoalPassBLL.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Theme { get; set; }
        public string ImageLink { get; set; }
        public IEnumerable<RecordDTO> Records { get; set; }
    }
}
