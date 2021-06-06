using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace 人事管理系统_GSJ
{
    class DoValidate
    {
        /// <summary>
        /// 检查固定电话是否合法
        /// </summary>
        /// <param name="str">固定电话字符串</param>
        /// <returns>合法返回 true</returns>
        public static bool CheckPhone(string str)//检查固定电话是否合法 合法返回 true
        {
            Regex phoneReg = new Regex(@"^(\d{3,4}-)?\d{6,8}$");
            return phoneReg.IsMatch(str);
        }
        /// <summary>
        /// 检查QQ
        /// </summary>
        /// <param name="Str">qq字符串</param>
        /// <returns>合法返回 true</returns>
        public static bool CheckQQ(string Str)//QQ
        {
            Regex QQReg = new Regex(@"^\d{9,10}?$");
            return QQReg.IsMatch(Str);
        }
        /// <summary>
        /// 检查手机号
        /// </summary>
        /// <param name="Str">手机号</param>
        /// <returns>合法返回 true</returns>
        public static bool CheckCellPhone(string Str)//手机
        {
            Regex CellPhoneReg = new Regex(@"^1[358][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]$");
            return CellPhoneReg.IsMatch(Str);
        }
        /// <summary>
        /// 检查E-Mail是否合法
        /// </summary>
        /// <param name="Str">要检查的E-mail字符串</param>
        /// <returns>合法返回true</returns>
        public static bool CheckEMail(string Str)//E-mail
        {
            Regex emailReg = new Regex(@"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$");
            return emailReg.IsMatch(Str);
            
        }
        /// <summary>
        /// 验证两个日期是否合法
        /// </summary>
        /// <param name="date1">开始日期</param>
        /// <param name="date2">结束日期</param>
        /// <returns>通过验证返回 true</returns>
        public static bool DoValitTwoDatetime(string date1, string date2)//验证两个日期是否合法 包括合同日期 培训日期等 不能相同 不能前大后小
        {
            if (date1 == date2)//两个日期相同
            {
                return false;
            }
            TimeSpan ts = Convert.ToDateTime(date1) - Convert.ToDateTime(date2);//检查是否为前大后小
            
           
            if (ts.Days >0)
            {
                return false;
            }
            return true;//通过验证
        }
        /// <summary>
        /// 检查姓名是否合法
        /// </summary>
        /// <param name="nameStr">要检查的内容</param>
        /// <returns></returns>
        public static bool CheckName(string nameStr)//检查姓名是否合法
        {
            Regex nameReg = new Regex(@"^[\u4e00-\u9fa5]{0,}$");//为汉字
            Regex nameReg2 = new Regex(@"^\w+$");//字母
            if (nameReg.IsMatch(nameStr) || nameReg2.IsMatch(nameStr))//为汉字或字母
            {
                return true;
            }
            else
            {
                return false;
            }        
        }
    }
}
