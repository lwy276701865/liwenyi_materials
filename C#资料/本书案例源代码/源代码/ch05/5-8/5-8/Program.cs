using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_8
{
    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();   //定义委托NumManipulationHandler

        public event NumManipulationHandler ChangeNum;   //根据委托定义事件ChangeNum，当数字改变时触发

        protected virtual void OnNumChanged()   //定义虚方法OnNumChanged
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("数字发生改变，事件被触发");
            }
        }
        public EventTest(int n)
        {
            SetValue(n);
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();   //数字变化，先赋值再调用OnNumChanged方法
            }
        }
    }
    public class MainClass
    {
        public static void Main()
        {
            EventTest e = new EventTest(1);
            e.SetValue(2);
            e.SetValue(3);
            Console.ReadKey();
        }
    }
}
