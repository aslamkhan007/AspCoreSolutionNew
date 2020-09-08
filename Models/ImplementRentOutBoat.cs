using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSolution.Models
{
    public class ImplementRentOutBoat : IRentOutBoat
    {

        public IConfiguration _Configuration;

        public ImplementRentOutBoat(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
       
        public int AddRentOutBoats(RentOutBoat rentOutBoat)
        {
            var res= 0;
            string connectionString = _Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RentOutBoat_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BoatName", rentOutBoat.BoatName);
                cmd.Parameters.AddWithValue("@CustomerName", rentOutBoat.CustomerName);
                con.Open();

                res   =  cmd.ExecuteNonQuery();
                con.Close();
                
            }
            return res;
        }

        

        public IEnumerable<RentOutBoat> GetAllRentOutBoats()
        {
            List<RentOutBoat> lstCustomer = new List<RentOutBoat>();
            string connectionString = _Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RentOutBoat_FetchAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    RentOutBoat Customer = new RentOutBoat();
                    Customer.BoatName = sdr["BoatName"].ToString();
                    Customer.CustomerName = sdr["CustomerName"].ToString();
                    //Customer.RegisterId = sdr["RegisterId"].ToString();
                    lstCustomer.Add(Customer);
                }
                con.Close();
            }
            return lstCustomer;
        }
    }
}
