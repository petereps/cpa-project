﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace cpamvc.Models
{
    public class Company
    {
        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("market")]
        public string Market { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }

        public Company() { }

        public Company(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public Company(int ID, string Name, string Description)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
        }

        public Company(int ID, string Name, string Description, string Market, string Symbol)
        {
            this.ID = ID;
            this.Name = Name;
            this.Description = Description;
            this.Market = Market;
            this.Symbol = Symbol;
        }

        public static List<Company> getCompanies()
        {
            SqlConnection sqlConn = new SqlConnection("Server=localhost;Database=cpa;Trusted_Connection=True;");
            List<Company> companies = new List<Company>();

            try
            {
                sqlConn.Open();
                SqlDataReader myReader = null;
                SqlCommand sqlCmd = new SqlCommand("SELECT id, name, description, market, symbol FROM company", sqlConn);
                myReader = sqlCmd.ExecuteReader();
                while (myReader.Read())
                {
                    companies.Add(new Company(Int32.Parse(myReader["id"].ToString()), myReader["name"].ToString(),
                        myReader["description"].ToString(), myReader["market"].ToString(), myReader["symbol"].ToString()));
                }

                sqlConn.Close();
            }
            catch (Exception e){Console.WriteLine(e.ToString());}
            return companies;
        }
           
    }

    
}