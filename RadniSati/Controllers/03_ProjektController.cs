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

       private List<Projekt> ListaProjekata = new List<Projekt>();

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

        public ActionResult PopisProjekata()
        {

            try
            {

                

                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);

                cnn.Open();

                SqlCommand projekti = new SqlCommand("SELECT Naziv, Opis, PM, Klijent FROM Projekt", cnn);


                using (SqlDataReader reader = projekti.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),reader[3]).ToString());
                   
                        TempData["nazivProjekta"] = reader[0].ToString(); //opis
                        TempData["opisProjekta"] = reader[1].ToString(); //naziv
                        TempData["pmProjekta"] = reader[2].ToString(); //PM
                        TempData["klijentProjekta"] = reader[3].ToString(); //klijent-naručitelj
                     
                        ListaProjekata.Add(new Projekt(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
                        
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






            return View(ListaProjekata);
        }



        public ActionResult IzmjenaProjekata()
        {

            try
            {



                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);

                cnn.Open();

                SqlCommand projekti = new SqlCommand("SELECT Šifra, Naziv FROM Projekt", cnn);


                using (SqlDataReader reader = projekti.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //Debug.WriteLine(String.Format("{0}, {1}, {2}, {3}", reader[0].ToString(), reader[1].ToString(), reader[2].ToString(),reader[3]).ToString());

                        TempData["sifra"] = reader[0].ToString(); //opis
                       // TempData["nazivProjekta"] = reader[1].ToString(); //naziv
                       
                        ListaProjekata.Add(new Projekt(Int32.Parse(reader[0].ToString()), reader[1].ToString()));

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


            return View(ListaProjekata);
        }

        public ActionResult IzmijeniProjekt()
        {

            return View();
        }

        [HttpPost]
        public ViewResult IzmijeniProjekt(FormCollection form, int id, string naziv)
        {
            var idProjekt = id;
            var Naziv = naziv;
            Debug.WriteLine(idProjekt);
            Debug.WriteLine(Naziv);
            ViewBag.id = idProjekt;
            ViewBag.naziv = Naziv;


            return View();
        }




    }


}