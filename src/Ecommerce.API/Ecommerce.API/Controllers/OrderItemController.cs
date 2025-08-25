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

public class OrderItemController : ControllerBase
{
    private readonly IOrderItemService _orderItemService;
    private readonly IMapper _mapper;
    public OrderItemController(IOrderItemService orderItemService, IMapper mapper)
    {
        _orderItemService = orderItemService;
        _mapper = mapper;
    }
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _orderItemService.GetOrderByIdAsync(id);
        if (item == null) return NotFound();
        var dto = _mapper.Map<OrderItemDto>(item);
        // .map<TDestination>(source) metodu AutoMapper'ın temel eşleme metodudur. Source kaynak nesneyi ifade eder, yani kaynak nesne dönüştürmek istediğimiz, orjinal nesnedir. TDestination kısmı da hedef türümüzü belirtir yani orjinal nesneyi, kaynak nesnemizi dönüştürmek istediğimiz türü belirtir.
        //Burada biz veritabanından ve orderitem entitysinden gelen item nesnesini OrderItem Dto'ya dönüştürmek istediğimizi yazıyoruz aslında.
        return Ok(dto);
    }
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _orderItemService.GetAllAsync();
        var dtoList = _mapper.Map<IEnumerable<OrderItemDto>>(items);
        return Ok(dtoList);
    }
    [Authorize(Roles = "customer,seller,admin")]
    [HttpGet("byorder/{orderId:guid}")]
    public async Task<IActionResult> GetByOrderId(Guid orderId)
    {
        var items = await _orderItemService.GetOrderByIdAsync(orderId);
        if (items == null) return NotFound();
        
        var dtoList = _mapper.Map<IEnumerable<OrderItemDto>>(items);
        return Ok(dtoList);
    }
    [Authorize(Roles = "seller,admin")]
    [HttpPost]
    public async Task<IActionResult> Create(OrderItemCreateDto createDto)
    //Parantez içindeki createDto, HTTP isteğinin gövdesinden gelen veriyi temsil eden bir parametredir. Bu parametre, kullanıcıdan alınan verileri içeren OrderItemCreateDto tipindedir. Yani createDto aslında OrderItemCreateDto veri tipindedir.
    {
        var orderItem = _mapper.Map<OrderItem>(createDto);
        //Burada kullanıcıdan aldığımız CreateDto nesnesi, veritabanına kaydedilecek olan OrderItem nesnesine dönüştürülür. Yani DTO entity dönüşümü gerçekleşir.
        await _orderItemService.AddOrderItemAsync(orderItem);
        //orderItem nesnesini veritabanına ekledik.
        var dto = _mapper.Map<OrderItemDto>(orderItem);
        //Bu kısım, veritabanına kaydedilmiş ve artık bir Id değeri olan orderItem nesnesini, API'nin dışarıya göndereceği DTO'ya (OrderItemDto) dönüştürür. Yani bu sefer bir entity DTO dönüşümü yaptık.
        return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
        //Buradaki CreatedAction bir durum kodunu döndüren özel bir metottur. Bu durum kodu, yeni bir kaynağın başarıyla eklendiğini belirtir.
    }
    [Authorize(Roles = "seller,admin")]
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> PutOrderItem(Guid id, OrderItemUpdateDto updateDto)
    // Burada parantez içindeki kısım metodun aldığı parametredir. id: URL'den gelen, güncellenecek sipariş öğesinin benzersiz kimliğidir. updateDto ise gelen veriyi temsil eder ve OrderItemUpdateDto tipindedir.
    {
        var existing = await _orderItemService.GetOrderItemByIdAsync(id);
        if (existing == null) return NotFound();
        //_orderItemService.GetOrderItemByIdAsync(id): Güncellenmek istenen sipariş öğesinin veritabanında var olup olmadığı kontrol edilir. id parametresini kullanarak ilgili OrderItem nesnesi veritabanından getirilir. Yani bu kısım yukarıdaki parametre kısmında verdiğimiz id ile ilgili kısımdır.

        _mapper.Map(updateDto, existing);
        //Bu, kaynak (updateDto) nesnesindeki verileri, hedef (existing) nesnesinin üzerine yazar. AutoMapper, updateDto'daki alanları, existing nesnesindeki karşılık gelen alanlarla eşler ve günceller.
        await _orderItemService.UpdateOrderItemAsync(existing);
        //Bu satır, güncellenmiş existing nesnesini servis katmanına gönderir. Servis katmanı, bu nesneyi veritabanında güncelleyerek değişiklikleri kalıcı hale getirir.
        return Ok("İtem updated successfully.");
    }
    [Authorize(Roles = "seller")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteOrderıtem(Guid id)
    {
        var existing = await _orderItemService.GetOrderItemByIdAsync(id);
        if (existing == null)
            return NotFound();

        await _orderItemService.DeleteOrderItemAsync(id);
        return Ok("Oder deleted successfully.");
    }

}