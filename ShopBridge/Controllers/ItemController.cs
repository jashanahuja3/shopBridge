using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridge.Models;
using ShopBridge.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Policy = "ProductAdmin")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly IItemService _itemService;

        public ItemController(
            ILogger<ItemController> logger,
            IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        [HttpGet]
        [Route("getitem")]
        public async Task<IActionResult> GetItem()
        {
            try
            {
                List<Item> items = await _itemService.GetItems();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured ItemController.GetItem. User {User.Identity.Name}, message {ex.Message}");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("additem")]
        public async Task<IActionResult> AddItem([FromBody] Item item)
        {
            try
            {
                bool isAdded = await _itemService.AddItem(item);
                return Ok($"Item {item.Name} successfully added");
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error occured ItemController.AddItem. User {User.Identity.Name}, message {ex.Message}");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deleteitem")]
        public async Task<IActionResult> DeleteItem([FromBody] Guid itemId)
        {
            try
            {
                bool isDeleted = await _itemService.DeleteItem(itemId);
                return Ok($"Item {itemId} deleted");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured ItemController.DeleteItem. User {User.Identity.Name}, message {ex.Message}");
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("{itemId}/update")]
        public async Task<IActionResult> UpdateItem([FromRoute] Guid itemId, [FromBody] Item item)
        {
            try
            {
                bool isUpdated= await _itemService.UpdateItem(itemId, item);
                return Ok($"Item {itemId} updated");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error occured ItemController.UpdateItem. User {User.Identity.Name}, message {ex.Message}");
                return BadRequest(ex);
            }
        }

    }
}
