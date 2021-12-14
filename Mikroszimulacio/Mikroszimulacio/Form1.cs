using Mikroszimulacio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mikroszimulacio
{
    public partial class Form1 : Form
    {
        List<Person> Population;
        List<BirthProbabilities> BirthProbabilities;
        List<DeathProbabilities> DeathProbabilities;

        Random rng = new Random(1234);
        public Form1()
        {
            InitializeComponent();

            for (int year = 2005; year <= 2024; year++)
            {
                // Végigmegyünk az összes személyen
                for (int i = 0; i < Population.Count; i++)
                {
                    // Ide jön a szimulációs lépés
                }

                int nbrOfMales = (from x in Population
                                  where x.Gender == Gender.Male && x.IsAlive
                                  select x).Count();
                int nbrOfFemales = (from x in Population
                                    where x.Gender == Gender.Female && x.IsAlive
                                    select x).Count();
                Console.WriteLine(
                    string.Format("Év:{0} Fiúk:{1} Lányok:{2}", year, nbrOfMales, nbrOfFemales));
            }
        }

        private void SzimulaciosLepes(Person person, int year)
        {
            if (!person.IsAlive) return;
            int kor = year - person.BirthYear;
            //halálozás valószínűsége
            double halalvaloszinuseg = (from x in DeathProbabilities where x.Gender == person.Gender && x.Age == kor select x.P).FirstOrDefault();
            double veletlen = rng.NextDouble();
            if (veletlen <= halalvaloszinuseg)
                person.IsAlive = false;

            if (person.IsAlive && person.Gender == Gender.Female)
            {

                double szuletesvaloszinuseg = (from x in BirthProbabilities where x.Age == kor select x.P).FirstOrDefault();
                veletlen = rng.NextDouble();
                if (veletlen <= szuletesvaloszinuseg)
                {

                    Person baba = new Person();
                    baba.BirthYear = year;
                    baba.NbrOfChildren = 0;
                    baba.Gender = (Gender)rng.Next(1, 3);
                    Population.Add(baba);

                }

            }

        }

        public List<Person> GetPopulation(string csvpath)
        {

            List<Person> result = new List<Person>();

            using (StreamReader sr = new StreamReader(csvpath, Encoding.Default))
            {

                while (!sr.EndOfStream)
                {

                    string line = sr.ReadLine();
                    string[] items = line.Split(';');
                    Person p = new Person();
                    p.BirthYear = int.Parse(items[0]);
                    p.Gender = (Gender)Enum.Parse(typeof(Gender), items[1]);
                    p.NbrOfChildren = int.Parse(items[2]);
                    result.Add(p);
                }
            }
            return result;

        }


    }
}
