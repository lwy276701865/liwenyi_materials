using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KWmusic
{
    class Lyrics
    {
        List<Lyric> lstLyric = new List<Lyric>();
        public void LoadLyricFromFile(string fileName)
        {
            lstLyric.Clear();
            FileStream fs = new FileStream(fileName, FileMode.Open);
            Encoding encode = Encoding.GetEncoding("GB2312");
            StreamReader sr = new StreamReader(fs, encode);
            string s;
            while((s=sr.ReadLine())!=null)
            {
                Lyric lyric = new Lyric();        
                lyric.minute = int.Parse(s.Substring(1, 2));
                double second = double.Parse(s.Substring(4, 5));
                lyric.strLyric = s.Substring(10);
                lstLyric.Add(lyric);
            }
        }
    }
    class Lyric
    {
        public int minute;
        public double second;
        public double totSeconds;
        public string strLyric;
       public double getTotSeconds()
        {
            return second + minute * 60;
        }
       
    }
}
