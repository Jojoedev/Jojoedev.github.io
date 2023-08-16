
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StockMgtApp.Models
{
    public static class Logger
    {
        public static string ActionMethod { get; set; } 
        public static string SetAction(string operation)
        {
           
            if (operation == "Delete")
            {
                ActionMethod = "Delete";
            }
            else if (operation == "Issue")
            {
                ActionMethod = "Issue";
            }
            else if (operation == "Receive")
            {
                ActionMethod = "Receive";
            }
            return ActionMethod;
        }

        public static string Log(StockItem stockitem)
        {

            //string Name;
            string Quantity;
            string UnitCost;
            string TotalCost;
            string IssueOut;
            string Stockbalance;
            string CurrentBalance;


            //Name = stockitem.Category.Name;
            Quantity = stockitem.Quantity.ToString();
            UnitCost = stockitem.Unitprice.ToString();
            TotalCost = stockitem.Total.ToString();
            IssueOut = stockitem.IssueOut.ToString();
            Stockbalance = stockitem.StockBalance.ToString();
            CurrentBalance = stockitem.NewTotal.ToString();


            DateTime date = DateTime.Now;

            string newdata = string.Format($"Name: {stockitem.Category.Name} \n Quantity: {Quantity}, " +
                $"\n Cost/Unit: {UnitCost}," + $"\n Current Issue: {IssueOut} \n Stock Balance: {Stockbalance}, " +
                $"\n IssuedToDate:{CurrentBalance} \n Date/Time: {date} \n, \n");


            //Logger.SetAction("Delete");


            string Issu = "Issue";
            //string Del = "Delete";
            //  string Receive = "Receive";


            //var filepath = @"C:\Users\HP\Desktop\Log\Issue.csv";
            var filepath = $@"C:\Users\HP\Desktop\CSharp projects\StockMgtApp\StockMgtApp\StockMgtApp\wwwroot\Warehouse\{Issu}" + ".csv";

            File.AppendAllText(filepath, newdata);


            return newdata;

        }

        public static void Download()
        {
            var file = new FileInfo(@"C:\Users\HP\Desktop\Log\REPORT.xlsx"); //This will give null reference error at sheet.Cell point if REPORT sample/template of .xlsx format was not in the Log folder.
            using(ExcelPackage excel = new ExcelPackage(file))
            {
                
                ExcelWorksheet sheet = excel.Workbook.Worksheets["sheet1"];
                string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Database=Requests; Initial Catalog = STOCKMGTReport; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
                SqlConnection conn = new SqlConnection(connectionString);
                conn.Open();
                var command = new SqlCommand("select * from dbo.STOCKMGT", conn); 
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                int count = dataTable.Rows.Count;
                sheet.Cells.LoadFromDataTable(dataTable, true);
                FileInfo excelFile = new FileInfo(@"C:\Users\HP\Desktop\Log\rep.xlsx");
                excel.SaveAs(excelFile);



            
            }


                

        }
    }
}
