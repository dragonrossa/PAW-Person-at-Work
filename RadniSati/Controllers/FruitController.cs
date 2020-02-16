using RadniSati.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RadniSati.Controllers
{
    public class FruitController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            FruitModel fruit = new FruitModel();
            fruit.Projects = PopulateFruits();
            return View(fruit);
        }

        [HttpPost]
        public ActionResult Index(FruitModel fruit)
        {
            fruit.Projects = PopulateFruits();
            var selectedItem = fruit.Projects.Find(p => p.Value == fruit.ProjektId.ToString());
            if (selectedItem != null)
            {
                selectedItem.Selected = true;
                ViewBag.Message = "Fruit: " + selectedItem.Text;
               
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
    }
}