using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }


        /// <summary>
        /// Retorna todos os produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<ProductVO>>> FindAll()
        {
            var result = await _productRepository.FindAll();
            if (result == null) return NotFound();
            return Ok(result);
        }

        /// <summary>
        /// Retorna produto por ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(int id)
        {
            var result = await _productRepository.FindById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> Cadastrar(ProductVO product)
        {
            if (product == null) return Ok(BadRequest());
            var result = await _productRepository.Create(product);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> Alterar(ProductVO product)
        {
            if (product == null) return Ok(BadRequest());
            var result = await _productRepository.Update(product);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Deletar(int id)
        {
            if (id == 0) return Ok(BadRequest());
            var result = await _productRepository.Delete(id);
            return Ok(result);
        }
    }
}
