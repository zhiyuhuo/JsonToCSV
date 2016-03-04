using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace JsonToCSV
{

    class JsonReader
    {
        JsonData _jsonData = new JsonData();

        public JsonReader()
        {

        }

        ~JsonReader()
        {

        }

        public int read_json(String jsonDir)
        {
            JObject json = JObject.Parse(File.ReadAllText(jsonDir));

            JToken testSubjectIDObj = json["TestSubjectId"];
            String testerID = (String)testSubjectIDObj;

            _jsonData.SetJumperID(testerID);

            JToken jumps = json["Jumps"];
            int jumps_num = 0;

            for (JToken jump = jumps.First; jump != null; jump = jump.Next)
            {
                double InitKasr = (double)jump["InitKasr"];
                double InitLeftValg = (double)jump["InitLeftValg"];
                double InitRightValg = (double)jump["InitRightValg"];


                double PeakKasr = (double)jump["PeakKasr"];
                double PeakLeftValg = (double)jump["PeakLeftValg"];
                double PeakRightValg = (double)jump["PeakRightValg"];

                _jsonData.add_jump(InitKasr, InitLeftValg, InitRightValg, PeakKasr, PeakLeftValg, PeakRightValg);
            }
            
            return 0;
        }

        public int save_to_csv(String csvDir)
        {
            _jsonData.save_to_csv(csvDir);
            return 0;
        }

        private class JsonData
        {
            String _jumperID;
            List<JumpData> _jumps = new List<JumpData>();
            public int JumpCount
            {
                get
                {
                    return _jumps.Count;
                }
            }

            public void SetJumperID(String jumperID)
            {
                _jumperID = jumperID;
            }

            public void add_jump(double initKasr, double initLeftValg, double initRightValg, double peakKasr, double peakLeftValg, double peakRightValg)
            {
                JumpData jump = new JumpData();
                jump.read_features(initKasr, initLeftValg, initRightValg, peakKasr, peakLeftValg, peakRightValg);
                _jumps.Add(jump);
            }

            public void remove_a_jump(int index)
            {
                _jumps.RemoveAt(index);
            }

            public void clear()
            {
                _jumps.Clear();
            }

            public void save_to_csv(String cvsFilePath)
            {
                if (!File.Exists(cvsFilePath))
                {
                    File.Create(cvsFilePath).Close();
                }
                else
                {
                    System.IO.File.WriteAllText(cvsFilePath, string.Empty);
                }
                StringBuilder sb = new StringBuilder();
                string delimiter = ",";
                string[] IDstr = { "Jumper ID", _jumperID };
                sb.AppendLine(string.Join(delimiter, IDstr));
                for (int i = 0; i < _jumps.Count; i++)
                {
                    string[] jumpIDstr = { "Jump#", i.ToString() };
                    sb.AppendLine(string.Join(delimiter, jumpIDstr));

                    string[][] features = {
                        new string[]{ "InitKasr", _jumps[i]._InitKasr.ToString() },
                        new string[]{ "InitLeftValg", _jumps[i]._InitLeftValg.ToString() },
                        new string[]{ "InitRightValg", _jumps[i]._InitRightValg.ToString() },
                        new string[]{ "PeakKasr", _jumps[i]._PeakKasr.ToString() },
                        new string[]{ "PeakLeftValg", _jumps[i]._PeakLeftValg.ToString() },
                        new string[]{ "PeakRightValg", _jumps[i]._PeakRightValg.ToString() }
                    };

                    for (int r = 0; r < features.GetLength(0); r++)
                    {
                        sb.AppendLine(string.Join(delimiter, features[r]));
                    }
                }

                File.AppendAllText(cvsFilePath, sb.ToString());
            }

            private class JumpData
            {
                public double _InitKasr;
                public double _InitLeftValg;
                public double _InitRightValg;

                public double _PeakKasr;
                public double _PeakLeftValg;
                public double _PeakRightValg;

                public int read_features(double initKasr, double initLeftValg, double initRightValg, double peakKasr, double peakLeftValg, double peakRightValg)
                {
                    _InitKasr = initKasr;
                    _InitLeftValg = initLeftValg;
                    _InitRightValg = initRightValg;

                    _PeakKasr = peakKasr;
                    _PeakLeftValg = peakLeftValg;
                    _PeakRightValg = peakRightValg;
                    return 0;
                }
            }

            private class JointsData
            {

            }
        }
    }
}
