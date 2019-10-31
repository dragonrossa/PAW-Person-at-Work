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




        public ViewResult Izbornik()
        {

            return View();
        }



        [HttpPost]
        public ActionResult Izbornik(FormCollection form)
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
                        return View("Izbornik");
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


       
        public ViewResult UnosSati()
        {
           
            return View();
        }



        public ActionResult IspisSati(FormCollection form)
        {
            
            ViewBag.ulaz = form["Ulazak"];
            ViewBag.izlaz = form["Izlazak"];


            DateTime date1 = DateTime.ParseExact(ViewBag.ulaz, "yyyy'-'MM'-'dd'T'HH':'mm':'ss", null);
            DateTime date2 = DateTime.ParseExact(ViewBag.izlaz, "yyyy'-'MM'-'dd'T'HH':'mm':'ss", null);



            string Ulazak = DateTime.Now.ToString("yyyy'-'MM'-'dd HH:mm:ss");
            string Izlazak = DateTime.Now.AddHours(8).ToString("yyyy'-'MM'-'dd HH:mm:ss");

            string datum = date1.ToString("dd-MM-yyyy"); //unos u bazu - datum
            string ul = date1.ToString("yyyy-MM-dd HH:mm:ss"); //unos u bazu - ulazni broj
            string iz = date2.ToString("yyyy-MM-dd HH:mm:ss"); //unos u bazu - izlazni broj

            string ul2 = date1.ToString("dd-MM-yyyy") + " u " + date1.ToString("HH:mm:ss");
            string iz2 = date2.ToString("dd-MM-yyyy") + " u " + date2.ToString("HH:mm:ss");


            Debug.WriteLine(datum);
            Debug.WriteLine(ul);
            Debug.WriteLine(iz);


            TempData["Datum"] = datum;
            TempData["Ulazak"] = ul;
            TempData["Izlazak"] = iz;


            var usCulture = new CultureInfo("en-US");
            var date3 = date1;
            var date4 = date2;
            var gmt1Date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date3, "W. Europe Standard Time");
            var gmt2Date = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(date4, "W. Europe Standard Time");
            var str1 = gmt1Date.ToString("dd MMM yyyy HH:mm:ss", usCulture);
            var str2 = gmt2Date.ToString("dd MMM yyyy HH:mm:ss", usCulture);


            ViewBag.ulazak = ul2;
            ViewBag.izlazak = iz2;
          
            TimeSpan interval = date4 - date3;
            ViewBag.interval = interval; //unos u bazu - ukupan broj sati
            TimeSpan span = new TimeSpan(08, 00, 00);
            TimeSpan visak = interval - span; 
            ViewBag.visak = visak;  //unos u bazu - visak, razlika

            TempData["Razlika"] = interval;
            TempData["Visak"] = visak; 


            //connect na bazu
            cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
            cnn.Open();

            SqlCommand command = new SqlCommand("SELECT u.Šifra, u.ImeZaposlenika,u.PrezimeZaposlenika, u.TipZaposlenika from dbo.UnosSati u JOIN dbo.Login l on u.Šifra=l.ŠifraZaposlenika WHERE l.Username=@username", cnn);

            command.Parameters.AddWithValue("@username", TempData["Username"]);
       

            int result = command.ExecuteNonQuery();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {

                    TempData["sifra"] = reader[0].ToString();
                    TempData["ime"] = reader[1].ToString();
                    TempData["prezime"] = reader[2].ToString();
                    TempData["tipZaposlenika"] = reader[3].ToString();

                }
            }


            Debug.WriteLine("Connection Closed!");
            cnn.Close();

            Debug.WriteLine(TempData["Sifra"]);  //sifra za unos
            Debug.WriteLine(TempData["Ime"]);  //ime za unos
            Debug.WriteLine(TempData["Prezime"]); //prezime za unos
            Debug.WriteLine(TempData["Datum"]); //datum za unos
            Debug.WriteLine(TempData["Ulazak"]); //ulazak za unos
            Debug.WriteLine(TempData["Izlazak"]); //izlazak za unos
            Debug.WriteLine(TempData["Razlika"]); //razlika za unos
            Debug.WriteLine(TempData["Visak"]); //visak za unos
            Debug.WriteLine(TempData["TipZaposlenika"]); //tip zaposlenika za unos



            //Upis u tablicu podatke o korisniku

            try
            {


                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
            cnn.Open();

            SqlCommand unos = new SqlCommand("INSERT INTO dbo.UnosSati VALUES(@sifra,@imeZaposlenika,@prezimeZaposlenika,@datum,@ulazak, @izlazak,@razlika,@visak,@tipZaposlenika)", cnn);

            unos.Parameters.Add("@sifra", SqlDbType.Int).Value = TempData["Sifra"];
            unos.Parameters.Add("@imeZaposlenika", SqlDbType.NChar).Value = TempData["Ime"];
            unos.Parameters.Add("@prezimeZaposlenika", SqlDbType.NChar).Value = TempData["Prezime"];
            unos.Parameters.Add("@datum", SqlDbType.Date).Value = TempData["Datum"];
            unos.Parameters.Add("@ulazak", SqlDbType.DateTime).Value = TempData["Ulazak"];
            unos.Parameters.Add("@izlazak", SqlDbType.DateTime).Value = TempData["Izlazak"];
            unos.Parameters.Add("@razlika", SqlDbType.Time).Value = TempData["Razlika"];
            unos.Parameters.Add("@visak", SqlDbType.Time).Value = TempData["Visak"];
            unos.Parameters.Add("@tipZaposlenika", SqlDbType.NChar).Value = TempData["tipZaposlenika"];
            unos.ExecuteNonQuery();


           
            cnn.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally {

                Debug.WriteLine("Podaci upisani!");
            }

            return View();

           
        }
    }
}