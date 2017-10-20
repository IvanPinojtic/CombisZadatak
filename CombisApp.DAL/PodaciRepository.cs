using CombisApp.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombisApp.DAL
{
    public class PodaciRepository
    {
        public List<Podaci> GetAll()
        {
            var filePath = ConfigurationManager.AppSettings["filePath"];
            var lista = MakeList(filePath);

            return lista;
        }

        private List<Podaci> MakeList(string filePath)
        {
            var lista = new List<Podaci>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    lista.Add(new Podaci
                    {
                        Ime = values[0].Trim(),
                        Prezime = values[1].Trim(),
                        PostanskiBroj = values[2].Trim(),
                        Grad = values[3].Trim(),
                        Telefon = values[4].Trim()
                    });
                }
            }

            return lista;
        }

        public void AddToDatabase(List<Podaci> lista)
        {
            using (var context = new PodaciContext())
            {
                foreach (var podatak in lista)
                {
                    try
                    {
                        if (!context.Podaci.Where(p => p.Ime.Equals(podatak.Ime)
                        && p.Prezime.Equals(podatak.Prezime)
                        && p.PostanskiBroj.Equals(podatak.PostanskiBroj)
                        && p.Grad.Equals(podatak.Grad)
                        && p.Telefon.Equals(podatak.Telefon)).Any())
                        {
                            context.Podaci.Add(podatak);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine(podatak.Ime + " " + podatak.Prezime + " vec postoji u bazi");
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.InnerException);
                        context.Podaci.Remove(podatak);
                    }
                }

            }


        }
    }
}
