using Microsoft.AspNetCore.Mvc;
using Shopping.Services.ProductAPI.Models.Dto;
using Shopping.Services.ProductAPI.Repository;

namespace Shopping.Services.ProductAPI.Controllers
{
    [Route("api/Products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepsotory _productRepsotory;

        public ProductAPIController(IProductRepsotory productRepsotory)
        {
            _productRepsotory = productRepsotory;
            this._response = new ResponseDto();
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> model = await _productRepsotory.GetProducts();
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto model = await _productRepsotory.GetProductById(id);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepsotory.CreateUpateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepsotory.CreateUpateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<object> Delete(int productId)
        {
            try
            {
                _response.IsSuccess = await _productRepsotory.DeleteProduct(productId);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
