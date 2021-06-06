/*
 * 简单的社区互助系统（共享经济）, 打开程序后，有个菜单：发布需求（需求名称，可提供的报酬），
 * 提供需求，查看所有需求，查看达成的交易 ，修改用户昵称，退出系统。
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Data;

namespace CommunityShare
{
    //需求状态，已发布和已完成
	enum Status
	{
		Published,
		Completed
	}

    //需求类
    class Need
    {
        public int nid;             //需求序号
        public string desc;         //需求描述
        public string poster;         //发布者
        public int pay;             //金额
        public Status status;       //需求状态
        public string helper;       //提供帮助者

        //构造函数
        public Need(int nid, string desc, string poster, int pay, Status status, string helper)
        {
            this.nid = nid;
            this.desc = desc;
            this.poster = poster;
            this.pay = pay;
            this.status = status;
            this.helper = helper;
        }

        //接受需求
        public bool Accept(string helper)
        {
            if (status == Status.Published)
            {
                status = Status.Completed;
                this.helper = helper;
                return true;
            }
            else
            {
                return false;
            }
        }

        //打印需求标题行
        public static void PrintHeadline()
        {
            Console.WriteLine("编号\t描述\t\t需求发布者  金额(元) 状态   提供帮助者");
        }

        //打印需求
        public void Print()
        {
            string statusDesc = status > 0 ? "交易达成" : "已发布";
            string helperDesc = helper.Length > 0 ? helper : "暂无";
            Console.WriteLine(" {0}  {1}\t{2}\t    {3}\t   {4}  {5}", nid, desc, poster, pay, statusDesc, helperDesc);
        }
    }

    //平台类
    class Platform
    {
        //需求List
        public List<Need> needs = new List<Need>();

        //构造函数，读取文件
        public Platform()
        {
            LoadPlatform();
        }

        //发布需求
        public void PublishNeed(Need need)
        {
            needs.Add(need);
			string sql = String.Format("INSERT INTO needs (nid, description, poster, pay, status, helper) " +
                                       "VALUES ({0}, '{1}', '{2}', {3}, {4}, '{5}')", 
                                       need.nid, need.desc, need.poster, need.pay, (int)need.status, need.helper);
			SqlHelper.ExecuteInsertQuery(SqlHelper.Conn, CommandType.Text, sql);

        }

        //接受需求
        public int AcceptNeed(int nid, String helper)
        {
            if (nid < 1 || nid >needs.Count)
                return 0;

            if (needs[nid - 1].poster == helper)
                return -1;
            bool success = needs[nid-1].Accept(helper);
            if (success)
            {
                string sql = String.Format("UPDATE needs SET helper = '{0}', status = 1 WHERE nid = {1}", helper, nid);
                SqlHelper.ExecuteUpdateQuery(SqlHelper.Conn, CommandType.Text, sql);
                return 1;
            } else
                return 0;
        }

        //打印部分需求
        public void PrintNeeds()
        {
            Need.PrintHeadline();
            for (int i = 0; i < needs.Count; i++)
            {
                    needs[i].Print();
            }
        }

        public void PrintNeeds(Status status)
        {
            Need.PrintHeadline();
			for (int i = 0; i < needs.Count; i++)
			{
                if (needs[i].status == status)
				{
					needs[i].Print();
				}
			}
        }

        //读取数据库
        public void LoadPlatform()
        {
			String sql = "SELECT nid, description, poster, pay, status, helper FROM needs";
			DataSet ds = SqlHelper.GetDataSet(SqlHelper.Conn, CommandType.Text, sql);

			foreach (DataRow dataRow in ds.Tables[0].Rows)
			{
				int nid = Convert.ToInt32(dataRow["nid"]);
				string desc = Convert.ToString(dataRow["description"]);
                string poster = Convert.ToString(dataRow["poster"]);
                int pay = Convert.ToInt32(dataRow["pay"]);
                Status status = (Status)Convert.ToInt32(dataRow["status"]);
                string helper = Convert.ToString(dataRow["helper"]);

                Need need = new Need(nid, desc, poster, pay, status, helper);
                needs.Add(need);
			}

        }
    }

    //系统类
    class CommunityShare
    {
        Platform platform = new Platform();
        public string user;

		//登陆
		public void LogIn()
		{
            Menu(1);
		}

		//主菜单
		public void Menu(int type)
		{

            if (type == 1) // 首次列出菜单项
            {
                Console.WriteLine("***************您好，欢迎登陆社区互助系统***************");
                Console.Write("请输入您的昵称：  ");
                user = Convert.ToString(Console.ReadLine());
                Console.WriteLine("欢迎登陆，{0}", user);
                Console.WriteLine("*******************请选择操作************************");
                Console.WriteLine("                   1.发布需求");
                Console.WriteLine("                   2.提供服务");
                Console.WriteLine("                   3.查看所有需求");
                Console.WriteLine("                   4.查看已达成交易");
                Console.WriteLine("                   5.更改昵称");
                Console.WriteLine("                   6.退出系统");
                Console.WriteLine("请输入您要选择的操作编号：  ");
            }
            else
            {
               Console.WriteLine("-------------------------------------------------------------");
               Console.WriteLine("请输入下一步操作编号（1.发布需求, 2.提供服务, 3.查看需求, 4.已达成交易,  5.更改昵称, 6.退出）");
            }
            int input = 0;
            while (true)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1 || input > 6) Console.WriteLine("你输入编号应为1-6，请重新输入！");
                    else break;
                }
                catch
                {
                    Console.WriteLine("你输入的编号样式不正确，请重新输入");
                }

            }

			switch (input)
			{
				case 1:
					PublishNeed();
					break;
				case 2:
					AcceptNeed();
					break;
				case 3:
					ViewPublishedNeeds();
					break;
				case 4:
					ViewAcceptedNeeds();
					break;
				case 5:
                    LogIn();
					break;
				case 6:
					Exit();
					break;
			}
		}

        //发布需求
        public void PublishNeed()
        {
            Console.WriteLine("\n***发布需求：");
            Console.WriteLine("-------------------------------------------------------------");
            int nid = platform.needs.Count+1;
			Console.Write("请输入需求描述：  ");
            string desc = Console.ReadLine();
			Console.Write("请输入需求金额(元)：  ");
			int pay = Convert.ToInt32(Console.ReadLine());
            Need need = new Need(nid, desc, user, pay, Status.Published, "");
            platform.PublishNeed(need);

			Console.WriteLine("发布成功！");
            Need.PrintHeadline();
            need.Print();
			Menu(2);
        }

        //接受需求
        public void AcceptNeed()
        {
            Console.WriteLine("\n***开始提供服务：");
            Console.WriteLine("-------------------------------------------------------------");
            platform.PrintNeeds(Status.Published);
            int nid = 0;
            while (true)
            {
                Console.WriteLine("请输入需求编号(输入r后回车返回主菜单)：  ");
                string input = Console.ReadLine();
                if (input == "r" || input == "R")
                {
                    Menu(2);
                    return;
                }
                try
                {
                    nid = Convert.ToInt32(input);
                    break;         
                }
                catch
                {
                    Console.WriteLine("你输入的编号样式不正确，请重新输入(输入r后回车返回主菜单)");
                }
            }

            int success = platform.AcceptNeed(nid, user);

            if (success > 0)
                Console.WriteLine("交易达成！ ");
            else if (success == 0)
                Console.WriteLine("交易失败！该需求不存在或已完成。");
            else if (success == -1)
                Console.WriteLine("交易失败！发布人和提供服务人相同。");
            else
            {
                ;
            }

            Menu(2);
        }

        //查看当前需求
        public void ViewPublishedNeeds()
        {
            Console.WriteLine("\n***查看所有发布的需求：");
            Console.WriteLine("-------------------------------------------------------------");
            platform.PrintNeeds();
			Menu(2);
        }

        //查看已完成交易
        public void ViewAcceptedNeeds()
        {
			Console.WriteLine("\n***查看已完成交易：");
            Console.WriteLine("-------------------------------------------------------------");
            platform.PrintNeeds(Status.Completed);
			Menu(2);
        }

        //退出系统
        public void Exit()
        {
            user = null;
            platform = null;
            Console.WriteLine("系统已退出");
        }
		
    }

    //Main类
    class MainClass
    {
        public static void Main(string[] args)
        {
            CommunityShare communityShare = new CommunityShare();
            communityShare.LogIn();
        }
    }
}
