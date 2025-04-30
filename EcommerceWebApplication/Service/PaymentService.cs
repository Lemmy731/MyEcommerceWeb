using EcommerceWebDomain.Dtos;
using EcommerceWebDomain.Entity;
using EcommerceWebDomain;
using EcommerceWebInfrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceWebApplication.IService;

namespace EcommerceWebApplication.Service
{
    public class PaymentService : IPaymentService
    { 

        private readonly IProductRepository _productRepository;
    
        public PaymentService(IProductRepository productRepository) 
        {
            _productRepository = productRepository; 
        }

        public async Task<ResponsePayment<ProductEntity>> Create(Productdtocs productDto)
        {
            var response =   await _productRepository.Create(productDto);   
            return response;
        }

        public async Task<ResponsePayment<List<ProductEntity>>> Get()
        {
            var response = await _productRepository.Get();  
            return response;    
        }

        public async Task<ResponsePayment<ProductEntity>> GetById(Guid id)
        {
            var response = await  _productRepository.GetById(id);
            return response;        
        }

        public async Task<ResponsePayment<ProductEntity>> Update(UpdateDto update)
        {
            var response = await _productRepository.Update(update); 
            return response;    
        }

        public async Task<ResponsePayment<ProductEntity>> Delete(Guid Id)
        {
            var response = await _productRepository.Delete(Id); 
            return response;
        }
    }

}
