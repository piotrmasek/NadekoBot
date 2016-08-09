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
    }
}