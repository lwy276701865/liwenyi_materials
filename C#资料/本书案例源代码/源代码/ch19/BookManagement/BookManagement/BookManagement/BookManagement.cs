/*
 * 简单的图书馆借阅系统，实现借书还书检阅信息功能
 */
using System;
using System.Collections.Generic;
using System.Data;

namespace BookManagement
{
    //图书类
    class Book
    {
        public int id;            //编号
        public string name;       //书名
        public bool available;           //是否闲置
        public string borrower;       //借书人名字

        //构造函数
        public Book(int id, string name, bool available, string borrower)
        {
            this.id = id;
            this.name = name;
			this.available = available;
            this.borrower = borrower;
        }

        //借书
        public bool Borrow(string borrower)
        {
			if (available)
            {
                string sql = String.Format("UPDATE books SET available = 0, borrower = '{0}' WHERE id = {1}", borrower, this.id);
				SqlHelper.ExecuteUpdateQuery(SqlHelper.Conn, CommandType.Text, sql);
                DateTime localDate = DateTime.Now;
                string currTime = localDate.ToString();
                sql = String.Format("INSERT INTO history (bookid, bookname, borrowtime, returntime, borrower) VALUES ({0}, '{1}', '{2}', '{3}', '{4}')", this.id, this.name, currTime, "", borrower);
                SqlHelper.ExecuteInsertQuery(SqlHelper.Conn, CommandType.Text, sql);

                return true;
            } 
            else
            {
                return false;
            }
        }

        //还书
        public void Return()
        {
			string sql = String.Format("UPDATE books SET borrower = '', available = 1 WHERE id = {0}", this.id);
			SqlHelper.ExecuteUpdateQuery(SqlHelper.Conn, CommandType.Text, sql);
            DateTime localDate = DateTime.Now;
            string currTime = localDate.ToString();
            sql = String.Format("UPDATE history SET returntime = '{0}' WHERE bookid = {1}", currTime, this.id);
            SqlHelper.ExecuteInsertQuery(SqlHelper.Conn, CommandType.Text, sql);
        }

        //空闲状态转化为字符串
        public string isAvailable()
        {
            return available ? "是" : "否";
        }
    }

    //图书馆类
    class Library
    {
        public List<Book> books = new List<Book>();

        //构造函数
        public Library()
        {
            LoadDataBase();
        }

		//读取数据库
		public void LoadDataBase()
		{
			String sql = "SELECT id, name, available, borrower FROM books";
			DataSet ds = SqlHelper.GetDataSet(SqlHelper.Conn, CommandType.Text, sql);

			foreach (DataRow dataRow in ds.Tables[0].Rows)
			{
                int id = Convert.ToInt32(dataRow["id"]);
                string name = Convert.ToString(dataRow["name"]);
                bool available = Convert.ToBoolean(dataRow["available"]);
				string borrower = Convert.ToString(dataRow["borrower"]);
                Book book = new Book(id, name, available, borrower);
                books.Add(book);
			}
		}
    }

    //借书系统类
    class BookSystem
    {
		Library library = new Library();
        string username = "";

        //主菜单
        public void Menu(int type)
        {
            if (type == 1) // 首次列出菜单项
            {
                Console.WriteLine("***************您好，欢迎登陆图书借阅系统***************");
                Console.Write("请输入您的姓名：  ");
                username = Convert.ToString(Console.ReadLine());

                Console.WriteLine("*******************请选择操作************************");
                Console.WriteLine("                   1.图书查询");
                Console.WriteLine("                   2.借书");
                Console.WriteLine("                   3.还书");
                Console.WriteLine("                   4.查看借阅历史");
                Console.WriteLine("                   5.退出系统");
                Console.WriteLine("请输入您要选择的操作编号：  ");
            }else {
                Console.WriteLine("请输入下一步操作编号（1.查询, 2.借书, 3.还书, 4.借阅历史,  5.退出）");
            }
            int input = 0;
            while (true) {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (input < 1 || input > 5) Console.WriteLine("你输入编号应为1-5，请重新输入！");
                    else break;
                }
                catch {
                    Console.WriteLine("你输入的编号样式不正确，请重新输入");
                }
                       
            }
            switch (input)
            {
                case 1:
                    Listing();
                    break;
                case 2:
                    Borrow();
                    break;
                case 3:
                    Return();
                    break;
                case 4:
                    History();
                    break;
                case 5:
                    Exit();
                    break;
            }
        }

