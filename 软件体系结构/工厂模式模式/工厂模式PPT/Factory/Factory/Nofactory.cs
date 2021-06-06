using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{// 4s店订购 汽车 场景  订购 跑车Sportcar 越野车 Jeepcar
    // 无工厂 模式  
    //创建跑车 类
    public class Sportcar
    {
        //...属性
        public Sportcar()
        {
            Console.WriteLine("A Sportcar");
        }
        //方法
        public void Work()
        {
            Console.WriteLine("Run a Sportcar");
        }
        //...
    }
    //创建 Jeepcar 类
    public class Jeepcar
    {
        //属性
        public Jeepcar()
        {
            Console.WriteLine("A Jeepcar");
        }
        //方法
        public void Work()
        {
            Console.WriteLine("Run a Jeepcar");
        }
        //...
    }
    //4S店 订购 创建Servicshop 提供订购方法 业务逻辑
    class Servicshop
    {
        public void Order(string car)//订购越野车
        {
            Sportcar sc;
            Jeepcar jp;
            if (car.Equals("Sport"))
                sc = new Sportcar();
            else if (car.Equals("Jeep"))
                jp = new Jeepcar();
        }
    }
    public class Client
    {
        public static void Main(String[] args)
        {
            Servicshop ss = new Servicshop();
            ss.Order("Sport");
            ss.Order("Jeep");
        }
    }
    //无工厂模式 订购中包含 创建具体车的new代码逻辑 ，不符合单一职责原则，
    //4S店和车紧密耦合
}
