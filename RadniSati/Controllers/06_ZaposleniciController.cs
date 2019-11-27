using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RadniSati.Models;

namespace RadniSati.Controllers
{
    public class ZaposleniciController : Controller
    {
        Baza RadniSati = new Baza(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RadniSati;Integrated Security=True;User ID=ROSANA\rosana;Password=;");
        SqlConnection cnn;
        private List<Zaposlenici> zaposlenik = new List<Zaposlenici>();

        // GET: Zaposlenici
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpisZaposlenika()
        {

            return View();
        }

        [HttpPost]
        public ViewResult UpisZaposlenika(FormCollection form)
        {
            TempData["ime"] = form["Ime"];
            TempData["prezime"] = form["Prezime"];
            TempData["adresa"] = form["Adresa"];
            TempData["postanskiBroj"] = form["PoštanskiBroj"];
            TempData["grad"] = form["Grad"];
            TempData["mail"] = form["Mail"];
            TempData["mobitel"] = form["Mobitel"];
            TempData["telefon"] = form["Telefon"];
            TempData["lokacija"] = form["Lokacija"];
            TempData["odjel"] = form["Odjel"];
            TempData["radnaPozicija"] = form["RadnaPozicija"];
            TempData["loginZap"] = form["LoginZap"];
            TempData["sifraProjekta"] = form["ŠifraProjekta"];
            TempData["ostalo"] = form["Ostalo"];

            Debug.WriteLine(form["LoginZap"]);
            //string logIn = TempData["loginZap"].ToString();
            //int logIn2 = Int32.Parse(logIn);

            //if (logIn2 == 1)
            //{
            //    TempData["loginZap"] = Convert.ToBoolean("True");
            //}
            //else
            //{
            //    TempData["loginZap"] = Convert.ToBoolean("False");
            //}

            //form["LoginZap"] = Convert.ToBoolean("False");
            //bool val = bool.Parse(form["LoginZap"]);

           
            //Debug.WriteLine(val);


            try
            {


                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
                cnn.Open();

                SqlCommand unos = new SqlCommand("INSERT INTO Zaposlenici VALUES (@ime, @prezime, @adresa, @postanskiBroj, @grad, @mail, @mobitel, @telefon, @lokacija, @odjel, @radnaPozicija, @loginZap, @sifraProjekta, @ostalo)", cnn);

                unos.Parameters.Add("@ime", SqlDbType.VarChar).Value = TempData["ime"];
                unos.Parameters.Add("@prezime", SqlDbType.VarChar).Value = TempData["prezime"];
                unos.Parameters.Add("@adresa", SqlDbType.VarChar).Value = TempData["adresa"];
                unos.Parameters.Add("@postanskiBroj", SqlDbType.Int).Value = TempData["postanskiBroj"];
                unos.Parameters.Add("@grad", SqlDbType.VarChar).Value = TempData["grad"];
                unos.Parameters.Add("@mail", SqlDbType.VarChar).Value = TempData["mail"];
                unos.Parameters.Add("@mobitel", SqlDbType.Int).Value = TempData["mobitel"];
                unos.Parameters.Add("@telefon", SqlDbType.Int).Value = TempData["telefon"];
                unos.Parameters.Add("@lokacija", SqlDbType.VarChar).Value = TempData["lokacija"];
                unos.Parameters.Add("@odjel", SqlDbType.VarChar).Value = TempData["odjel"];
                unos.Parameters.Add("@radnaPozicija", SqlDbType.VarChar).Value = TempData["radnaPozicija"];
                unos.Parameters.Add("@loginZap", SqlDbType.Bit).Value = TempData["loginZap"];
                unos.Parameters.Add("@sifraProjekta", SqlDbType.Int).Value = TempData["sifraProjekta"];
                unos.Parameters.Add("@ostalo", SqlDbType.Text).Value = TempData["ostalo"];
               
                unos.ExecuteNonQuery();



                cnn.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {

                Debug.WriteLine("Podaci upisani!");
            }



            return View();
         
        }

        public ActionResult IzmjenaZaposlenika()
        {
            return View();
        }

        public ActionResult IzbrisiZaposlenika()
        {
            return View();
        }
        public ActionResult PopisZaposlenika()
        {
            return View();
        }
        public ActionResult ZaposleniciReport()
        {

            try
            {



                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);

                cnn.Open();

                SqlCommand zaposliti = new SqlCommand("SELECT COUNT(*) from Zaposlenici", cnn);


                using (SqlDataReader reader = zaposliti.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),reader[3]).ToString());

                        zaposlenik.Add(new Zaposlenici(int.Parse(reader[0].ToString())/*, int.Parse(reader[1].ToString())*/));


                    }


                }


                cnn.Close();


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
            finally
            {

                Debug.WriteLine("Podaci su OK!");
            }


            return View(zaposlenik);

            return View();
        }
    }
}
