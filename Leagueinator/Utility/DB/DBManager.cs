using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1.X500;

namespace Leagueinator.Utility {
    public class DBManager {
        private string dbfile;

        public DBManager(string dbfile) {
            this.dbfile = dbfile;
        }

        public void CreateTables() {
            SQLiteConnection connection = CreateConnection();

            SQLiteCommand  command1 = connection.CreateCommand();
            command1.CommandText = @"CREATE TABLE IF NOT EXISTS players (
                idx INTEGER PRIMARY KEY AUTOINCREMENT,
                name VARCHAR(64) NOT NULL
            )";
            command1.ExecuteNonQuery();

            SQLiteCommand command2 = connection.CreateCommand();
            command2.CommandText = @"CREATE TABLE IF NOT EXISTS settings (              
                idx VARCHAR(64) NOT NULL UNIQUE,
                value VARCHAR(64) NOT NULL
            )";
            command2.ExecuteNonQuery();

            connection.Close();
        }

        public void SetValue(string idx, string value) {
            SQLiteConnection connection = CreateConnection();

            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "INSERT OR REPLACE INTO settings(idx, value) VALUES (@idx, @value)";
                command.Parameters.AddWithValue("@idx", idx);
                command.Parameters.AddWithValue("@value", value);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public string GetValue(string idx, string defValue) {
            Debug.WriteLine("Get Value : " + idx);

            SQLiteConnection connection = CreateConnection();
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM settings WHERE idx = @idx";
                command.Parameters.AddWithValue("@idx", idx);

                using (var reader = command.ExecuteReader()) {
                    var rvalue = defValue;
                    Debug.WriteLine(reader.HasRows);
                    if (reader.Read()) {
                        Debug.WriteLine("key: " + reader.GetString(0));
                        Debug.WriteLine("value: " + reader.GetString(1));
                        rvalue = reader.GetString(1);
                    }
                    connection.Close();
                    return rvalue;
                }
            }
        }

        public PlayerInfo AddName(string name) {
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO players(name) VALUES (@name)";
            command.Parameters.AddWithValue ("@name", name);
            command.ExecuteNonQueryAsync();

            var playerinfo = new PlayerInfo(name, connection.LastInsertRowId);
            connection.Close();
            return playerinfo;
        }

        public PlayerInfo UpdateName(long index, string name) {
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "UPDATE players SET name = @name WHERE idx = @index";
            command.Parameters.AddWithValue("@index", index);
            command.Parameters.AddWithValue("@name", name);                        
            command.ExecuteNonQuery();

            var playerinfo = new PlayerInfo(name, connection.LastInsertRowId);
            connection.Close();
            return playerinfo;
        }

        public void RemovePlayer(long index) {
            SQLiteConnection connection = CreateConnection();
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "DELETE FROM players WHERE idx = @index";
            command.Parameters.AddWithValue("@index", index);
            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<PlayerInfo> GetPlayers() {
            List<PlayerInfo> players = new List<PlayerInfo>();
            SQLiteConnection connection = CreateConnection();

            var sql = $"SELECT * FROM players";

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = sql;
            SQLiteDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                var name = reader.GetString(1);
                int idx = reader.GetInt32(0);
                var playerinfo = new PlayerInfo(name, idx);
                players.Add(playerinfo);
            }

            connection.Close();
            return players;
        }

        SQLiteConnection CreateConnection() {
            SQLiteConnection connection = new SQLiteConnection($"Data Source={this.dbfile}; Version = 3; New = True; Compress = True; ");
            connection.Open();

            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "PRAGMA journal_mode=WAL";
            command.ExecuteNonQuery();

            return connection;
        }
    }

    
}
