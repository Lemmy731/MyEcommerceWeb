using EcommerceWebDomain.Dtos;
using EcommerceWebDomain.Entity;
using EcommerceWebDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebInfrastructure.IRepository
{
    public interface IProductRepository
    {
        Task<ResponsePayment<ProductEntity>> Create(Productdtocs productDto);
        Task<ResponsePayment<List<ProductEntity>>> Get();
        Task<ResponsePayment<ProductEntity>> GetById(Guid id);
        Task<ResponsePayment<ProductEntity>> Update(UpdateDto update);
        Task<ResponsePayment<ProductEntity>> Delete(Guid Id);

    }
}
