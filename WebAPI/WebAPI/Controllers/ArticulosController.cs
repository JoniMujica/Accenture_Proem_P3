using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticulosController : ControllerBase
    {
        //readonly solose puede escribir en elcontructor
        private readonly DataContext dataContext;
        public ArticulosController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Articulo>> Get()
        {
            return await dataContext.Articulos.ToListAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Articulo> Get(int id)
        {
            var entity = await dataContext.Articulos.FindAsync(id);
            if (entity ==null)
            {
                return null;
            }
            return entity; 
        }
        [HttpPost]
        public async Task<Articulo> Post(Articulo entity)
        {

            dataContext.Articulos.Add(entity);
            await dataContext.SaveChangesAsync();
            return entity;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, Articulo entity)
        {
            entity.Id = id;
            dataContext.Articulos.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete] 
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await dataContext.Articulos.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            dataContext.Articulos.Remove(entity);
            await dataContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> Export()
        {
            var articulos = await dataContext.Articulos.ToListAsync();
            IWorkbook worlbook = new XSSFWorkbook();
            ISheet sheet1 = worlbook.CreateSheet("Articulos");
            IRow row = sheet1.CreateRow(0);
            row.CreateCell(0).SetCellValue("Codigo");
            row.CreateCell(1).SetCellValue("Nombre");
            row.CreateCell(2).SetCellValue("Precio");
            int rowNumber = 1;
            foreach (var item in articulos)
            {
                row = sheet1.CreateRow(rowNumber);
                row.CreateCell(0).SetCellValue(item.Id);
                row.CreateCell(1).SetCellValue(item.Nombre);
                row.CreateCell(2).SetCellValue((double)item.Precio);
                rowNumber++;
            }
            var st = new MemoryStream();
            worlbook.Write(st);
            var st2 = new MemoryStream();
            var array = st.ToArray();
            st2.Write(array,0,array.Length);
            //await st.FlushAsync();
            st2.Position = 0;
            //st.Close();
            return File(st2, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","Reporte.xlsx");
        }

    }
}
 