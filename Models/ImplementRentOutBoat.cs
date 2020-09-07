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
       
        public RegisterBoat AddRentOutBoats(RegisterBoat rentOutBoat)
        {
            string connectionString = _Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RegisterBoat_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BoatName", rentOutBoat.BoatName);
                cmd.Parameters.AddWithValue("@BoatSpeed", rentOutBoat.BoatSpeed);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return rentOutBoat;
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
                    //Customer.BoatName = sdr["BoatName"].ToString();
                    Customer.CustomerName = sdr["CustomerName"].ToString();
                    Customer.RegisterId = sdr["RegisterId"].ToString();
                    lstCustomer.Add(Customer);
                }
                con.Close();
            }
            return lstCustomer;
        }
    }
}
