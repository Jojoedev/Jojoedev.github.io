using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMgtApp.Models
{
    public static class Logs
    {
        
        public static bool MyLog(this ItemCategory item, StockItem stockItem)
        {
            var stock = item.Name;
            return true;
                        
        }

        public static string SuccessMsg(StockItem item)
        {
            bool success = true;
            if (success)
            {
               var msg = $"{item.Category} was successfully received";
                return msg;
            }
            else
            {
               var msg = $"{item.Category} was not successful";
                return msg;
            }
                       
        }
        

    }
}
