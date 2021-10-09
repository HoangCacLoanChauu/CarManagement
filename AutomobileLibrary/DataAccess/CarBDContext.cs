using AutomobileLibrary.BussinessObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileLibrary.DataAccess
{
    class CarBDContext
    {
        //khởi tạo car list generic
        private static List<Car> CarList = new List<Car>()
        {
            new Car{ CarID=1, CarName ="CRV", Manufacturer ="Honda",
            Price =123456, ReleaseYear= 2020},
            new Car{ CarID=2, CarName ="Mercs", Manufacturer ="Mercs",
            Price =123456, ReleaseYear= 2020}
        };
        //Single Pattern
        private static CarBDContext instance = null;
        private static readonly object instanceLock = new object();
        private CarBDContext() { }
            //READ ONLY
                // biến static tên Instance
        public static CarBDContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    // nếu null mới cấp phát
                    if (instance == null)
                    {
                        instance = new CarBDContext();
                    }
                 //   có rồi sẽ lấy sử dụng
                    return instance;
                }
            }
        }
        //===========================================
        public List<Car> GetCarList => CarList;
        //-----------------
        public Car GetCarByID(int carID)
        {
            // using LINQ to object
            Car car = CarList.SingleOrDefault(pro => pro.CarID == carID);
            return car;
        }
        //========== Add new Car =============
        public void AddNewCar(Car car)
        {
            Car pro = GetCarByID(car.CarID);
            if(pro == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already exists");
            }
        }
        //========== Update a Car =============
        public void Update(Car car)
        {
            Car u = GetCarByID(car.CarID);
            if(u != null)
            {
                var index = CarList.IndexOf(u);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not exists");
            }

        }
        //========== Remove a Car =============
        public void Remove(int CarID)
        {
            Car r = GetCarByID(CarID);
            if(r!= null)
            {
                CarList.Remove(r);
            }
            else
            {
                throw new Exception("Car does not exists");
            }
        }


    }
}
