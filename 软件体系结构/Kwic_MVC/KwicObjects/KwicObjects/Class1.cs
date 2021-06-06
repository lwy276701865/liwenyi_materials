using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwicObjects
{
    public class Class1
    {
    }
    public interface IKwic
    {
        ArrayList input(FileStream fs, ArrayList al);
        ArrayList sort(ArrayList al);
       
    }
    public class Kwic:MarshalByRefObject,IKwic
    {
        

        public ArrayList input(FileStream fs, ArrayList al)
        {
            StreamReader sr = new StreamReader(fs);
            ArrayList al1 = new ArrayList();
            string[] words;
            string str;
            while ((str = sr.ReadLine()) != null)
            {
                if (!string.IsNullOrEmpty(str))
                {
                   
                    words = str.Trim().Split(new char[] { ' ' },
                 StringSplitOptions.RemoveEmptyEntries);//以空格分割单词，并去除多余空格
                    string str1 = string.Join(" ", words);
                    al.Add(str1);
                }
            }
            return al;
        }

        public ArrayList sort(ArrayList al)
        {
            al.Sort();
            return al;
        }
    }

}
