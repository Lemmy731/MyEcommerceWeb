using Azure;
using EcommerceWebDomain;
using EcommerceWebDomain.Dtos;
using EcommerceWebDomain.Entity;
using EcommerceWebInfrastructure.Data;
using EcommerceWebInfrastructure.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebInfrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context; 
        }      

        public async Task<ResponsePayment<ProductEntity>> Create(Productdtocs productDto)
        {
            var productdto = new ProductEntity
            {
                Name = productDto.Name,
                Description = productDto.Description,
                ImageUrl = productDto.ImageUrl,
                Price = productDto.Price
            };

            var response = await _context.Products.AddAsync(productdto); 
            
            var result = await _context.SaveChangesAsync();

            //var responses = new ResponsePayment<string>();

            if (result > 0)
            {

                var results = ResponsePayment<ProductEntity>.Success("product added successfully", productdto, 200);
                return results;
            }
            else
            {
                var results = ResponsePayment<ProductEntity>.Fail("unable to create product", 400);
                return results;

            }

          
        }

        public async Task<ResponsePayment<List<ProductEntity>>> Get() 
        {   

            var response = await _context.Products.ToListAsync();

            if (response != null)
            { 
               var result = ResponsePayment<List<ProductEntity>>.Success("successful", response, 200);
               return result;
            }
            else
            {
                var result = ResponsePayment<List<ProductEntity>>.Fail("fail to get products", 400);
                return result;
            }
        }

        
        public async Task<ResponsePayment<ProductEntity>> GetById(Guid id)
        {

            var response = await _context.Products.FirstAsync(x => x.Id == id);

            if (response.Id == id)
            {
                var result = ResponsePayment<ProductEntity>.Success("successful", response, 200);
                return result;
            }
            else
            {
                var result = ResponsePayment<ProductEntity>.Fail("fail to get product", 400);
                return result;
            }
        }

        public async Task<ResponsePayment<ProductEntity>> Update(UpdateDto update)
        {

            var response = await _context.Products.FirstOrDefaultAsync(x => x.Id == update.Id);

            if (response != null)
            {
                if(update.Price != 0)
                {
                    response.Price = update.Price;
                }
                if (update.ImageUrl != string.Empty)
                {
                    response.ImageUrl = update.ImageUrl;
                }
                if (update.Description != string.Empty)
                {
                    response.Description = update.Description;
                }
                if (update.Name != string.Empty)
                {
                    response.Name = update.Name;
                }
                _context.Products.Update(response);
                var result = await _context.SaveChangesAsync();
               
                    var results = ResponsePayment<ProductEntity>.Success("successful", response, 200);
                    return results;
               
            }
            else
            {
                var result = ResponsePayment<ProductEntity>.Fail("fail to update", 400);
                return result;
            }
        }

        public async Task<ResponsePayment<ProductEntity>> Delete(Guid Id)
        {

            var response = await _context.Products.FirstAsync(x => x.Id == Id); 

            if (response.Id == Id)
            {
                
                _context.Products.Remove(response);
                var result = await _context.SaveChangesAsync();

                var results = ResponsePayment<ProductEntity>.Success("delete successful", response, 200);
                return results;

            }
            else
            {
                var result = ResponsePayment<ProductEntity>.Fail("fail to delete", 400);
                return result;
            }
        }

    }
}