        //查询子菜单
        public void Listing()
        {
            Console.WriteLine("图书编号\t图书名称\t\t可借阅");
            for (int i = 0; i < library.books.Count; i++)
            {
                Console.WriteLine("  {0}\t\t{1}\t\t {2}\n",
                                 library.books[i].id, library.books[i].name, library.books[i].isAvailable());
            }
            Menu(2); // 再次列出菜单项
        }

        //借书子菜单
        public void Borrow()
        {

            int id = 0;
            while (true)
            {
                Console.WriteLine("请输入要借阅的图书编号(输入r后回车返回主菜单)：  ");
                string input = Console.ReadLine();
                if (input == "r" || input == "R") {
                    Menu(2);
                    return;
                }
                try
                {
                    id = Convert.ToInt32(input);
                    if (id < 1 || id > library.books.Count || !library.books[id - 1].available)
                        Console.WriteLine("该图书已被借阅，请重新输入(输入r后回车返回主菜单)！");
                    else break;
                }
                catch
                {
                    Console.WriteLine("你输入的编号样式不正确，请重新输入(输入r后回车返回主菜单)");
                }
            }

            Console.WriteLine("{0}已成功借阅图书<{1}>", username, library.books[id-1].name);
            library.books[id - 1].borrower = username;
            library.books[id-1].Borrow(username);
            library.books[id-1].available = false;

            Menu(2);  // 再次列出菜单项

        }

		//还书子菜单
		public void Return()
		{
            int id = 0;		
            while (true)
            {
                Console.WriteLine("请输入要归还的图书编号(输入r后回车返回主菜单)：  ");
                string input = Console.ReadLine();
                if (input == "r" || input == "R")
                {
                    Menu(2);
                    return;
                }
                try
                {
                    id = Convert.ToInt32(input);
                    if (id < 1 || id > library.books.Count || library.books[id - 1].available || library.books[id-1].borrower != username)
                        Console.WriteLine("无法找到相关的借阅记录，请重新输入(输入r后回车返回主菜单)！");
                    else break;
                }
                catch
                {
                    Console.WriteLine("你输入的编号样式不正确，请重新输入(输入r后回车返回主菜单)");
                }
            }
			Console.WriteLine("您已成功归还图书<{0}>", library.books[id-1].name);
            library.books[id-1].Return();
            library.books[id-1].available = true;

            Menu(2);  // 再次列出菜单项
        }

        //还书子菜单
        public void History() {

            string sql = String.Format("SELECT * FROM history WHERE borrower = '{0}'", this.username);
            DataSet ds = SqlHelper.GetDataSet(SqlHelper.Conn, CommandType.Text, sql);           
            Console.WriteLine("图书编号\t图书名称\t 借出时间\t   还书时间");
            int id = 0;
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                int bookId = Convert.ToInt32(dataRow["bookid"]);
                string bookName = Convert.ToString(dataRow["bookname"]);
                string borrowTime = Convert.ToString(dataRow["borrowtime"]);
                string returnTime = Convert.ToString(dataRow["returntime"]);
                if (returnTime.Length == 0) returnTime = "尚未归还";
                Console.WriteLine(" {0}\t\t{1}   {2}\t{3} ",bookId, bookName, borrowTime, returnTime);
                id++;
            }
            if (id == 0) Console.WriteLine("未发现你的借阅历史！");
            Menu(2);  // 再次列出菜单项
        }

        //系统退出
        public void Exit()
        {            
            this.library = null;
            this.username = null;
            Console.WriteLine("系统已退出");
        }
    }

    //Main类
    class MainClass
    {
        public static void Main(string[] args)
        {
            BookSystem bookSys = new BookSystem();
            bookSys.Menu(1); 
        }
    }
}
