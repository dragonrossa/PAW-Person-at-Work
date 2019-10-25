using RadniSati.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace RadniSati.Controllers
{
    public class RadniSatiController : Controller
    {
        Baza RadniSati = new Baza(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RadniSati;Integrated Security=True;User ID=ROSANA\rosana;Password=;");
        SqlConnection cnn;

        public ViewResult Index()
        {
       
            //open database
            cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
            cnn.Open();
            
            Debug.WriteLine("Connection Open!");
            cnn.Close();

            return View();
        }


        // GET: RadniSati
        public ViewResult UnosSati()
        {
           
            return View();
        }

        [HttpPost]
        public ViewResult UnosSati(FormCollection form)
        {
            string username = form["Username"];
            Debug.WriteLine(username);
            string password = form["Password"];
            Debug.WriteLine(password);
            cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
            cnn.Open();
            
            SqlCommand command = new SqlCommand("  IF EXISTS (SELECT * FROM dbo.Login WHERE Username = @username AND Password=@password) SELECT 1 ELSE SELECT 2", cnn);
            
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            int result = command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                  
                    Debug.WriteLine("{0}", reader[0]);

                    if (reader[0].ToString() == "1")
                    {
                        return View("UnosSati");
                    }
                    else
                    {
                        return View("Index");
                    }

                }
            }


            Debug.WriteLine("Connection Closed!");
            cnn.Close();



        
            return View();
        }



        public ActionResult IspisSati(FormCollection form)
        {
            
            ViewBag.ulazak = form["Ulazak"];
            ViewBag.izlazak = form["Izlazak"];
            DateTime date1 = DateTime.ParseExact(ViewBag.ulazak, "dd'.'MM'.'yyyy - HH:mm:ss", null);
            DateTime date2 = DateTime.ParseExact(ViewBag.izlazak, "dd'.'MM'.'yyyy - HH:mm:ss", null);
            TimeSpan interval = date2 - date1;
            ViewBag.interval = interval;
            TimeSpan span = new TimeSpan(08, 00, 00);
            TimeSpan visak = interval - span;
            ViewBag.visak = visak;
            return View();
        }
    }
}