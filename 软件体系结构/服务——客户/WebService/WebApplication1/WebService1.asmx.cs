using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Collections;
using System.Text;

namespace WebApplication1
{
    /// <summary>
    /// WebService1 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        FileStream in_fs = new FileStream("d:\\input.txt", FileMode.Open);
        FileStream out_fs = new FileStream("d:\\output.txt", FileMode.Create);
        ArrayList in_al = new ArrayList();
        ArrayList out_al = new ArrayList();
        [WebMethod]
        public ArrayList Shift()
        {
            //需要实现
            input(in_fs, in_al);
            shift(in_al);
            // return in_al;
            sort(in_al);
            return out_al;
        }
        void input(FileStream fs, ArrayList al)
        {
            //需要实现
            string str;
      
            StreamReader sr = new StreamReader(fs);
            while ((str = sr.ReadLine()) != null)
            {
                al.Add(str);
            }           
        }
        void shift(ArrayList in_al)
        {
            ArrayList al = new ArrayList();
            ArrayList al1 = new ArrayList();
            string[] words;
            foreach(string i in in_al)
            {
                words = i.Trim().Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries);//以空格分割单词，并去除多余空格
                al.Clear();
                foreach (string s in words)
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        al.Add(s);
                    }
                }
                for(int j=0;j<al.Count;j++)
                {
                    for(int k=j;k<al.Count;k++)
                    {
                        al1.Add(al[k]+" ");
                    }
                    if(j!=0)
                    {
                        for (int h = 0; h < j; h++)
                            al1.Add(al[h]+" ");
                    }
                    al1.Add("\n");
                }
            }
            this.in_al = al1;
        }
        void sort(ArrayList al)
        {
            string st="";
            foreach (string str in al)
            {
                if (str != "\n")
                {
                    st += str;
                }
                else
                {
                    out_al.Add(st + "\n");
                    st = "";
                }
            }
            out_al.Sort();
        }
    }
}

