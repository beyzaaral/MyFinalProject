using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstarct
{
    //product ile ilgili veri tabanında yapılacak operasyonları(ekleme çıkarma gücelleme) içeren interface
    //interface'in kendisi public değil operasyonları public'tir.
    // ampul çıkınca 'add referance to entities' basınca otomatik referance eder.
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();
    }
}
