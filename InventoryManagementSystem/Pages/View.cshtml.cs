using InventoryManagementSystem.DTOs;
using InventoryManagementSystem.DTOs.InventoryManagementSystem.DTOs;
using InventoryManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManagementSystem.Pages
{
    public class ViewModel : PageModel
    {
        private readonly ItemRepository _repository;

        public ViewModel(ItemRepository repository)
        {
            _repository = repository;
        }

        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public ItemDto? Item { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (Id == Guid.Empty)
            {
                return NotFound();
            }

            var item = await _repository.GetByIdAsync(Id);
            if (item == null)
            {
                return NotFound();
            }

            Item = ItemDto.FromModel(item);
            return Page();
        }
    }
}
