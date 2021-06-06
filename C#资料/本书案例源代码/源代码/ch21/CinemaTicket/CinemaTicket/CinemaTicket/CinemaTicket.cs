/*
 * 简单影院订票系统
 */

using System;
using System.Collections.Generic;
using System.Data;


namespace CinemaTicket
{
    //座位类
    class Seat
    {
        //座位位置及是否已预定
        public int row, col;
        public bool booked = false;

        //构造函数
        public Seat(int row, int col, bool booked)
        {
            this.row = row;
            this.col = col;
            this.booked = booked;
        }

        //预定函数
        public void Book()
        {
            booked = true;
        }

        //将座位预定信息转化为字符
        public static char ToChar(bool booked)
        {
            return booked ? 'X' : 'O';
        }

        public string GetPosString()
        {
            return row.ToString() + "," + col.ToString() + " ";
        }
    }

    //影厅类
    class Hall
    {
        //默认行列数
		public const int DEFAULT_ROWS = 9;
		public const int DEFAULT_COLS = 9;

        //影厅编号及行列
        public int hallNum;
        public int rows;
        public int cols;

        //座位数组
		public Seat[,] seats;

        //构造函数，生成座位数组
		public Hall(int hallNum, int rows, int cols)
		{
            this.hallNum = hallNum;
            this.rows = rows;
            this.cols = cols;
			seats = new Seat[rows, cols];
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < cols; j++)
				{
                    seats[i, j] = new Seat(i, j, false);
				}
			}
		}

        //将座位情况显示在控制台
        public void Display()
        {
            String hallDisplay = "  ";
			for (int j = 0; j < cols; j++)
			{
                hallDisplay += (j+1).ToString();
				hallDisplay += ' ';
			}
            hallDisplay += '\n';

            for (int i = 0; i < rows; i++)
            {
                hallDisplay += (i + 1).ToString();
                hallDisplay += ' ';
                for (int j = 0; j < cols; j++)
                {
                    hallDisplay += Seat.ToChar(seats[i, j].booked);
                    hallDisplay += ' ';
                }
                hallDisplay += '\n';
            }

            Console.Write(hallDisplay);
        }

        //预订某个座位
        public bool BookSeat(int row, int col)
        {
            if (seats[row, col].booked)
            {
                return false;
            }
            else
            {
                seats[row, col].Book();
                return true;
            }
        }

        //获取座位预订字符串
        public string GetSeatbookString()
        {
            string seatbook = "";
            foreach (Seat seat in seats)
            {
                if (seat.booked)
                {
                    seatbook += seat.GetPosString();
                }
            }

            return seatbook;
        }
    }

    //电影类
    class Movie
    {
        //电影名称、日期时间、大厅
        public string name;
        public DateTime showTime;
        public Hall hall;

        //构造函数
        public Movie(string name, DateTime showTime, int hallNum)
        {
            this.name = name;
            this.showTime = showTime;
            this.hall = new Hall(hallNum, Hall.DEFAULT_ROWS, Hall.DEFAULT_COLS);
        }

        //构造函数包括座位预定信息
        public Movie(string name, DateTime showTime, int hallNum, string bookseat)
        {
			this.name = name;
			this.showTime = showTime;
			this.hall = new Hall(hallNum, Hall.DEFAULT_ROWS, Hall.DEFAULT_COLS);

            MarkBookSeat(bookseat);
        }

        //座位预订字符串转化为数组
        public void MarkBookSeat(string bookseat)
        {
            if (bookseat == null || bookseat == "")
                return;
            char[] separator = {',', ' '};
            string[] subStrings = bookseat.Split(separator);
            bool isRow = true;
            int row = -1;
            int col = -1;
            foreach (string substring in subStrings)
            {
                if (isRow)
                {
                    row = Convert.ToInt32(substring);
                } 
                else 
                {
                    col = Convert.ToInt32(substring);
                    hall.seats[row, col].booked = true;
                }

                isRow = !isRow;
            }
        }

        //座位预订数组转化为字符串
        public string ToStringBookSeat()
        {
            string result = "";
            foreach (Seat seat in hall.seats)
            {
                if (seat.booked)
                {
                    result += seat.row;
                    result += ',';
                    result += seat.col;
                    result += " ";
                }
            }

            return result;
        }



        //控制台显示电影信息
        public void Display()
        {
            Console.WriteLine("{0}\t时间：{1}\t影厅：{2}", name, showTime, hall.hallNum);
        }
    }

    //订票系统类
    class TicketSystem
    {
        //所有电影
        public List<Movie> movies = new List<Movie>();

        //增加电影
		public bool AddMovie(Movie movie)
		{
			movies.Add(movie);
			return true;
		}

        //预订座位
        public bool BookSeat(int mid, int row, int col)
        {
            if (movies[mid].hall.BookSeat(row, col))
            {
                string seatbooked = movies[mid].ToStringBookSeat();
                string sql = String.Format("UPDATE movies SET seatbooked = '{0}' WHERE mid = {1}", seatbooked, mid + 1);

               // Console.WriteLine(seatbooked);
                int i = SqlHelper.ExecuteUpdateQuery(SqlHelper.Conn, CommandType.Text, sql);

                return true;
            }

            return false;
        }

        //显示影厅预订情况
        public void DisplayHall(int movieNum)
        {
            movies[movieNum].hall.Display();
        }

        //读取数据库
        public void LoadDataBase()
        {
			String sql = "SELECT mid, mname, showtime, hall, seatbooked FROM movies";
			DataSet ds = SqlHelper.GetDataSet(SqlHelper.Conn, CommandType.Text, sql);

			foreach (DataRow dataRow in ds.Tables[0].Rows)
			{
				String mname = Convert.ToString(dataRow["mname"]);
				DateTime time = Convert.ToDateTime(dataRow["showtime"]);
				int hall = Convert.ToInt32(dataRow["hall"]);
				string seatbook = Convert.ToString(dataRow["seatbooked"]);
				Movie movie = new Movie(mname, time, hall, seatbook.Trim());
                this.AddMovie(movie);
			}
        }

    }

    //Main类
    class CinemaTicket
    {
        //Main函数
		public static void Main(string[] args)
		{
            //实例化订票系统
			TicketSystem ticketSystem = new TicketSystem();

            Console.WriteLine("－－－－－－－欢迎光临电影订票系统－－－－－－－－－");
			String seperator = "-----------------------------------------";

            // 执行查询
            ticketSystem.LoadDataBase();

            //初始化输入变量
			int movieNum = -1;
			int rowNum = -1;
			int colNum = -1;
            int inputStatus = 0; //0选择电影，1选择行，2选择列，3预定成功，4退出
            bool validCmd = true;
            String temp;

            //使用状态机控制输入
            while (inputStatus != 4)
            {
                switch (inputStatus)
                {
                    case 0:
                        Console.WriteLine("当前正在放映的电影包括：");
                        for (int i = 0; i < ticketSystem.movies.Count; i++)
                        {
                            Console.Write("{0}:\t", i + 1);
                            ticketSystem.movies[i].Display();
                        }
                        Console.WriteLine(seperator);
                        Console.WriteLine("请输入电影序号，输入q退出系统：");
                        temp = Console.ReadLine();
                        if (temp == "q")
                        {
                            inputStatus = 4;
                            break;
                        }
                        try
                        {
                            movieNum = Convert.ToInt32(temp) - 1;
                            if (movieNum >= 0 && movieNum < ticketSystem.movies.Count)
                            {
                                inputStatus = 1;
                            }
                            else
                            {
                                Console.WriteLine("你输入的编号不存在，请重新输入");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("你输入的编号格式不正确，请重新输入");
                        }
                        break;

                    case 1:
                        Console.WriteLine("该电影的放映厅座位图如下所示（X为已预订，O为空座）：");
                        ticketSystem.DisplayHall(movieNum);
                        Console.WriteLine("请输入座位横排序号，输入r重新选择电影：");
                        temp = Console.ReadLine();
                        if (temp == "r")
                        {
                            inputStatus = 0;
                            break;
                        }
                        rowNum = Convert.ToInt32(temp) - 1;
                        if (rowNum >= 0 && rowNum < ticketSystem.movies[movieNum].hall.rows)
                        {
                            inputStatus = 2;
                        }
                        else
                        {
                            Console.WriteLine("你输入的横排号不存在，请重新输入：");
                        }
                        break;

                    case 2:
                        Console.WriteLine("请输入座位竖排序号，输入r重新选择电影：");
                        temp = Console.ReadLine();
                        if (temp == "r")
                        {
                            inputStatus = 0;
                            break;
                        }
                        colNum = Convert.ToInt32(temp) - 1;
                        if (colNum >= 0 && colNum < ticketSystem.movies[movieNum].hall.cols)
                        {
                            inputStatus = 3;
                        }
                        else
                        {
                            Console.WriteLine("你输入的竖排号不存在，请重新输入：");
                        }

                        break;

                    case 3:
                        if (validCmd)
                        {
                            if (ticketSystem.BookSeat(movieNum, rowNum, colNum))
                                Console.WriteLine("预订成功！输入字符c继续预订，输入q退出系统：");
                            else
                                Console.WriteLine("该座位无法预订！输入字符c预定其他座位。输入q退出系统：");
                        }
                        else
                        {
                                Console.WriteLine("输入字符c继续预定。输入q退出系统：");
                        }
                        temp = Console.ReadLine();
                        if (temp == "q")
                        { 
                            inputStatus = 4;
                            validCmd = true;
                        }else if (temp == "c")
                        {
                            inputStatus = 0;
                            validCmd = true;
                        } else
                        {
                            validCmd = false;
                        }
                        break;
      
                }
            }
		}
    }
}
