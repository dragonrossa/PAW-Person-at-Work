using System;
using System.Collections.Generic;
using System.Configuration;
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
        private List<Projekt> ListaProjekata2 = new List<Projekt>();

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult UpisZaposlenika()
        {
            FruitModel fruit = new FruitModel();
            fruit.Projects = PopulateFruits();
            return View(fruit);

            //return View();
        }

        [HttpPost]
        public ViewResult UpisZaposlenika(FormCollection form, FruitModel fruit)
        {
            fruit.Projects = PopulateFruits();
            var selectedItem = fruit.Projects.Find(p => p.Value == fruit.ProjektId.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Projekt: " + selectedItem.Text;

            }

            //return View(fruit);

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
            //TempData["sifraProjekta"] = form["ŠifraProjekta"];
            TempData["sifraProjekta"] = fruit.ProjektId;
            //Debug.WriteLine(fruit);
            Debug.WriteLine(TempData["sifraProjekta"]);
            TempData["ostalo"] = form["Ostalo"];
            Debug.WriteLine(form["LoginZap"]);


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



            return View(fruit);

        }


        private static List<SelectListItem> PopulateFruits()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Naziv, Šifra FROM Projekt";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr["Naziv"].ToString(),
                                Value = sdr["Šifra"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
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


        }

        public ActionResult Test()

        {


            //list of Projekts by its code

           

            try
            {

              

                cnn = new SqlConnection(connectionString: RadniSati.ConnectionString);

                cnn.Open();

                SqlCommand projekti = new SqlCommand("SELECT Naziv, Šifra from Projekt", cnn);


                using (SqlDataReader reader = projekti.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("{0}", reader[0].ToString()));

                        ViewBag.sifraProjekta = reader[0].ToString();

                        ViewBag.sifrica = new SelectList(reader[0].ToString());

                        //ViewBag.sifrica = new SelectList(reader[0].ToString());


                        ListaProjekata2.Add(new Projekt(Int32.Parse(reader[0].ToString())));


                        //ViewBag.CategoryId = new SelectList(ListaProjekata2.AsDataView(), "CategoryId", "CategoryName");


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



        






            return View(ListaProjekata2);
        }


    }
}
