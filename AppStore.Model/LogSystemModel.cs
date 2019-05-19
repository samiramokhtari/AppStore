using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Models
{
    public class LogSystemModel : IEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string BeforeChange { get; set; }
        public string AfterChange { get; set; }
        public DateTime DateTime { get; set; }
        public string DateTimeShow { get; set; }
        public string FromDateTime { get; set; }
        public string ToDateTime { get; set; }
        public string Action { get; set; }
        public string ErrorMessage { get; set; }
    }
}
