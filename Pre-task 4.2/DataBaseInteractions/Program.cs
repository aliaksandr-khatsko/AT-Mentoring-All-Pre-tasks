using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.Common;
using System.Data;
using Microsoft.SqlServer.Server;
using System.Data.SqlTypes;

namespace DataBaseInteractions
{
    class Program
    {
        static void Main(string[] args)
        {

            bool appliactionNeverStop = false;

            do
            {
                Console.WriteLine("Northwind managment tool is launched");
                Console.WriteLine();
                Console.WriteLine("To review sales by category please enter CategotySales and press Enter");
                Console.WriteLine();
                Console.WriteLine("To review sales by category please enter RegionSales and press Enter");
                Console.WriteLine();
                Console.WriteLine("To add region please enter AddRegion and press Enter");
                Console.WriteLine();
                Console.WriteLine("To update customer phone please enter UpdatePhone and press Enter");
                Console.WriteLine();
                Console.WriteLine("To delete Order Details for specific order enter DeleteDetails and press Enter");
                Console.WriteLine();

                bool correctCommand = false;
                string userChoiceFirstMenu = Console.ReadLine();
                do
                {
                    if (String.Equals(userChoiceFirstMenu, "CategotySales"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "RegionSales"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "AddRegion"))
                    {
                        correctCommand = true;
                    }

                    else if (String.Equals(userChoiceFirstMenu, "UpdatePhone"))
                    {
                        correctCommand = true;
                    }
                    else if (String.Equals(userChoiceFirstMenu, "DeleteDetails"))
                    {
                        correctCommand = true;
                    }

                    else
                    {
                        Console.WriteLine("Wrong command, choose from the following options (CategotySales, RegionSales, AddRegion, UpdatePhone, DeleteDetails)");

                        userChoiceFirstMenu = Console.ReadLine();
                    }
                } while (correctCommand == false);

                switch (userChoiceFirstMenu)
                {
                    case "CategotySales":
                        Console.WriteLine("Enter Category name and press Enter(For example Seafood)");
                        SqlString categoryName1 = Console.ReadLine();
                        Console.WriteLine("Enter Orders Year and press Enter(For example 1998)");
                        SqlString ordYear = Console.ReadLine();
                        StoredProcedures.ShowSalesByCategory(categoryName1, ordYear);
                        break;
                    case "RegionSales":
                        Requests.SelectOrderNumberByRegion();
                        break;
                    case "AddRegion":
                        using (var connectionAdd = new SqlConnection())
                        {
                            Console.WriteLine("Connection object --> " + connectionAdd.GetType().Name);
                            connectionAdd.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
                            try
                            {
                                connectionAdd.Open();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message); ;
                            }
                            Console.WriteLine("Enter Region ID and press Enter");
                            string regionEnteredID = Console.ReadLine();
                            Console.WriteLine("Enter region description and press Enter");
                            string regionEnteredDescription = Console.ReadLine();
                            Console.WriteLine("Regions added {0}", Requests.InsertRegion(regionEnteredID, regionEnteredDescription, connectionAdd));
                        }
                        break;
                    case "UpdatePhone":
                        using (var connectionUpdate = new SqlConnection())
                        {
                            Console.WriteLine("Connection object --> " + connectionUpdate.GetType().Name);
                            connectionUpdate.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
                            try
                            {
                                connectionUpdate.Open();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message); ;
                            }
                            Console.WriteLine("Enter Customer ID and press Enter");
                            string customerEnteredID = Console.ReadLine();
                            Console.WriteLine("Enter a phone number and press Enter");
                            string customerEnteredPhonw = Console.ReadLine();
                            Console.WriteLine("Phones updated {0}", Requests.UpdateCustomerPhone(customerEnteredID, customerEnteredPhonw, connectionUpdate));
                        }
                        break;
                    case "DeleteDetails":
                        using (var connectionDelete = new SqlConnection())
                        {
                            Console.WriteLine("Connection object --> " + connectionDelete.GetType().Name);
                            connectionDelete.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
                            try
                            {
                                connectionDelete.Open();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message); ;
                            }
                            Console.WriteLine("Enter Order ID and press Enter");
                            string orderEnteredID = Console.ReadLine();
                            Console.WriteLine("Phones updated {0}", Requests.DeleteOrderDetails(orderEnteredID, connectionDelete));
                        }
                        break;
                    default:
                        break;
                }
            } while (appliactionNeverStop == false);

        }
    }

    public class Requests
    {

        public static void SelectOrderNumberByRegion()
        {
            using (var connection = new SqlConnection())
            {
                Console.WriteLine("Connection object --> " + connection.GetType().Name);
                connection.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }

                DbCommand cmd = new SqlCommand();
                Console.WriteLine("Command object --> " + cmd.GetType().Name);
                Console.WriteLine();
                cmd.Connection = connection;
                cmd.CommandText = @"SELECT [RegionDescription], COUNT(o.OrderID) as OrderNumber
                                    FROM [northwind].[dbo].[Orders] as o
                                    join [northwind].[dbo].[Employees]  as e
                                    on o.EmployeeID = e.EmployeeID
                                    join [northwind].[dbo].[EmployeeTerritories] as et
                                    on e.EmployeeID = et.EmployeeID
                                    join [northwind].[dbo].[Territories] as ter
                                    on et.TerritoryID = ter.TerritoryID
                                    join [northwind].[dbo].[Region] as reg
                                    on reg.RegionID = ter.RegionID
                                    group by [RegionDescription]";

                var regions = new DataTable();
                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Console.WriteLine(
                            "Region: {0}, OrderNumber: {1}\n",
                            dr["RegionDescription"],
                            dr["OrderNumber"]);
                    }
                }
                connection.Close();
            }
        }

        public static int InsertRegion(string regionID, string regionDescription, SqlConnection connectionInsert)
        {
            
                int numberOfAffectedRows = 0;
                string insertRequest = string.Format(@"INSERT INTO [dbo].[Region] ([RegionID] ,[RegionDescription]) VALUES ({0}, '{1}');", regionID, regionDescription);
                DbCommand cmd = new SqlCommand(insertRequest, connectionInsert);
                try
                {
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    var error = new Exception("Region cannot be added");
                    Console.WriteLine(error.Message);
                }
                return numberOfAffectedRows;

        }

        public static int DeleteOrderDetails(SqlString orderID, SqlConnection connectionDelete)
        {

                int numberOfAffectedRows = 0;
                string deleteRequest = string.Format("Delete from [northwind].[dbo].[Order Details] where [OrderId] = '{0}'", orderID);
                using (DbCommand cmd = new SqlCommand(deleteRequest, connectionDelete))
                {
                    try
                    {
                        numberOfAffectedRows = cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        var error = new Exception("Customer cannot be deleted");
                        Console.WriteLine(error.Message);
                    }
                    return numberOfAffectedRows;
                }
            
        }

        public static int UpdateCustomerPhone(string customerID, string customerPhone, SqlConnection connectionUpdate)
        {
            
                int numberOfAffectedRows = 0;
                string insertRequest = string.Format(@"UPDATE [dbo].[Customers] SET [Phone] = '{0}' WHERE [CustomerID] = '{1}'", customerPhone, customerID);
                DbCommand cmd = new SqlCommand(insertRequest, connectionUpdate);
                try
                {
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    var error = new Exception("Phone cannot be updated");
                    Console.WriteLine(error.Message);
                }
                return numberOfAffectedRows;

        }
        

    }

    public class StoredProcedures
     {
 
         public static void ShowSalesByCategory(SqlString categoryName, SqlString orderYear)
         {
             var salesByCategory = new DataTable();
             using (SqlConnection cn = new SqlConnection())
             {
                 Console.WriteLine("Connection object --> " + cn.GetType().Name);
                 Console.WriteLine();
                 cn.ConnectionString = ConfigurationManager.AppSettings["connectionString"];
                 try
                 {
                     cn.Open();
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message); ;
                 }
                 using (SqlCommand DisplaySalesByCategory = new SqlCommand("SalesByCategory", cn))
                 {
                     DisplaySalesByCategory.CommandType = CommandType.StoredProcedure;
                     SqlParameter categoryNameParameter = new SqlParameter("@CategoryName", SqlDbType.NVarChar, 15);
                     SqlParameter orderYearParameter = new SqlParameter("@OrdYear", SqlDbType.NVarChar, 4);

                     categoryNameParameter.Value = categoryName;
                     orderYearParameter.Value = orderYear;

                     DisplaySalesByCategory.Parameters.Add(categoryNameParameter);
                     DisplaySalesByCategory.Parameters.Add(orderYearParameter);
                     DisplaySalesByCategory.Connection = cn;

                     var dataRead = DisplaySalesByCategory.ExecuteReader();
                     salesByCategory.Load(dataRead);

                     foreach (DataRow row in salesByCategory.Rows)
                     {
                         Console.WriteLine(
                             "-> ProductName: {0}, TotalPurchase: {1}\n", row["ProductName"], row["TotalPurchase"]);
                     }
                 }
                 
                 cn.Close();
             }
         }      
    }
       
}