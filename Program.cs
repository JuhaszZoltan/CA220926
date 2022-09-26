namespace CA220926
{
    internal struct EmberS
    {
        public string Nev { get; set; }
        public int Kor { get; set; }

        public EmberS(string nev, int kor)
        {
            Nev = nev;
            Kor = kor;
        }
    }

    internal class EmberO
    {
        public string Nev { get; set; }
        public int Kor { get; set; }

        public EmberO(string nev, int kor)
        {
            Nev = nev;
            Kor = kor;
        }
    }

    internal class Program
    {
        static void Main()
        {
            //StructVsClass();           
            //DatumIdo();
            AsszociativTomb();
        }

        private static void AsszociativTomb()
        {
            //asszociatív vektor
            Dictionary<string, List<string>> dic = new();

            dic.Add("macska", new List<string> { "cat", "kitty", "pussy" });
            dic.Add("kutya", new List<string> { "dog", "doggy", "puppy", "doggo" });
            dic.Add("másik macska", new List<string> { "cat", "kitty", "pussy" });

            //dic.Add("macska", new string[] { "ez mindegy"});

            foreach (var szo in dic["macska"])
                Console.WriteLine(szo);

            Dictionary<int, int> dic2 = new();

            dic2.Add(2020, 2600000);
            dic2.Add(2021, 3000000);
            dic2.Add(2022, 1200000);

            Console.WriteLine(dic2[2022]);

            //felvesz új elemet
            dic2[2022] = 1250000;
            dic["pingvin"] = new List<string> { "asd", "asd" };

            //Console.WriteLine(dic["pingvin"]);

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var s in dic[kvp.Key])
                {
                    Console.WriteLine($"\t{s}");
                }
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape)
            {
                Console.Write("írd be: ");
                string ujKulcs = Console.ReadLine();

                if (!dic.ContainsKey(ujKulcs))
                {
                    dic.Add(ujKulcs, new List<string>());

                    Console.Write("hogy van angolul: ");
                    dic[ujKulcs].Add(Console.ReadLine());
                }
                else
                {
                    Console.Write("új szinonima: ");
                    dic[ujKulcs].Add(Console.ReadLine());
                }

                Console.WriteLine("gomb");
            }

            foreach (var kvp in dic)
            {
                Console.WriteLine($"{kvp.Key}");
                foreach (var s in dic[kvp.Key])
                {
                    Console.WriteLine($"\t{s}");
                }
            }

        }

        private static void DatumIdo()
        {
            DateTime dt1 = new DateTime(1986, 01, 31, 16, 20, 10);
            Console.WriteLine(dt1);
            var dt2 = dt1.AddDays(9.6);
            Console.WriteLine(dt2);

            //for(DateTime i = new(1990, 07, 11);
            //    i < DateTime.Now;
            //    i = i.AddYears(1))
            //    Console.WriteLine(i.ToLongDateString());

            Console.WriteLine(dt1.ToLongDateString());
            Console.WriteLine(dt1.ToShortDateString());
            Console.WriteLine(dt1.ToLongTimeString());
            Console.WriteLine(dt1.ToShortTimeString());

            Console.WriteLine(dt1.ToString("yyyy-MM-dd"));


            string inp = "20070111";

            DateTime dt3 = new DateTime(
                year: int.Parse(inp.Substring(0, 4)),
                month: int.Parse(inp.Substring(4, 2)),
                day: int.Parse(inp.Substring(6, 2)));
            Console.WriteLine(dt3);

            TimeSpan ts1 = dt3 - dt1;
            Console.WriteLine(ts1);

            TimeSpan ts2 = new TimeSpan(100, 10, 10);

            DateTime dt4 = dt1 - ts1;

            for (DateTime i2 = new(2022, 09, 26, 06, 00, 00);
                i2 <= DateTime.Parse("2022-09-26 20:00");
                i2 += new TimeSpan(0, 30, 0))
            {
                Console.WriteLine(i2);
            }

            DateOnly do1 = new(2000, 10, 10);
            TimeOnly to1 = new(20, 10, 10);

            DateTime dt5 = DateTime.Parse(do1.ToString() + to1.ToString());

            Console.WriteLine(dt5);

        }

        private static void StructVsClass()
        {
            EmberS es = new EmberS("Structura Béla", 20);
            EmberO eo = new EmberO("Osztály Olivér", 30);

            EmberS es2 = es;
            EmberO eo2 = eo;

            es2.Kor += 200;
            eo2.Kor += 200;

            Console.WriteLine($"ES1: {es.Nev} - {es.Kor}");
            Console.WriteLine($"ES2: {es2.Nev} - {es2.Kor}");
            Console.WriteLine("--------------------");
            Console.WriteLine($"EO1: {eo.Nev} - {eo.Kor}");
            Console.WriteLine($"EO2: {eo2.Nev} - {eo2.Kor}");

            //fő különbségek:

            //struct: ÉRTÉK TÍPUS
            //class: REFERENCIA TÍPUS

            //struct: NEM FEDHETŐ EL a public ctor
            //class: ELFEDHETŐ a public ctor

            //struct: NEM lehet null
            //class: LEHET null
        }
    }
}