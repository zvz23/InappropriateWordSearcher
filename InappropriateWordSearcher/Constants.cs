using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InappropriateWordSearcher
{
    public static class AppConstants
    {
        public const string TEMP_FOLDER_NAME = "WordSearcher";
        public static readonly string ABS_TEMP_FOLDER = Path.Combine(Path.GetTempPath(), TEMP_FOLDER_NAME);
    }

    public static class DbConstants
    {
        public const string DB_NAME = "TranscriptHistoryDB";
        public static readonly string ABS_DB_PATH = Path.Combine(AppConstants.ABS_TEMP_FOLDER, DB_NAME);
        public const string DB_INITIAL_QUERY =
            @"
            CREATE TABLE IF NOT EXISTS TranscriptHistory 
            (
	            TranscriptHistoryId integer PRIMARY KEY AUTOINCREMENT,
	            videohash varchar,
	            transcript text
            );
            ";
    }
}
