using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Atlantic.Api.Data.EcommerceDataContext.Repositories;
using Atlantic.Api.Data.EcommerceDataContext.Repositories.Interfaces;
using Atlantic.Api.Facades.Core;
using Atlantic.Api.Facades.Interfaces;
using Atlantic.Api.Facades.Validators;
using Atlantic.Api.Models.Context.Products;
using Atlantic.Api.Models.DTOs;
using Atlantic.Api.Models.Responses;

namespace Atlantic.Api.Facades
{
    public class CategoriesFacade : BaseFacade, ICategoriesFacade
    {
        private ICategoriesRepository _categoriesRepository;
        private IProductsRepository _productsRepository;

        public CategoriesFacade(
                CommonDependenciesFacade commonDependenciesFacade,
                ICategoriesRepository categoriesRepository,
                IProductsRepository productsRepository
            )
            : base(commonDependenciesFacade)
        {
            _categoriesRepository = categoriesRepository;
            _productsRepository = productsRepository;
        }

        public ListCategoriesResponse GetAll(int page, int pageSize, string term)
        {
            return _categoriesRepository.GetAll(page, pageSize, term);
        }

        public async Task<BaseResponse> InsertCategoryAsync(CategoryDTO category)
        {
            try
            {
                var validator = new CategoryValidador().Validate(category);
                var validate = ValidatorHelper.Validate(validator);
                if (validate != null)
                    return validate;

                var categoryToAdd = new Category()
                {
                    name = category.name,
                    subCategories = category.subCategories,
                    updatedDate = DateTime.Now,
                    createdDate = DateTime.Now
                };

                var result = await _categoriesRepository.InsertAsync(categoryToAdd);

                return new BaseResponse() { Code = HttpStatusCode.Created, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public async Task<BaseResponse> UpdateCategoryAsync(string id, CategoryDTO category)
        {
            try
            {
                var validator = new CategoryValidador().Validate(category);
                var validate = ValidatorHelper.Validate(validator);
                if (validate != null)
                    return validate;

                var idCategory = new MongoDB.Bson.ObjectId(id);

                var categoryToUpdate = new Category()
                {
                    id = idCategory,
                    name = category.name,
                    subCategories = category.subCategories,
                    updatedDate = DateTime.Now
                };

                var productsWithCategory = await _productsRepository.GeyByCategoryIdAsync(idCategory);

                foreach (var p in productsWithCategory)
                {
                    var idProduct = p.id;
                    List<Category> categories = p.categories.FindAll(x => x.id != idCategory);
                    var existentCategoryProduct = p.categories.Find(x => x.id == idCategory);

                    if (existentCategoryProduct != null)
                    {
                        categories.Add(categoryToUpdate);
                    }

                    p.categories = categories;

                    await _productsRepository.UpdateAsync(p.id, p);
                }

                category.updatedDate = DateTime.Now;

                var result = await _categoriesRepository.UpdateAsync(idCategory, categoryToUpdate);

                return new BaseResponse() { Code = HttpStatusCode.OK, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }

        public async Task<BaseResponse> DeleteCategoryAsync(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return new BaseResponse() { Code = HttpStatusCode.BadRequest, Message = "Id must not be empty" };
                }

                var idCategory = new MongoDB.Bson.ObjectId(id);

                var productsWithCategory = await _productsRepository.GeyByCategoryIdAsync(idCategory);
                if (productsWithCategory.Count > 0)
                {
                    return new BaseResponse() { Code = HttpStatusCode.BadRequest, Result = "There is product with current category. Category cannot be deleted." };
                }

                var result = await _categoriesRepository.DeleteAsync(idCategory);

                return new BaseResponse() { Code = HttpStatusCode.OK, Result = result };
            }
            catch (Exception ex)
            {
                Logger.Error("Error on insert product. Error: {E}", ex.Message);
                return new BaseResponse() { Code = HttpStatusCode.InternalServerError, Message = ex.Message };
            }
        }
    }
}
