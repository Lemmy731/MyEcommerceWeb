using EcommerceWebApplication.IService;
using EcommerceWebDomain.Dtos;
using EcommerceWebDomain.Entity;
using EcommerceWebDomain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EcommerceWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public ProductController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ResponsePayment<ProductEntity>> Create(Productdtocs productDto)
        {
            try
            {
                var response = await _paymentService.Create(productDto);
                return response;


            }

            catch (Exception ex)
            {
                var results = ResponsePayment<ProductEntity>.Fail(ex.Message, 400);
                return results;
            }

        }

        [HttpGet]
        public async Task<ResponsePayment<List<ProductEntity>>> Get()
        {
            
                try
                {
                    var response = await _paymentService.Get();
                    return response;
                }

                catch (Exception ex)
                {
                    var results = ResponsePayment<List<ProductEntity>>.Fail(ex.Message, 400);
                    return results;
                }

            
        }

        [HttpGet("{id}")]
        public async Task<ResponsePayment<ProductEntity>> GetById(Guid id)
        {
            try
            {
                var response = await _paymentService.GetById(id);   
                return response;
            }

            catch (Exception ex)
            {
                var results = ResponsePayment<ProductEntity>.Fail(ex.Message, 400);
                return results;
            }
        }

        [HttpPut]
        public async Task<ResponsePayment<ProductEntity>> Update(UpdateDto update)
        {

            try
            {
                var response = await _paymentService.Update(update);
                return response;
            }

            catch (Exception ex)
            {
                var results = ResponsePayment<ProductEntity>.Fail(ex.Message, 400);
                return results;
            }


        }

        [HttpDelete]
        public async Task<ResponsePayment<ProductEntity>> Delete(Guid Id)
        {
            try
            {
                var response = await _paymentService.Delete(Id);
                return response;
            }

            catch (Exception ex)
            {
                var results = ResponsePayment<ProductEntity>.Fail(ex.Message, 400);
                return results;
            }

        }
   } 
        
}



    
