using SQLiteORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPlayer
{
    public class PlayListController
    {
        private SQLiteDBEngine _sQLiteDBEngine;
        private SQLiteTable _playlist;
        private SQLiteTable _mediaRecords;

        private SortedList<string, List<MediaRecord>> _allMediaRecords;
        public PlayListController(string pathToDBfile)
        {
            _sQLiteDBEngine = new SQLiteDBEngine(pathToDBfile, SQLIteMode.EXISTS);
            _playlist = _sQLiteDBEngine["playlists"];
            _mediaRecords = _sQLiteDBEngine["mediarecords"];
            _allMediaRecords = new SortedList<string, List<MediaRecord>>();


            foreach (var onePlayList in _playlist.BodyRows)
            {
                List<MediaRecord> list = new List<MediaRecord>();
                foreach (var row in _mediaRecords.BodyRows.Values)
                {
                    if(onePlayList.Key == Convert.ToInt64(row[0]))
                    {
                        MediaRecord mediaRecord = new MediaRecord(Convert.ToInt32(row[0]), row[1]);
                        list.Add(mediaRecord);
                    }
                }
                _allMediaRecords.Add(onePlayList.Value[0], list);
            }
        }
        public List<string> PlayListNames
        {
            get
            {
                List<string> tmp = new List<string>();
                foreach (List<string> row in _playlist.BodyRows.Values)
                {
                    tmp.Add(row[0]);
                }
                return tmp;
            }
        }
        public SortedList<string, List<MediaRecord>> AllMediaRecords
        {
            get
            {
                return _allMediaRecords;
            }
        }
    }
}
