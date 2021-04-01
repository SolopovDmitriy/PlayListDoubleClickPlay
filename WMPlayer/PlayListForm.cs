using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WMPlayer
{
    public partial class PlayListForm : Form
    {
        private MainForm _parentForm;
        public PlayListForm(MainForm parentForm)
        {
            this._parentForm = parentForm;
            InitializeComponent();
        }
        private void PlayListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
        private void PlayListForm_Load(object sender, EventArgs e)
        {
            foreach (string item in _parentForm.PlayListController.PlayListNames)
            {
                playlistsToolStripMenuItem.DropDownItems.Add(item);
            }

            foreach (ToolStripMenuItem item in playlistsToolStripMenuItem.DropDownItems)
            {
                item.Click += Item_Click;                
            }
        }

        //private void Item_DoubleClick(object sender, EventArgs e)
        //{
        //    //string mediaPath = ((MediaRecord)sender).Path;
        //    //_parentForm.MediaPlayer.URL = mediaPath;
        //    //_parentForm.MediaPlayer.Text = Path.GetFileName(mediaPath);
        //    //_parentForm.MediaPlayer.ForeColor = Color.Red;
        //    MessageBox.Show("hello");
        //}

        private void Item_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem item in playlistsToolStripMenuItem.DropDownItems)
            {
                item.Checked = false;
            }
            ((ToolStripMenuItem)sender).Checked = true;

            if (_parentForm.PlayListController.AllMediaRecords.ContainsKey(((ToolStripMenuItem)sender).ToString()))
            {
                listBox_Playlists.Items.Clear();
                foreach (var item in _parentForm.PlayListController.AllMediaRecords[((ToolStripMenuItem)sender).ToString()])
                {
                    listBox_Playlists.Items.Add(item);
                }

                
            }
        }





        private void listBox_Playlists_MouseDoubleClick(object sender, MouseEventArgs e)//е - аргумент события, обЪект
        {
            
            int index = listBox_Playlists.IndexFromPoint(e.Location);//e.Location - точка - координаты места клика мыши; IndexFromPoint - по координате клика мышки определяет индекс элемента в списке
            if (index != ListBox.NoMatches)//если кликнули не по элементу списка, то index равен -1
            {
                MediaRecord mediaRecord = (MediaRecord) listBox_Playlists.Items[index];
                //MessageBox.Show(e.Location.X + " " + e.Location.Y);
                string mediaPath = mediaRecord.Path;//mediaRecord - например - короче или три секунды
                _parentForm.MediaPlayer.URL = mediaPath;//полный путь к файлу фильма
                _parentForm.MediaPlayer.Text = Path.GetFileName(mediaPath);//печатает текст под плеером
                _parentForm.MediaPlayer.ForeColor = Color.Red;// красным цветом
            }
        }
    }
}
