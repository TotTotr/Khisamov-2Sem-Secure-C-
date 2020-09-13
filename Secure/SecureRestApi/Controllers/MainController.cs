using SecureLogic.BindingModels;
using SecureLogic.BusinessLogic;
using SecureLogic.Interfaces;
using SecureLogic.ViewModels;
using SecureRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecureShopRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IOrderLogic _order;

        private readonly IKomlectLogic _product;

        private readonly MainLogic _main;

        public MainController(IOrderLogic order, IKomlectLogic product, MainLogic main)
        {
            _order = order;
            _product = product;
            _main = main;
        }
        [HttpGet] public List<KomlectModel> GetProductList() => _product.Read(null)?.Select(rec => Convert(rec)).ToList();

        [HttpGet] public KomlectModel GetProduct(int productId) => Convert(_product.Read(new KomlectConcreteBindingModel { Id = productId })?[0]);

        [HttpGet] public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpPost] public void CreateOrder(CreateOrderBindingModel model) => _main.CreateOrder(model);

        private KomlectModel Convert(KomlectViewModel model)
        {
            if (model == null) return null;

            return new KomlectModel
            {
                Id = model.Id,
                KomlectName = model.KomlectName,
                Price = model.Price
            };
        }
    }
}
