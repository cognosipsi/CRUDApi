using APIsinPlantilla.Data;
using APIsinPlantilla.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIsinPlantilla.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController:ControllerBase
    {
        //Funciones ASP

        [HttpGet]
        public async Task<ActionResult<List<Mproductos>>> Get() 
        {
            var funcion = new Dproductos();
            var lista = await funcion.mostrarProductos();
            return lista;
        }

        [HttpPost]
        public async Task Post([FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            await funcion.insertarProductos(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            parametros.id = id;
            await funcion.editarProductos(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.id = id;
            await funcion.eliminarProductos(parametros);
            return NoContent();
        }

    }
}
