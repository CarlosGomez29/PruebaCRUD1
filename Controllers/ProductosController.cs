using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaCRUD1.DTOs;
using PruebaCRUD1.Services;

namespace PruebaCRUD1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly ProductosService _productosService;

        public ProductosController(ProductosService productosService)
        {
            _productosService = productosService;
        }

        [Route("ListarProductos")]
        [HttpGet]
        public async Task<IActionResult> ListarProductos()
        {
            try
            {
                List<ProductoDTO> listaProducto = await _productosService.ListarProductosDTOs();

                if (listaProducto.Count() == 0)
                {
                    return Ok("No hay productos creados");
                }

                return Ok(listaProducto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado. Intentelo mas tarde");
            }
        }

        [Route("CrearProducto")]
        [HttpPost]
        public async Task<IActionResult> CrearProducto([FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductoDTO productoCreado = await _productosService.CrearProductoDTO(productoDTO);

                return Ok(productoCreado);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al guardar el producto en la base de datos");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }
        }

        [Route ("EditarProducto")]
        [HttpPut]
        public async Task<IActionResult> EditarProducto([FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductoDTO productoEditado = await _productosService.EditarProductoDTO(productoDTO);

                return Ok(productoEditado);
            }
            catch (DbUpdateException)
            {
                return StatusCode (500, "Error al guardar el producto en la base de datos");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }
        }

        [Route("EliminarProducto")]
        [HttpDelete]
        public async Task<IActionResult> EliminarProducto(int a)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ProductoDTO eliminarProducto = await _productosService.EliminarProducto(a);
                return Ok(eliminarProducto);

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al guardar el producto en la base de datos");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }
        }

        [Route("VenderProducto")]
        [HttpPost]
        public async Task<IActionResult> VenderProducto(int idProducto, int cantidadProducto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                ResponseDto ventaProducto = await _productosService.VenderProducto(idProducto, cantidadProducto);
                if(!ventaProducto.Success)
                {
                    return BadRequest(ventaProducto);
                }
                
                return Ok(ventaProducto);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Error al vender el producto");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error inesperado");
            }
        }
    }
}