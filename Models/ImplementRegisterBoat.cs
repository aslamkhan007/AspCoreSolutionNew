using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreSolution.Models
{
    public class ImplementRegisterBoat : IRegisterBoat
    {
        public IConfiguration _Configuration;

        public ImplementRegisterBoat(IConfiguration configuration )
        {
            _Configuration = configuration;
        }
        public string AddBoats(RegisterBoat registerBoat)
        {
            string message = "";
            string connectionString = _Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                SqlCommand cmd = new SqlCommand("RegisterBoat_Add", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@BoatName", registerBoat.BoatName);
                cmd.Parameters.AddWithValue("@BoatSpeed", registerBoat.BoatSpeed);
                cmd.Parameters.Add("@SeriesCode", SqlDbType.Char, 500);
                cmd.Parameters["@SeriesCode"].Direction = ParameterDirection.Output;
                con.Open();
                cmd.ExecuteNonQuery();
                message = (string)cmd.Parameters["@SeriesCode"].Value;
                con.Close();
            }
            return message;
        }
       
        public IEnumerable<RegisterBoat> GetAllBoats()
        {
            List<RegisterBoat> lstCustomer = new List<RegisterBoat>();
            string connectionString = _Configuration["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("RegisterBoat_FetchAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    RegisterBoat Customer = new RegisterBoat();
                    Customer.BoatName = sdr["BoatName"].ToString();
                    Customer.BoatSpeed = Convert.ToDecimal(sdr["BoatSpeed"]);
                    Customer.RegisterId = sdr["RegisterId"].ToString();                   
                    lstCustomer.Add(Customer);
                }
                con.Close();
            }
            return lstCustomer;
           
        }

    }
}
