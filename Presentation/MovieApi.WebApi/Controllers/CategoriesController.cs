using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.CategoryQueries;
using MovieApi.Domain.Entities;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly GetCategoryQueryHandler _getCategoriesQueryHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;

        public CategoriesController(GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoriesQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler, CreateCategoryCommandHandler createCategoryCommandHandler)
        {
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoriesQueryHandler = getCategoriesQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
            _createCategoryCommandHandler = createCategoryCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getCategoriesQueryHandler.Handle();
            return Ok(result);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(result);

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
             await _createCategoryCommandHandler.Handle(command);
             return Ok("Kayıt Başarılı ! ");
            //return Ok(await _createCategoryCommandHandler.Handle(command));
        }
        [HttpPost("[action]")]
        public async Task <IActionResult> Remove(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kayıt Silindi ! ");
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            await _updateCategoryCommandHandler.Handle(command);
            return Ok("Kayıt Güncellendi ! ");
        }
    }
}
