using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    // READ - GET By Id
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category== null) return NotFound();
        var categoryDto = _mapper.Map<CategoryDto>(category);
        return Ok(categoryDto);
    }
    // READ - GET All
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);
        return Ok(categoriesDto);
    }

    // CREATE - POST
    [Authorize(Roles = "seller,admin")]
    [HttpPost]
    public async Task<IActionResult> PostCategory(CategoryCreateDto categoryCreateDto)
    {
        var category = _mapper.Map<Category>(categoryCreateDto);
        await _categoryService.AddCategoryAsync(category);

        var categoryDto = _mapper.Map<CategoryDto>(category);
        return CreatedAtAction(nameof(GetById), new { id = categoryDto.Id }, categoryDto);
    }

    // UPDATE - PUT
    [Authorize(Roles = "seller,admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutCategory(Guid id, CategoryCreateDto categoryUpdateDto)
    {
        var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
        if (existingCategory == null) return NotFound();

        _mapper.Map(categoryUpdateDto, existingCategory);
        await _categoryService.UpdateCategoryAsync(existingCategory);

        var updatedDto = _mapper.Map<CategoryDto>(existingCategory);
        return Ok(updatedDto);
    }

    // DELETE - DELETE
    [Authorize(Roles = "seller, admin")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var existingCategory = await _categoryService.GetCategoryByIdAsync(id);
        if (existingCategory == null)
            return NotFound();

        await _categoryService.DeleteCategoryAsync(id);
        return Ok("Category deleted successfully.");
    }

}

