using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMPlayer
{
    public class MediaRecord
    {
        private int _playlist_id;
        private string _path;

        public int Playlist_Id
        {
            get
            {
                return _playlist_id;
            }
            set { _playlist_id = value; }
        }
        public string Path
        {
            get
            {
                return _path;
            }
            set { _path = value; }
        }
        public MediaRecord( int playlist_id, string path)
        {
            Playlist_Id = playlist_id;
            Path = path;
        }
        public string MediaName()
        {
            return System.IO.Path.GetFileNameWithoutExtension(_path);
            //return System.IO.Path.GetFileNameWithoutExtension(_path.ToLower());
            //return _path;
        }
        public override string ToString()
        {
            return $"{MediaName()}";
        }
    }
}
