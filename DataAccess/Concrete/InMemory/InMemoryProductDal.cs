using DataAccess.Abstarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        //class içinde olup metot dışında olan değişkenlere Global değişken denir. o class için global
        //.Net projelerinde isimlendirme standartı olaraka önüne alt çizgi konulur. Naming Conventions - isimlendirme standartı
        List<Product> _products;
        //referans tip tek başına bir anlam ifade etmez.Sadece değişken oluşturulmuş olur.
        public InMemoryProductDal()   //Constructor yapı
        {
            //oracle, sql server, Postgres, MongoDb 'den geliyormuş gibi simile ediliyor.
            _products = new List<Product> {    //içinde ürünler listenecek.
                new Product{ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product{ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product{ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product{ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product{ProductId = 5, CategoryId = 2, ProductName = "Bardak", UnitPrice = 85, UnitsInStock = 1},
            } ;
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        //referans tipler, referans numaraları üzerinden gider.
        //Ürünlerde aynı referans numarasına sahip olmadıkları için
        //arayüzden bir tane ürün new'leyip gönderdiğinde ID'si aynı bile
        //olsa farklı referans değerde olduğu için sil işlemi yap denilse bile yapmaz.
        //ürünleri silerken PK(primary key) kullanılır.
        //LİNQ - language ıntergrated query
        {
            //Product productToDelete = null;
            //bu kod listeyi tek tek dolaşarak silinecek ürünü bulmaya yarar.
            //foreach (var p in _products)
            //{
            //    //liste dolandıktan sonra şart koşarak ürünü ıd ile eşleştirip siler.
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //} 
            //productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //bu yapı kullanılsaydı ürünler arasında dolanarak bulacaktı ama linq yapısı olduğu için daha kısa yapısı var.

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
            //linq kullanıldığında kod bu kadar oluyor.
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        //producttodelete=silinicek ürün 

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p => p.CategoryId == categoryId).ToList();
            //where koşulu içindeki şarta uyan tüm elemanları yeni bir liste haline getirir ve onu döndürür.
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //gönderdiğim ürün ıd'sine sahip olan ürünıd'sini bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate .ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate .UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            //güncellenecek olan ürünün ıd'si = ürün ıd'si
        }
    }
}

//Constructor - nesne yönelimli programlama kavramı içerisinde bulunan sınıf yapılarının nesne
//olarak tanımlamasında alt yapıyı hazırlayan, kurucu rölü üstlenen, sınıf ismi ile aynı isme sahip olan,
//geriye değer döndürmeyen fonksyion türleridir.

//Singleordefoult - dizinin tek öğesini veya dizi boşsa varsayılan değeri döndür. özetle datayı getir.
