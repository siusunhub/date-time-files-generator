using LiteDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateTimeFilesSetting
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();



            labelStatus.Text = "";

            using (var db = new LiteDatabase(@"DateTimeFiles.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<PathSetting>("path");

                foreach (var _path in col.FindAll())
                {

                    if (_path.no == 1) genPath1.Text = _path.path;
                    if (_path.no == 2) genPath2.Text = _path.path;
                    if (_path.no == 3) genPath3.Text = _path.path;
                    if (_path.no == 4) genPath4.Text = _path.path;
                    if (_path.no == 5) genPath5.Text = _path.path;
                    if (_path.no == 6) genPath6.Text = _path.path;
                    if (_path.no == 7) genPath7.Text = _path.path;
                    if (_path.no == 8) genPath8.Text = _path.path;
                    if (_path.no == 9) genPath9.Text = _path.path;
                    if (_path.no == 10) genPath10.Text = _path.path;
       
                }

            }

        }

        private PathSetting genSettingObj(int no, string path)
        {
            PathSetting s = new PathSetting();
            s._id = RandomString(16);
            s.no = no;
            s.path = path;
            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new LiteDatabase(@"DateTimeFiles.db"))
            {
                // Get a collection (or create, if doesn't exist)
                var col = db.GetCollection<PathSetting>("path");
                // var _item = col.FindOne(Query.EQ("Command", textBoxCommand.Text));

                col.DeleteAll();

                if (genPath1.Text != "") col.Insert(genSettingObj(1, genPath1.Text));
                if (genPath2.Text != "") col.Insert(genSettingObj(2, genPath2.Text));
                if (genPath3.Text != "") col.Insert(genSettingObj(3, genPath3.Text));
                if (genPath4.Text != "") col.Insert(genSettingObj(4, genPath4.Text));
                if (genPath5.Text != "") col.Insert(genSettingObj(5, genPath5.Text));
                if (genPath6.Text != "") col.Insert(genSettingObj(6, genPath6.Text));
                if (genPath7.Text != "") col.Insert(genSettingObj(7, genPath7.Text));
                if (genPath8.Text != "") col.Insert(genSettingObj(8, genPath8.Text));
                if (genPath9.Text != "") col.Insert(genSettingObj(9, genPath9.Text));
                if (genPath10.Text != "") col.Insert(genSettingObj(10, genPath10.Text));

                labelStatus.Text ="Setting saved.";
            }
        }


        private void selectDirectoryBox(TextBox _textbox)
        {

            if(_textbox.Text != "")
            {
                folderBrowserDialog1.SelectedPath = _textbox.Text;
            }
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _textbox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private string RandomString(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[length];
            
            

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        private void buttonBrowse1_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath1);
        }
        private void buttonBrowse2_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath2);
        }

        private void buttonBrowse3_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath3);
        }

        private void buttonBrowse4_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath4);
        }

        private void buttonBrowse5_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath5);
        }

        private void buttonBrowse6_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath6);
        }

        private void buttonBrowse7_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath7);
        }

        private void buttonBrowse8_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath8);
        }

        private void buttonBrowse9_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath9);
        }

        private void buttonBrowse10_Click(object sender, EventArgs e)
        {
            selectDirectoryBox(genPath10);
        }
    }
}
