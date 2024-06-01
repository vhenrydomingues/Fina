using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Fina.api.Data;
using Fina.Core.Handlers;
using Fina.Core.Models;
using Fina.Core.Requests.Categories;
using Fina.Core.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace Fina.api.Handlers
{
    public class CategoryHandler(AppDbContext context) : ICategoryHandler
    {
        public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
        {
            try
            {
                var category = new Category
                {
                    UserId = request.UserId,
                    Title = request.Title,
                    Description = request.Description
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();                
                return new Response<Category?>(category, 201, "Categoria criada com sucesso");
            }
            catch(Exception ex)
            {
                return new Response<Category?>(null, 500, "Não foi possivel registrar a categoria");
            }
        }

        public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 404, "Não foi possivel localizar a categoria");

                context.Categories.Remove(category);
                await context.SaveChangesAsync();                
                return new Response<Category?>(category, message:"Categoria excluida com sucesso");
            }
            catch(Exception ex)
            {
                return new Response<Category?>(null, 500, "Não foi possivel excluir a categoria");
            }
        }

        public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoryRequest request)
        {
            try
            {

                var query = context
                    .Categories
                    .AsNoTracking()
                    .Where(x => x.UserId == request.UserId)
                    .OrderBy(x => x.Title);
                var categories = await query
                    .Skip((request.PageNumber - 1) * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var count = await query.CountAsync();

                return new PagedResponse<List<Category>?>(
                    categories,
                    count,
                    request.PageNumber,
                    request.PageSize);
            }
            catch(Exception ex)
            {
                return new PagedResponse<List<Category>?>(null, 500, "Não foi possível consultar as categorias");
            }
        }

        public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
        {
            try
            {
                var category = await context
                .Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                return category is null 
                    ? new Response<Category?>(null, 404, "Não foi possivel localizar a categoria")
                    : new Response<Category?>(category);
            }
            catch(Exception ex)
            {
                return new Response<Category?>(null, 500, "Não foi possivel resgatar a categoria");
            }
        }

        public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
        {
            try
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == request.UserId);

                if (category is null)
                    return new Response<Category?>(null, 404, "Não foi possivel localizar a categoria");



                category.Title = request.Title;
                category.Description = request.Description;
                context.Categories.Update(category);
                await context.SaveChangesAsync();                
                return new Response<Category?>(category, message:"Categoria atualizada com sucesso");
            }
            catch(Exception ex)
            {
                return new Response<Category?>(null, 500, "Não foi possivel atualizar a categoria");
            }
        }
    }
}