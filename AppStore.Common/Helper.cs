using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Common
{
    public static class Helper
    {
        public static string MeladiToShamsi(string strMeladi)
        {
            DateTime d = DateTime.Parse(strMeladi);
            PersianCalendar pc = new PersianCalendar();

             
            return string.Format("{0}/{1}/{2}", pc.GetYear(d), (pc.GetMonth(d).ToString().Length < 2 ? "0" + pc.GetMonth(d) : pc.GetMonth(d).ToString()),(pc.GetDayOfMonth(d).ToString().Length < 2 ? "0" + pc.GetDayOfMonth(d) : pc.GetDayOfMonth(d).ToString()));
        }
    }
}
