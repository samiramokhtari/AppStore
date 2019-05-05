using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumer { get; set; }
        public string MobileNumber { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<UserDownload> UserDownloads { get; set; }
    }
}
