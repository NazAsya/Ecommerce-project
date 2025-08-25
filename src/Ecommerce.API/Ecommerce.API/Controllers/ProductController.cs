using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    // READ - GET By Id
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
            return NotFound();
        var productDto = _mapper.Map<ProductDto>(product);
        return Ok(productDto);
    }
    // READ - GET All
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
       var products = await _productService.GetAllProductsAsync();
       var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);
      return Ok(productsDto);
    }

    // CREATE - POST
    [Authorize(Roles = "seller,admin")]
    [HttpPost]
    public async Task<IActionResult> PostProduct([FromBody] ProductCreateDto productCreateDto)
    {
      var product = _mapper.Map<Product>(productCreateDto);
       await _productService.AddProductAsync(product);

      var productDto = _mapper.Map<ProductDto>(product);
      return CreatedAtAction(nameof(GetById), new { id = productDto.Id }, productDto);
    }

    // UPDATE - PUT
    [Authorize(Roles = "seller,admin")]
    [HttpPut("update/{id}")]
    public async Task<IActionResult> PutProduct(Guid id, [FromBody] ProductUpdateDto productUpdateDto)
    {
       var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null) return NotFound();
        
        _mapper.Map(productUpdateDto, existingProduct);
        await  _productService.UpdateProductAsync(existingProduct);
        var updatedDto = _mapper.Map<ProductDto>(existingProduct);
        return Ok("Product updated successfully.");
    }

    // DELETE - DELETE
    [Authorize(Roles = "seller")]
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
       var existingProduct = await _productService.GetProductByIdAsync(id);
        if (existingProduct == null)
        return NotFound();
        
        await _productService.DeleteProductAsync(id);
        return Ok("Product deleted successfully.");
    }

}
