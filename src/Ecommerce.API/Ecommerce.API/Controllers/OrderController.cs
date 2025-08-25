using AutoMapper;
using Ecommerce.API.DTOs;
using Ecommerce.API.Models;
using Ecommerce.API.Services;
using global::Ecommerce.API.Models;
using global::Ecommerce.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("[controller]")]

public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;
    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderService.GetOrderByIdAsync(id);
        if (order == null)
            return NotFound();
        var orderDto = _mapper.Map<OrderDto>(order);
        return Ok(orderDto);
    }
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        var ordersDto = _mapper.Map<IEnumerable<OrderDto>>(orders);
        return Ok(ordersDto);
    }
    
    
    [Authorize(Roles = "admin,customer")]
    [HttpGet("byuser/{userId:guid}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var orders = await _orderService.GetOrdersByUserIdAsync(userId);
        if (orders == null) return NotFound();

        var dtoList = _mapper.Map<IEnumerable<OrderItemDto>>(orders);
        return Ok(dtoList);
    }

    
    [Authorize(Roles = "seller,admin")]
    [HttpPost]
    public async Task<IActionResult> Create(OrderCreateDto orderCreateDto)
    {
        var order = _mapper.Map<Order>(orderCreateDto);
        await _orderService.AddOrderAsync(order);
        var dto = _mapper.Map<OrderDto>(order);
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
    }
    [Authorize(Roles = "seller,admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutOrder(Guid id, OrderUpdateDto orderUpdateDto)
        {
            var existing = await _orderService.GetOrderByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(orderUpdateDto, existing);
            await _orderService.UpdateOrderAsync(existing);
            return Ok("İtem updated successfully.");
        }
    [Authorize(Roles = "seller")]
    [HttpDelete("{id:guid}")]
        
       public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var existingOrder = await _orderService.GetOrderByIdAsync(id);
            if (existingOrder == null)
                return NotFound();

            await _orderService.DeleteOrderAsync(id);
            return Ok("Oder deleted successfully.");
        }
 }
