using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RadniSati.Models
{
    public class Baza
    {
        //it works
        public string connetionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=RadniSati;Integrated Security=True;User ID=ROSANA\rosana;Password=;";

        public string ConnectionString
        {
            get { return this.connetionString; }
            set { this.connetionString = value; }
        }

        public Baza(string conn)
        {
            this.connetionString = conn;
        }

    }
}