using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //Arabalar için yeni liste oluştur.

        //Constructor bloğu
        public InMemoryCarDal()
        {
            _cars = new List<Car>  //Arabaları getirirken tabloyu yenile getir.
            {
                new Car{CarID=1,BrandID=1,ColorID=5,DailyPrice=3000,ModelYear=1998,Description="Toyota"},
                new Car{CarID=2,BrandID=2,ColorID=8,DailyPrice=2000,ModelYear=1998,Description="Honda"},
                new Car{CarID=3,BrandID=3,ColorID=7,DailyPrice=1500,ModelYear=1998,Description="Hyundai"},
                new Car{CarID=4,BrandID=1,ColorID=4,DailyPrice=6000,ModelYear=1998,Description="BMW"},
                new Car{CarID=5,BrandID=3,ColorID=9,DailyPrice=7000,ModelYear=1998,Description="Mercedes"}

            };

        }
        public void Add(Car car) //Ekleme işlemini yap 
        {
            _cars.Add(car);
        }

        public void Delete(Car car) //Silme işlemini yap
        {
            //Her c için c'nin CarID'si benim gönderdiğim CarID'sine eşit mi? Eşitse onunla eşitle.
            Car carToDelete = _cars.SingleOrDefault(c => c.CarID == car.CarID);
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll() //Arabaların tümünü görüntüle
        {
            return _cars;
        }

        public List<Car> GetById(string Description )
        {
            return _cars.Where(c => c.Description == Description).ToList();
        }

        public void Update(Car car) //Güncelleme işlemini yap
        {
            //Gönderdiğim car ıd'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarID == car.CarID);

            //carToUpdete de ki değişkeni gönderdiğim carda istediğim değişkenle değiştirebilirsin.
            carToUpdate.BrandID = car.BrandID;
            carToUpdate.ColorID = car.ColorID;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
