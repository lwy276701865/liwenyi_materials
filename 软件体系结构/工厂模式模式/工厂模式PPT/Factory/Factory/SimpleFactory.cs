using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
    //为了解决无工厂 创建车对象和4S店的耦合，不符合单一职责原则
    //建立一个工厂对象 负责单独建立车这类对象
    //简单工厂模式，用一个工厂类 建立车这类对象，4S店通过工厂类订购具体车
    //首先 需要一个抽象 Car类或 ICar接口
    public interface ICar //接口类 抽象产品（Product）角色
    {
        void Work();
    }

    public class Sportcar : ICar //具体产品（Concrete Product）角色
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
    public class Jeepcar : ICar
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
    //public class Hatchcar : ICar
    //{
    //    //属性
    //    public Hatchcar()
    //    {
    //        Console.WriteLine("A Hatchcar");
    //    }
    //    //方法
    //    public void Work()
    //    {
    //        Console.WriteLine("Run a Hatchcar");
    //    }
    //    //...
    //}
    //创建简单工厂 可以创建Car这类对象
    public class SimpleFactory  //工厂（Creator）角色
    {
        public ICar GetCar(String carType)
        {
            switch (carType)
            {
                case "Sport":
                    return new Sportcar();
                case "Jeep":
                    return new Jeepcar();
                //case "Hatch":
                //    //....
                default:
                    throw new Exception("爱上一匹野马,可我的家里没有草原. 你走吧！");
            }
        }
    }//将再增加 两厢车时，除了创建对应 两厢车类外，还需要修改 工厂类,违背开闭原则的

    //4S店 订购 创建Servicshop 提供订购方法 业务逻辑
    class Servicshop
    {
        SimpleFactory sf = null;
        public Servicshop(SimpleFactory sf1)
        {
            sf = sf1;
        }
        public ICar Order(string car)//更加参数确定订购哪钟车
        {
            return sf.GetCar(car);
        }
        //订购业务逻辑 和创建车对象逻辑实现 分开
    }
    public class Client
    {
        public static void Main(String[] args)
        {
            SimpleFactory sf = new SimpleFactory();
            Servicshop ss = new Servicshop(sf);
            ss.Order("Sport");
            ss.Order("Jeep");
        }
    }
    //简单工厂模式 将创建对象逻辑和业务处理逻辑分开，业务处理只需关注如何使用对象
    //而不必管这些对象究竟如何创建及如何组织的．明确了各自的职责和权利，有利于整个软件体系结构的优化。

    //缺点：
    //由于工厂类集中了所有实例的创建逻辑，违反了高内聚责任分配原则，将全部创建逻辑集中到了一个工厂类中；
    //它所能创建的类只能是事先考虑到的，如果需要添加新的类，则就需要改变工厂类了。违背开闭原则的
    //当系统中的具体产品类不断增多时候，可能会出现要求工厂类根据不同条件创建不同实例的需求．
    //这种对条件的判断和对具体产品类型的判断交错在一起，很难避免模块功能的蔓延，对系统的维护和扩展非常不利；
    
}
