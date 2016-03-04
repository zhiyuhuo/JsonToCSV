using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JsonToCSV
{
    public partial class Main : Form
    {
        JsonReader _jsonReader = new JsonReader();
        List<String> _jsonDirList = new List<String>();
        public Main()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void buttonOpenJson_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            // Set filter options and filter index.
            openFileDialog1.Filter = "Json Files (.JSON)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;
            DialogResult userClickedOK = openFileDialog1.ShowDialog();

            for (int i = 0; i < openFileDialog1.FileNames.GetLength(0); i++)
            {
                _jsonDirList.Add(openFileDialog1.FileNames[i]);
            }

            textBox_JSONDIR.Lines = _jsonDirList.ToArray() ;
        }

        private void button_readjsonlist_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _jsonDirList.Count; i++)
            {
                JsonReader jsonReader = new JsonReader();
                jsonReader.read_json(_jsonDirList[i]);
                String csvDir = _jsonDirList[i].Substring(0, _jsonDirList[i].Length - 4) + "csv";
                jsonReader.save_to_csv(csvDir);
            }
        }

        private void button_Clean_Click(object sender, EventArgs e)
        {
            _jsonDirList.Clear();
            textBox_JSONDIR.Clear();
        }
    }
}
