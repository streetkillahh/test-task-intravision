using AutoMapper;
using VendingMachine.Domain.Dto;
using VendingMachine.Domain.Interfaces.Repositories;
using VendingMachine.Domain.Interfaces.Services;

namespace VendingMachine.Application.Services;

//public class CartService : ICartService
//{
//    private readonly IBaseRepository<Cart> _cartRepository;
//    private readonly IMapper _mapper;

//    public CartService(IUnitOfWork unitOfWork, IMapper mapper)
//    {
//        _cartRepository = unitOfWork.Carts;
//        _mapper = mapper;
//    }

//    public async Task AddToCartAsync(OrderItemDto itemDto)
//    {
//        var carts = await _cartRepository.FindAsync(c => c.ProductId == itemDto.ProductId);
//        var existing = carts.FirstOrDefault();

//        if (existing != null)
//        {
//            existing.Quantity += itemDto.Quantity;
//            _cartRepository.Update(existing);
//        }
//        else
//        {
//            var cartEntity = new Cart
//            {
//                ProductId = itemDto.ProductId,
//                ProductName = itemDto.ProductName,
//                BrandName = itemDto.BrandName,
//                Quantity = itemDto.Quantity,
//                PricePerItem = itemDto.PricePerItem
//            };
//            await _cartRepository.AddAsync(cartEntity);
//        }

//        await _cartRepository.SaveChangesAsync();
//    }

//    public async Task<List<OrderItemDto>> GetCartAsync()
//    {
//        var items = await _cartRepository.GetAll().ToListAsync();
//        return items.Select(cart => new OrderItemDto
//        {
//            ProductId = cart.ProductId,
//            ProductName = cart.ProductName,
//            BrandName = cart.BrandName,
//            Quantity = cart.Quantity,
//            PricePerItem = cart.PricePerItem
//        }).ToList();
//    }

//    public async Task RemoveFromCartAsync(int productId)
//    {
//        var items = await _cartRepository.FindAsync(c => c.ProductId == productId);
//        var toRemove = items.FirstOrDefault();
//        if (toRemove != null)
//        {
//            _cartRepository.Remove(toRemove);
//            await _cartRepository.SaveChangesAsync();
//        }
//    }

//    public async Task ClearCartAsync()
//    {
//        var all = await _cartRepository.GetAll().ToListAsync();
//        foreach (var item in all)
//        {
//            _cartRepository.Remove(item);
//        }

//        await _cartRepository.SaveChangesAsync();
//    }
//}
