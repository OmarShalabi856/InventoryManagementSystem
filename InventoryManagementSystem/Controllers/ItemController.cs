using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.DTOs.InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Repository;
using InventoryManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ItemRepository _repository;
        private readonly OpenAIService _openAIService;
        private readonly ILogger<ItemController> _logger;

        public ItemController(ItemRepository repository, OpenAIService openAIService, ILogger<ItemController> logger)
        {
            _repository = repository;
            _openAIService = openAIService;
            _logger = logger;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> AskInventory([FromBody] string question)
        {
            try
            {
                var items = await _repository.GetAllAsync();
                var inventoryData = items.Select(i => $"{i.Name} (Qty: {i.Quantity}, Status: {i.Status})");
                var inventoryContext = "Here is the current inventory data:\n" + string.Join("\n", inventoryData);

                var answer = await _openAIService.ChatCompletion(inventoryContext, question);

                return Ok(new { answer });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing inventory question");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                var result = items.Select(i => ItemDto.FromModel(i));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all items");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var item = await _repository.GetByIdAsync(id);
                if (item == null)
                    return NotFound();

                return Ok(ItemDto.FromModel(item));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching item with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateItemDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var item = dto.ToModel();
                await _repository.AddAsync(item);
                return CreatedAtAction(nameof(GetById), new { id = item.Id }, ItemDto.FromModel(item));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating item");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateItemDto updateItemDto)

        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                if (id != updateItemDto.Id)
                    return BadRequest("ID mismatch");

                var existingItem = await _repository.GetByIdAsync(id);
                if (existingItem == null)
                    return NotFound();

                var item = updateItemDto.ToModel(existingItem);
                await _repository.UpdateAsync(item);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating item with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateStatusDto dto)
        {
            try
            {
                var existingItem = await _repository.GetByIdAsync(id);
                if (existingItem == null)
                    return NotFound();

                await _repository.UpdateStatusAsync(id, dto.Status);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating status for item with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var existingItem = await _repository.GetByIdAsync(id);
                if (existingItem == null)
                    return NotFound();

                await _repository.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting item with id {id}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(
            [FromQuery] string? name,
            [FromQuery] string? category,
            [FromQuery] InventoryStatus? status,
            [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice,
            [FromQuery] int? minQuantity,
            [FromQuery] int? maxQuantity)
        {
            try
            {
                var results = await _repository.SearchAsync(name, category, status, minPrice, maxPrice, minQuantity, maxQuantity);
                var dtoResults = results.Select(i => ItemDto.FromModel(i));
                return Ok(dtoResults);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching items");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
