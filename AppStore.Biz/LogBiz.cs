using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppStore.Biz
{
    public  class LogBiz<T> 
    {
        public  string GetProperites(T obj)
        {
            try
            {
                if (obj == null)
                    return "null";
                IList<PropertyInfo> props = obj.GetType().GetProperties();
                string log = "";
                foreach (PropertyInfo prop in props)
                {
                    if (prop != null && prop.GetValue(obj, null) != null)
                        log += prop.Name + ":" + prop.GetValue(obj, null).ToString() + ",";

                }
                return log.Substring(0, log.Length - 1);
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}
