using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
// using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poo3;

namespace TestPoo2
{
    class Program
    {
        static void Main(string[] args)
        {
           TesterCollection();
            //TestCreateFile();
            
        }
            
        static void Polymorphe1()
        {
            Salarie sal1 = new Salarie("Bost", "Vincent", "96AAA11");

            Commercial com1 = new Commercial("Bost", "Vincent", "96AAA11", 10000, 0.10m)
            {
                SalaireBrut = 3500.00m,
                TauxCS = 0.35m
            };

            Console.WriteLine("Salaire commercial attendu {0} obtenu {1} assertion {2} ", 3275, com1.SalaireNet, 3275 == com1.SalaireNet);
            Console.WriteLine("Détails : {0}", com1.ToString());
            Console.ReadLine();
        }
        static void TesterCollection()
        {

            Salaries salaries = new Salaries();
            salaries.Add(new Salarie() { Matricule = "01tre12", Nom = "bost", Prenom = "Vincent", DateNaissance = new DateTime(1962, 01, 13) });
            salaries.Add(new Salarie()
            {
                Matricule = "01tre13",
                Nom = "bosti",
                Prenom = "Vincente",
                DateNaissance = new DateTime(1962, 01, 14)
            });
            Salarie sal3 = new Salarie()
            {
                Matricule = "01tre13",
                Nom = "bosti",
                Prenom = "Vincente",
                DateNaissance = new DateTime(1962, 01, 14)

            };
            salaries.Add(sal3);
            salaries.SaveTexte("");
            
        }
       
                    /// <summary>
                    /// Test Creation Fichier
                    /// </summary>
                    //static void TestCreateFile()
                    //{

                    //    string path = @"c:\Windows\temp\MyTest.txt";
                    //    if (!File.Exists(path))
                    // {
                    //        StreamWriter sw = File.CreateText(path);

                    //            sw.WriteLine ("Bonjour");
                    //            sw.WriteLine ("Salut");
                    //        sw.Close();
                    //        sw.Dispose();


                    // }
                    //    using (StreamReader sr = File.OpenText(path))
                    //    {
                    //        string s = "";
                    //        while ((s = sr.ReadLine()) != null)
                    //        {
                    //            Console.WriteLine(s);
                    //        }
                    //    }

                }
}