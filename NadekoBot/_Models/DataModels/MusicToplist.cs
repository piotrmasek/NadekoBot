using SQLite;
using System;

namespace NadekoBot.DataModels
{
    internal class MusicToplist : IDataModel
    {
        public int SongInfoId { get; set; }

        [IndexedAttribute]
        public int Plays { get; set; }

        [IndexedAttribute]
        public DateTime LastPlayed { get; set; }

        public string GetInfoString()
        {
            var toplist = Classes.DbHandler.Instance.GetMusicToplist();
            //int place = toplist.FindIndex(p => p.Id == Id) + 1;

            int place = 1;
            foreach(var song in toplist)
            {
                if (song.Plays == Plays)
                    break;

                ++place;
            }

            string str = "";

            if (Plays >= 1)
            {
                str += $"`Played: {Plays} time";
                if (Plays != 1)
                    str += 's';

                str += $" (#{place})` ";
                str += $"`Last played: {LastPlayed}`";
            }
            else
                str += "`Never played before`";

            return str;
        }
    }
}