using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Poo3
{
    [Serializable()]
    [XmlInclude(typeof(Commercial))]
    public class Salaries : List<Salarie>
    {
        /// <summary>
        /// Ajout d'un salarié sans doublon
        /// </summary>
        /// <param name="salarie"></param>
        public new void Add(Salarie salarie)
        {
            bool trouve = false;
            foreach (Salarie item in this)
            {
                if (item.Equals(salarie))
                {
                    trouve = true;
                    break;
                }
            }
            if (!trouve)
            {
                base.Add(salarie);
            }
        }
        /// <summary>
        /// Autre forme d'ajout sans doublon
        /// </summary>
        /// <param name="salarie"></param>
        public void AddV2(Salarie salarie)
        {
            if (!this.Contains(salarie))
            {
                base.Add(salarie);
            }
        }
        public Salarie Extraire(string matricule)
        {
            foreach (Salarie item in this)
            {
                if (item.Matricule == matricule)
                {
                    return item;

                }
            }
            return null;
        }

        /// <summary>
        /// Suppression d'un salarié en fonction du matricule
        /// </summary>
        /// <param name="matricule"></param>
        public bool Remove(string matricule)
        {
            Salarie salTrouve = Extraire(matricule);
            if (salTrouve != null)
            {
                base.Remove(salTrouve);
                return true;
            }
            else
            {
                return false;
            }

        }
        #region Serialisation
        public void SaveTexte(string path)
        {
            path = @"c:\Windows\temp\Salarie.txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (Salarie item in this)
                    {
                        sw.WriteLine(item.ToString());
                    }
                    sw.Dispose();
                    sw.Close();
                }
            }
        }
        public void LoadTexte(string path)
        {
            path = @"c:\Windows\temp\Salarie.txt";
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] result = s.Split(';');
                    for (int i = 0; i < result.Length; i++)
                    {
                        Debug.WriteLine(result[i]);
                    }


                }
                sr.Close();
                sr.Dispose();
            }
        }
        public void SaveBinary(Salaries listsalaries, string filepath)
        {
            filepath = @"c:\Windows\temp\SalarieBinary.dat";
            FileStream fs = File.Create(filepath);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, listsalaries);
            fs.Close();
            fs.Dispose();
        }
        public void SaveXML(Salaries listsalaries, string filepath)
        {
            filepath = @"c:\Windows\temp\SalarieXML.xml";
            FileStream fs = File.Create(filepath);
            XmlSerializer x = new XmlSerializer(typeof(Salaries));
            x.Serialize(fs, listsalaries);
            fs.Close();
            fs.Dispose();
        }
        public void LoadBinary(string filepath)
        {
            filepath = @"c:\Windows\temp\SalarieBinary.dat";
            FileStream fs = File.OpenRead(filepath);
            BinaryFormatter bf = new BinaryFormatter();
            this.AddRange(bf.Deserialize(fs) as Salaries);
            fs.Close();
            fs.Dispose();

        }
        public void LoadXML(Salaries listsalaries, string filepath)
        {
            filepath = @"c:\Windows\temp\SalarieXML.xml";
            FileStream fs = File.OpenRead(filepath);
            XmlSerializer x = new XmlSerializer(typeof(Salaries));
            this.AddRange(x.Deserialize(fs) as Salaries);
            fs.Close();
            fs.Dispose();
        }
        public void SaveJson(Salaries listsalaries, string filepath)
        {
            filepath = @"c:\Windows\temp\SalarieJson.json";
            JsonSerializer j = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(filepath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                j.Serialize(writer, listsalaries);
            }

        }
        public void LoadJson(Salaries listsalaries, string filepath)
        {
            filepath = @"c:\Windows\temp\SalarieJson.txt";
            using (StreamReader file = File.OpenText(filepath))
            {
                JsonSerializer j = new JsonSerializer();
                this.AddRange(j.Deserialize(file, typeof(Salaries)) as Salaries);
            }
        }
        #endregion
       

    }
}