using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
    //简单工厂模式 存在增加一个新车型即需要新增加一个车类，都要在工厂类中增加相应的创建业务逻辑需要新增case），
    //这显然是违背开闭原则的
    //如何解决 每个车型（车类），一个工厂类来创建
    //1.工厂类定义成了接口,而每新增的车种类型,就增加该车种类型对应工厂类的实现,
    //2.这样工厂的设计就可以扩展了,而不必去修改原来的代码
    //这就是工厂方法模式 解决一个产品簇 产品创建问题，比如 车类 有越野 跑车 都继承车类
    //步骤 抽象产品类、具体产品类、抽象工厂类，具体工厂类
    public interface ICar //接口类 抽象产品（Product）角色
    {
        void Work();
    }
    //工厂抽象类
    public interface IFactory
    {
        ICar GetCar();//工厂方法 创建对象
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
    public class Hatchcar : ICar
    {
        //属性
        public Hatchcar()
        {
            Console.WriteLine("A Hatchcar");
        }
        //方法
        public void Work()
        {
            Console.WriteLine("Run a Hatchcar");
        }
        //...
    }

    //具体工厂类
    public class SportFactory : IFactory  //创建Sportcar工厂类 返回Sportcar对象
    {
        public ICar GetCar()
        {
            return new Sportcar();
        }
    }
    public class JeepFactory : IFactory  //创建Jeepcar工厂类 返回Jeepcar对象
    {
        public ICar GetCar()
        {
            return new Jeepcar();
        }
    }
    public class HatchFactory : IFactory  //创建Hatchcar工厂类 返回Hatchcar对象
    {
        public ICar GetCar()
        {
            return new Hatchcar();
        }
    }
    //4S店 订购 创建Servicshop 提供订购方法 业务逻辑
    class Servicshop
    {
        IFactory sf = null;
        public Servicshop(IFactory sf1)//传递 具体工厂类
        {
            sf = sf1;
        }
        public ICar Order()//更加参数确定订购哪钟车
        {
            return sf.GetCar();
        }
        //
    }
    public class Client
    {
        public static void Main(String[] args)
        {
            IFactory sf = new SportFactory();//具体工厂类
            IFactory jf = new JeepFactory();
            IFactory hf = new HatchFactory();
            Servicshop ss = new Servicshop(sf);
            Servicshop ss1 = new Servicshop(jf);
            Servicshop ss2 = new Servicshop(hf);
            ss.Order();
            ss1.Order();
            ss2.Order();
        }
    }
    //典型的解耦框架。高层模块只需要知道产品的抽象类，其他的实现类都不需要关心，
    //符合迪米特法则，符合依赖倒置原则，符合里氏替换原则。
}
