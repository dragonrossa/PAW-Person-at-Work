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
    public class ProjektController : Controller
    {
        Baza RadniSati = new Baza(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=RadniSati;Integrated Security=True;User ID=ROSANA\rosana;Password=;");
        SqlConnection cnn;

        // GET: Projekt
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UpisProjekta()
        {
            return View();
        }

        [HttpPost]
        public ViewResult UpisProjekta(FormCollection form)
        {
            string naziv = form["Naziv"];
            string opis = form["Opis"];
            string pm = form["PM"];
            string task = form["Task"];
            string rezultat = form["Rezultat"];
            string koordinator = form["Koordinator"];
            string klijent = form["Klijent"];
            string pocetak = form["Pocetak"];
            string kraj = form["Kraj"];
            string datum = form["Datum"];
            string budget = form["Budget"];
            string drzava = form["Drzava"];
            string imeZaposlenika = form["ImeZaposlenika"];
            string prezimeZaposlenika= form["PrezimeZaposlenika"];

          

            //ViewBag.naziv = form["Naziv"];
            Debug.WriteLine(naziv);
            Debug.WriteLine(opis);
            Debug.WriteLine(pm);
            Debug.WriteLine(task);
            Debug.WriteLine(rezultat);
            Debug.WriteLine(koordinator);
            Debug.WriteLine(klijent);
            Debug.WriteLine(pocetak);
            Debug.WriteLine(kraj);
            Debug.WriteLine(datum);
            Debug.WriteLine(budget);
            Debug.WriteLine(drzava);
            Debug.WriteLine(imeZaposlenika);
            Debug.WriteLine(prezimeZaposlenika);



            //cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
            //cnn.Open();

            //SqlCommand command = new SqlCommand("SELECT u.Šifra, u.ImeZaposlenika,u.PrezimeZaposlenika, u.TipZaposlenika from dbo.UnosSati u JOIN dbo.Login l on u.Šifra=l.ŠifraZaposlenika WHERE l.Username=@username", cnn);

            //command.Parameters.AddWithValue("@username", TempData["Username"]);


            //int result = command.ExecuteNonQuery();

            //using (SqlDataReader reader = command.ExecuteReader())
            //{
            //    while (reader.Read())
            //    {

            //        TempData["sifra"] = reader[0].ToString();
            //        TempData["ime"] = reader[1].ToString();
            //        TempData["prezime"] = reader[2].ToString();
            //        TempData["tipZaposlenika"] = reader[3].ToString();

            //    }
            //}


            //Debug.WriteLine("Connection Closed!");
            //cnn.Close();

            //Debug.WriteLine(TempData["Sifra"]);  //sifra za unos
            //Debug.WriteLine(TempData["Ime"]);  //ime za unos
            //Debug.WriteLine(TempData["Prezime"]); //prezime za unos
            //Debug.WriteLine(TempData["Datum"]); //datum za unos
            //Debug.WriteLine(TempData["Ulazak"]); //ulazak za unos
            //Debug.WriteLine(TempData["Izlazak"]); //izlazak za unos
            //Debug.WriteLine(TempData["Razlika"]); //razlika za unos
            //Debug.WriteLine(TempData["Visak"]); //visak za unos
            //Debug.WriteLine(TempData["TipZaposlenika"]); //tip zaposlenika za unos



            //Upis u tablicu podatke o korisniku


            TempData["naziv"] = form["Naziv"];
            TempData["opis"] = form["Opis"];
            TempData["pm"] = form["PM"];
            TempData["task"] = form["PM"];
            TempData["rezultat"] = form["Rezultat"];
            TempData["koordinator"] = form["Koordinator"];
            TempData["klijent"] = form["Klijent"];
            TempData["pocetak"] = form["Pocetak"];
            TempData["kraj"] = form["Kraj"];
            TempData["datum"] = form["Datum"];
            TempData["budget"] = form["Budget"];
            TempData["drzava"] = form["Drzava"];
            TempData["imeZaposlenika"] = form["ImeZaposlenika"];
            TempData["prezimeZaposlenika"] = form["PrezimeZaposlenika"];



            try
            {


                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);
                cnn.Open();

                SqlCommand unos = new SqlCommand("INSERT INTO dbo.Projekt VALUES (@naziv,@opis,@pm,@task,@rezultat, @koordinator, @klijent, @pocetak, @kraj, @datum,@budget, @drzava, @imeZaposlenika, @prezimeZaposlenika)", cnn);

                unos.Parameters.Add("@naziv", SqlDbType.NChar).Value = TempData["naziv"];
                unos.Parameters.Add("@opis", SqlDbType.Text).Value = TempData["opis"];
                unos.Parameters.Add("@pm", SqlDbType.NChar).Value = TempData["pm"];
                unos.Parameters.Add("@task", SqlDbType.NChar).Value = TempData["task"];
                unos.Parameters.Add("@rezultat", SqlDbType.NChar).Value = TempData["rezultat"];
                unos.Parameters.Add("@koordinator", SqlDbType.NChar).Value = TempData["koordinator"];
                unos.Parameters.Add("@klijent", SqlDbType.NChar).Value = TempData["klijent"];
                unos.Parameters.Add("@pocetak", SqlDbType.DateTime).Value = TempData["pocetak"];
                unos.Parameters.Add("@kraj", SqlDbType.DateTime).Value = TempData["kraj"];
                unos.Parameters.Add("@datum", SqlDbType.Date).Value = TempData["datum"];
                unos.Parameters.Add("@budget", SqlDbType.Money).Value = TempData["budget"];
                unos.Parameters.Add("@drzava", SqlDbType.NChar).Value = TempData["drzava"];
                unos.Parameters.Add("@imeZaposlenika", SqlDbType.NChar).Value = TempData["imeZaposlenika"];
                unos.Parameters.Add("@prezimeZaposlenika", SqlDbType.NChar).Value = TempData["prezimeZaposlenika"];
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
    }
}