using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Security.Cryptography;
// using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poo3;

namespace TestPoo2
{
    class Program
    {
        static Salaries salaries = new Salaries();
        static void Main(string[] args)
        {
            //TesterCollection();
            //TestCreateFile();
            //Polymorphe1();
            Salarie sal = new Salarie  { Nom = "Peyramard", Prenom = "Florian", Matricule = "13ppf19" };
            TestException(sal);
            Salarie sal2 = new Salarie { Nom = "Peyramard", Prenom = "Florian", Matricule = "13ppf19" };
            TestException(sal2);
            sal2 = new Salarie { Nom = "Dupond", Prenom = "Jean", Matricule = "36ytu89" };
            TestException(sal2);
            sal2 = new Salarie {Prenom = "Florian", Matricule = "13ppf19" };
           TestExceptionV2(sal2);
            sal2 = new Salarie { Nom = "Peyramard", Prenom = "Florian" };
            TestExceptionV2(sal2);
            Console.ReadLine();
        }
        /// <summary>
        /// Test Exceptions
        /// </summary>
        /// <param name="sal"></param>
        private static void TestException(Salarie sal)
        {
            bool ok = false;
            try
            {
                salaries.AddV2(sal);
                ok = true;
            }
            catch (SalarieException ex)
            {

                Console.WriteLine(Resource1.Salarie_001);
                ok = false;

            }
            catch (Exception)
            {
                Console.WriteLine("Autre Exception");
                ok = false;
            }
            finally
            {
                Console.WriteLine(ok);
            }
          

        }
        private static void TestExceptionV2(Salarie sal)
        {
            bool ok = false;
            try
            {
                if (sal.Matricule == null | sal.Prenom == null | sal.Nom == null)
                {
                    throw new SalarieException();
                    ok = false;
                    
                    
                }
                else
                {
                    salaries.Add(sal);
                    ok = true;
                }
            }
            //catch (ArgumentNullException aNE)
            //{
            //    Debug.WriteLine($"{aNE.Message} \n {aNE.Source} \n {aNE.StackTrace}");
            //    Console.WriteLine("prout");
            //    ok = false;
            //}
            catch (SalarieException ex2)
            {
                Console.WriteLine(Resource1.Salarie_002);
                ok = false;
            }
            catch (Exception)
            {
                Console.WriteLine("Autre Exception");
                ok = false;
            }
            finally
            {
                Console.WriteLine(ok);
            }

        }
        static void Polymorphe1()
        {
            Salarie sal1 = new Salarie("Bost", "Vincent", "96AAA11");

            Commercial com1 = new Commercial("Bost", "Vincent", "96AAA11", 10000, 0.10m)
            {
                SalaireBrut = 3500.00m,
                TauxCS = 0.35m
            };

            //Console.WriteLine("Salaire commercial attendu {0} obtenu {1} assertion {2} ", 3275, com1.SalaireNet, 3275 == com1.SalaireNet);
            //Console.WriteLine("Détails : {0}", com1.ToString());
            //Console.ReadLine();
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
        }   
        

            // salaries.SaveXML(salaries, "");
            // salaries.SaveTexte("");
            //salaries.SaveBinary(salaries,"");
            // salaries.SaveJson(salaries, "");
            // Salaries listeRetour = new Salaries();
            //listeRetour.LoadBinary("");
            //listeRetour.LoadXML(salaries, "");
            //listeRetour.LoadTexte("");
          // listeRetour.LoadJson(salaries, "");

        //  foreach(Salarie item in listeRetour)
        //  {
        //      Debug.WriteLine(item);
        //  }
        //}

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