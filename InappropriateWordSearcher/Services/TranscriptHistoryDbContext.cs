using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
namespace InappropriateWordSearcher.Services
{
    public class TranscriptHistoryDbContext
    {

        public TranscriptHistoryDbContext() 
        {
        
        }

        public void SaveTranscript(string videoHash, string transcript)
        {
            
            using (var connection = new SQLiteConnection($"Data Source={DbConstants.ABS_DB_PATH}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        INSERT INTO TranscriptHistory(videohash, transcript)
                        VALUES ($videohash, $transcript)
                    ";
                command.Parameters.AddWithValue("$videohash", videoHash);
                command.Parameters.AddWithValue("$transcript", transcript);
                command.ExecuteNonQuery();
            }
        }

        public string GetTranscript(string videoHash)
        {
            string transcript = null;
            using (var connection = new SQLiteConnection($"Data Source={DbConstants.ABS_DB_PATH}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"SELECT transcript FROM TranscriptHistory WHERE videohash=$videohash";
                command.Parameters.AddWithValue("$videohash", videoHash);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        transcript = reader.GetString(0);
                    }

                }
            }
            return transcript;
        }

        public void UpdateTranscript(string videoHash, string newTranscript)
        {
            using (var connection = new SQLiteConnection($"Data Source={DbConstants.ABS_DB_PATH}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                        UPDATE TranscriptHistory SET transcript=$transcript WHERE videohash=$videohash
                    ";
                command.Parameters.AddWithValue("$videohash", videoHash);
                command.Parameters.AddWithValue("$transcript", newTranscript);
                command.ExecuteNonQuery();
            }
        }

        public static void Initialize_Database()
        {
            using (var connection = new SQLiteConnection($"Data Source={DbConstants.ABS_DB_PATH}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = DbConstants.DB_INITIAL_QUERY;
                command.ExecuteNonQuery();
            }
        }


    }

    
}
