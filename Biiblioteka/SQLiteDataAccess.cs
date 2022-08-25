using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biiblioteka
{
    public class SQLiteDataAccess
    {
        public static List<plan_lekcji_bib> LoadPlan()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<plan_lekcji_bib>("select * from plan_zajec", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SavePlan(plan_lekcji_bib przedmiot)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into plan_zajec (nazwa, dzien, godzina) values (@nazwa, @dzien, @godzina)", przedmiot);
            }
        }

        public static void ModifyPlan(plan_lekcji_bib przedmiot, string nowanazwa, string nowydzien, string nowagodzina)
        {
            string query = "update plan_zajec set nazwa = 'nowanazwa', dzien = 'nowydzien', godzina = 'nowagodzina' where nazwa = 'staranazwa' and dzien = 'starydzien' and godzina = 'staragodzina'";
            var replacement1 = query.Replace("nowanazwa", nowanazwa);
            var replacement2 = replacement1.Replace("nowydzien", nowydzien);
            var replacement3 = replacement2.Replace("nowagodzina", nowagodzina);
            var replacement4 = replacement3.Replace("staranazwa", przedmiot.nazwa);
            var replacement5 = replacement4.Replace("starydzien", przedmiot.dzien);
            var replacement6 = replacement5.Replace("staragodzina", przedmiot.godzina);
            
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(replacement6, przedmiot);
            }
        }

        public static void DeletePlan(plan_lekcji_bib przedmiot)
        {
            string query = "delete from plan_zajec where nazwa = 'pnazwa' and dzien = 'pdzien' and godzina = 'pgodzina'";
            var replacement1 = query.Replace("pnazwa", przedmiot.nazwa);
            var replacement2 = replacement1.Replace("pdzien", przedmiot.dzien);
            var replacement3 = replacement2.Replace("pgodzina", przedmiot.godzina);
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(replacement3, przedmiot);
            }
        }

        public static List<zadania_domowe_bib> LoadZadania()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<zadania_domowe_bib>("select * from zadania_domowe", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveZadania(zadania_domowe_bib zadanie)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into zadania_domowe (nazwa, dzien, godzina) values (@nazwa, @dzien, @godzina)", zadanie);
            }
        }

        public static void ModifyZadania(zadania_domowe_bib zadanie, string nowanazwa, string nowydzien, string nowagodzina)
        {
            string query = "update zadania_domowe set nazwa = 'nowanazwa', dzien = 'nowydzien', godzina = 'nowagodzina' where nazwa = 'staranazwa' and dzien = 'starydzien' and godzina = 'staragodzina'";
            var replacement1 = query.Replace("nowanazwa", nowanazwa);
            var replacement2 = replacement1.Replace("nowydzien", nowydzien);
            var replacement3 = replacement2.Replace("nowagodzina", nowagodzina);
            var replacement4 = replacement3.Replace("staranazwa", zadanie.nazwa);
            var replacement5 = replacement4.Replace("starydzien", zadanie.dzien);
            var replacement6 = replacement5.Replace("staragodzina", zadanie.godzina);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(replacement6, zadanie);
            }
        }

        public static void DeleteZadania(zadania_domowe_bib zadanie)
        {
            string query = "delete from zadania_domowe where nazwa = 'pnazwa' and dzien = 'pdzien' and godzina = 'pgodzina'";
            var replacement1 = query.Replace("pnazwa", zadanie.nazwa);
            var replacement2 = replacement1.Replace("pdzien", zadanie.dzien);
            var replacement3 = replacement2.Replace("pgodzina", zadanie.godzina);
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(replacement3, zadanie);
            }
        }

        public static List<sprawdziany_bib> LoadSprawdziany()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<sprawdziany_bib>("select * from sprawdziany", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveSprawdziany(sprawdziany_bib sprawdzian)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into sprawdziany (nazwa, dzien, godzina) values (@nazwa, @dzien, @godzina)", sprawdzian);
            }
        }

        public static void ModifySprawdziany(sprawdziany_bib sprawdzian, string nowanazwa, string nowydzien, string nowagodzina)
        {
            string query = "update sprawdziany set nazwa = 'nowanazwa', dzien = 'nowydzien', godzina = 'nowagodzina' where nazwa = 'staranazwa' and dzien = 'starydzien' and godzina = 'staragodzina'";
            var replacement1 = query.Replace("nowanazwa", nowanazwa);
            var replacement2 = replacement1.Replace("nowydzien", nowydzien);
            var replacement3 = replacement2.Replace("nowagodzina", nowagodzina);
            var replacement4 = replacement3.Replace("staranazwa", sprawdzian.nazwa);
            var replacement5 = replacement4.Replace("starydzien", sprawdzian.dzien);
            var replacement6 = replacement5.Replace("staragodzina", sprawdzian.godzina);

            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(replacement6, sprawdzian);
            }
        }

        public static void DeleteSprawdziany(sprawdziany_bib sprawdzian)
        {
            string query = "delete from sprawdziany where nazwa = 'pnazwa' and dzien = 'pdzien' and godzina = 'pgodzina'";
            var replacement1 = query.Replace("pnazwa", sprawdzian.nazwa);
            var replacement2 = replacement1.Replace("pdzien", sprawdzian.dzien);
            var replacement3 = replacement2.Replace("pgodzina", sprawdzian.godzina);
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute(replacement3, sprawdzian);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            string conn = ConfigurationManager.ConnectionStrings[id].ConnectionString;
            return conn;
        }
    }
}
