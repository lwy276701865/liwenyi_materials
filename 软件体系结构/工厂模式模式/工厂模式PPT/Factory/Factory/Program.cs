using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Factory
{
   //工厂方法模式 可以解决一个产品簇 产品的创建，如果还有另外一个不同产品簇 需要创建 如何解决
    //比如 订购 车 还有订购背包 这个2个实现过程不同 所以需要2个 抽象产品类

    public interface ICar //接口类 抽象产品（Product）角色
    {
        void Work();
    }
     public interface IBackpack //接口类 抽象产品（Product）角色
    {
        void Use1();
    }
    //工厂抽象类
    public interface AbstractFactory
    {
        /// 抽象方法： 创建一辆车
        ICar GetCar();
        /// 抽象方法： 创建背包
        IBackpack GetBackpack();
    }

    
    public class Sportcar:ICar //具体产品（Concrete Product）角色
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
    public class Jeepcar:ICar
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

    public class SportBackpack : IBackpack
    {
       public void Use1()
        {
            Console.WriteLine("Use a SportBackpack");
        }
    }
    public class JeepBackpack : IBackpack
    {
       public void Use1()
        {
            Console.WriteLine("Use a JeepBackpack");
        }
    }
    //具体工厂类
    public class SportFactory : AbstractFactory  //创建Sportcar工厂类 返回Sportcar对象
    {
        public ICar GetCar()
        {
            return new Sportcar();
        }
        public IBackpack GetBackpack()
        {
            return new SportBackpack();
        }
    }
    public class JeepFactory : AbstractFactory   //创建Jeepcar工厂类 返回Jeepcar对象
    {
        public ICar GetCar()
        {
            return new Jeepcar();
        }
        public IBackpack GetBackpack()
        {
            return new JeepBackpack();
        }
    }
    //public class HatchFactory : IFactory  //创建Hatchcar工厂类 返回Hatchcar对象
    //{
    //    public ICar GetCar()
    //    {
    //        return new Hatchcar();
    //    }
    //}
    //4S店 订购 创建Servicshop 提供订购方法  业务逻辑
    class Servicshop
    {
        AbstractFactory sf = null;
        public Servicshop(AbstractFactory sf1)//传递 具体工厂类
        {
            sf = sf1;
        }
        public ICar OrderCar()//
        {
           return  sf.GetCar();
           //sf.GetBackpack();
            //
        }
        public IBackpack OrderBackpack()//
        {
            return sf.GetBackpack();
        }
        //
    }
    public class Client
    {
        public static void Main(String[] args)
        {
            AbstractFactory sf = new SportFactory();//具体工厂类
            AbstractFactory jf = new JeepFactory();
           // AbstractFactory hf = new HatchFactory();
            Servicshop ss = new Servicshop(sf);
            Servicshop ss1 = new Servicshop(jf);
           // Servicshop ss2 = new Servicshop(hf);
            ss.OrderCar();
            ss.OrderBackpack().Use1();
            ss1.OrderCar();
            ss1.OrderBackpack().Use1();
            //ss2.Order();
        }
    }
    
}
