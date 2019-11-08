using RadniSati.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace RadniSati.Controllers
{
    public class IzbornikController : Controller
    {

        Baza RadniSati = new Baza(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RadniSati;Integrated Security=True;User ID=ROSANA\rosana;Password=;");
        SqlConnection cnn;

        // GET: Izbornik
        public ViewResult Izbornik()
        {
            return View();
        }


        [HttpPost]
        public ViewResult Provjera(FormCollection form)
        {

            string username = form["Username"];
            ViewBag.username = form["Username"];
            //proslijediti na sljedeći ViewResult
            TempData["Username"] = form["Username"];
            //Debug.WriteLine(username);
            string password = form["Password"];
            //Debug.WriteLine(password);


            //connect na bazu
            cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
            cnn.Open();

            SqlCommand command = new SqlCommand("IF EXISTS (SELECT * FROM dbo.Login WHERE Username = @username AND Password=@password) SELECT 1 ELSE SELECT 2", cnn);

            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);

            int result = command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {


                    if (string.IsNullOrEmpty(username) != string.IsNullOrEmpty(password))
                    {

                        ModelState.AddModelError("Login", "Upiši username i password!");

                    }
                    else
                    {
                        ModelState.AddModelError("Login", "Obavezno upiši sve podatke!");
                    }


                    Debug.WriteLine("{0}", reader[0]);

                    if (reader[0].ToString() == "1")
                    {
                        return View("~/Views/Izbornik/Izbornik.cshtml");
                    }

                    else
                    {

                        return View("~/Views/Prijava/Index.cshtml");
                    }

                }
            }


            Debug.WriteLine("Connection Closed!");
            cnn.Close();



            return View();
        }





    }
}