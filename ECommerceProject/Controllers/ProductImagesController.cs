using Business.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] ProductImageDto productImageDto)
        {
            ProductImage image = new ProductImage();
            if (productImageDto != null)
            {
                var extension = Path.GetExtension(productImageDto.ImageFileName.FileName);
                var newImageName = Guid.NewGuid() + extension;
                var placeToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newImageName);
                using (var stream = new FileStream(placeToSave, FileMode.Create))
                {
                    productImageDto.ImageFileName.CopyTo(stream);
                }
                image.ImagePath = newImageName;
            }
            image.Id = productImageDto.Id;
            image.ProductId = productImageDto.ProductId;
            image.Date = DateTime.Now;
            var result = _productImageService.Add(image);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}