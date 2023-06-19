using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using Leagueinator.Utility;

namespace Leagueinator.Model.LeagueEvents {
    public class EventDB : IDisposable{
        private string dbfile;
        private SQLiteConnection connection;

        public EventDB(string dbfile) {
            this.dbfile = dbfile;
            this.connection = this.CreateConnection();
        }

        public void Dispose() {
            Debug.WriteLine("EventDB Dispose");
            if (this.connection == null) return;
            this.connection.Dispose();
            this.connection = null;
        }

        public void Close() {
            if (this.connection == null) return;
            this.connection.Dispose();
            this.connection = null;
        }

        public void CreateTables() {
            SQLiteCommand command1 = connection.CreateCommand();
            command1.CommandText = @"CREATE TABLE IF NOT EXISTS events (
                idx INTEGER PRIMARY KEY AUTOINCREMENT,
                created DATE DEFAULT (datetime('now','localtime'))
            )";
            command1.ExecuteNonQuery();

            SQLiteCommand command2 = connection.CreateCommand();
            command2.CommandText = @"CREATE TABLE IF NOT EXISTS assigned_players (
                idx INTEGER PRIMARY KEY AUTOINCREMENT,
                event_idx INTEGER NOT NULL,
                round_num INTEGER NOT NULL,
                match_num INTEGER NOT NULL,
                team_num INTEGER NOT NULL,
                player_idx INTEGER NOT NULL
            )";
            command2.ExecuteNonQuery();

            SQLiteCommand command3 = connection.CreateCommand();
            command3.CommandText = @"CREATE TABLE IF NOT EXISTS players (
                idx INTEGER PRIMARY KEY AUTOINCREMENT,
                event_idx INTEGER NOT NULL,
                player_idx INTEGER NOT NULL
            )";
            command2.ExecuteNonQuery();
        }

        public string GetDate(long eventIdx) {
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "SELECT date FROM events WHERE idx = @idx";
                command.Parameters.AddWithValue("@idx", eventIdx);

                using (var reader = command.ExecuteReader()) {
                    if (reader.Read()) {
                        return reader.GetString(0);                        
                    }
                    throw new Exception("Unkown event index");
                }
            }
        }

        int CreateEvent() {
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "INSERT INTO events DEFAULT VALUES";
                command.ExecuteNonQuery();
                var idx = connection.LastInsertRowId;
                return (int)idx;
            }
        }

        public LeagueEvent CreateEvent(IEnumerable<Player> players) {
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "INSERT INTO events DEFAULT VALUES";
                command.ExecuteNonQuery();
                var idx = connection.LastInsertRowId;

                foreach (Player p in players) {
                    this.AddPlayer(idx, p);
                }

                return new LeagueEvent(this, idx, players);
            }
        }

        private long AddPlayer(long eventIdx, Player player) {
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "INSERT INTO idle_Players (event_idx, player_idx) VALUES (@event_idx, @player_idx)";
                command.Parameters.AddWithValue("@event_idx", eventIdx);
                command.Parameters.AddWithValue("@player_idx", player.SQLIndex);
                command.ExecuteNonQuery();
                return connection.LastInsertRowId;
            }
        }

        public void RemoveEvent(long eventIndex) {
            SQLiteCommand command = connection.CreateCommand();

            command.CommandText = "DELETE FROM events WHERE idx = @index";
            command.Parameters.AddWithValue("@index", eventIndex);
            command.ExecuteNonQuery();
        }

        public List<LeagueEvent> AllEvents() {
            var list = new List<LeagueEvent>();

            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "SELECT idx FROM events";

                using (var reader = command.ExecuteReader()) {
                    while (reader.Read()) {
                        Debug.WriteLine("key: " + reader.GetInt32(0));
                        Debug.WriteLine("value: " + reader.GetString(1));
                        LeagueEvent lEvent = new LeagueEvent(this, reader.GetInt32(0), reader.GetString(1));
                        this.CreateEvent()
                        list.Add(lEvent);
                    }
                }
            }

            return list;
        }

        public LeagueEvent GetEvent(int eventIdx) {
            using (SQLiteCommand command = connection.CreateCommand()) {
                command.CommandText = "SELECT * FROM events WHERE idx = @idx";
                command.Parameters.AddWithValue("@idx", eventIdx);

                using (var reader = command.ExecuteReader()) {
                    LeagueEvent rvalue = null;
                    if (reader.Read()) {
                        Debug.WriteLine("key: " + reader.GetInt32(0));
                        Debug.WriteLine("value: " + reader.GetString(1));
                        rvalue = new LeagueEvent(this, reader.GetInt32(0), reader.GetString(1));                       
                    }
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
