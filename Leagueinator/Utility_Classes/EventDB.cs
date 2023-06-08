using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leagueinator.Model;
using Org.BouncyCastle.Asn1.X500;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Leagueinator.utility_classes {
    public class EventDB {
        private string dbfile;

        public EventDB(string dbfile) {
            this.dbfile = dbfile;
        }

        public void CreateTables() {
            SQLiteConnection connection = CreateConnection();

            SQLiteCommand command1 = connection.CreateCommand();
            command1.CommandText = @"CREATE TABLE IF NOT EXISTS events (
                idx INTEGER PRIMARY KEY AUTOINCREMENT,
                created DATE DEFAULT (datetime('now','localtime'))
            )";
            command1.ExecuteNonQuery();

            connection.Close();
        }

        public int AddEvent() {
            SQLiteConnection connection = CreateConnection();

            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "INSERT INTO events DEFAULT VALUES";
                command.ExecuteNonQuery();
                var id = connection.LastInsertRowId;
                connection.Close();
                return (int)id;
            }
        }

        public List<LeagueEvent> AllEvents() {
            var list = new List<LeagueEvent>();

            SQLiteConnection connection = CreateConnection();
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM events";

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Debug.WriteLine("key: " + reader.GetInt32(0));
                        Debug.WriteLine("value: " + reader.GetString(1));
                        LeagueEvent lEvent = new LeagueEvent(reader.GetInt32(0), reader.GetString(1));
                        list.Add(lEvent);
                    }
                    connection.Close();
                }
            }

            return list;
        }

        public LeagueEvent GetEvent(int idx) {

            SQLiteConnection connection = CreateConnection();
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM events WHERE idx = @idx";
                command.Parameters.AddWithValue("@idx", idx);

                using (var reader = command.ExecuteReader()) {
                    LeagueEvent rvalue = null;
                    if (reader.Read()) {
                        Debug.WriteLine("key: " + reader.GetInt32(0));
                        Debug.WriteLine("value: " + reader.GetString(1));
                        rvalue = new LeagueEvent(reader.GetInt32(0), reader.GetString(1));                       
                    }
                    connection.Close();
                    return rvalue;
                }
            }
        }
        SQLiteConnection CreateConnection() {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={this.dbfile}; Version = 3; New = True; Compress = True; ");
            connection.Open();
            return connection;
        }
    }

    
}
