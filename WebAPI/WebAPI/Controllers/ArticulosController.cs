using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
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
        [Route("ExportPDF")]
        public async Task<IActionResult> ExportPDF()
        {
            var articulos = await dataContext.Articulos.ToListAsync();
            var st = new  MemoryStream();
            PdfWriter writer = new PdfWriter(st);
            PdfDocument pdf = new PdfDocument(writer);
            Document reporte = new Document(pdf, iText.Kernel.Geom.PageSize.A4);
            Paragraph texto = new Paragraph("Listado de articulos")
                .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                .SetFontSize(15)
                .SetMarginBottom(3);
                
            reporte.Add(texto);
            reporte.Close();

            var st2 = new MemoryStream();
            var array = st.ToArray();
            st2.Write(array, 0, array.Length);
            st2.Position = 0;
            return File(st2, "application/pdf","Reporte.pdf");
        }

        [HttpGet]
        [Route("Export")]
        public async Task<IActionResult> Export()
        {
            var articulos = await dataContext.Articulos.ToListAsync();
            IWorkbook worlbook = new XSSFWorkbook();
            ISheet sheet1 = worlbook.CreateSheet("Articulos");


            //tipo de fuente
            var titulos = worlbook.CreateCellStyle();
            var fuente = worlbook.CreateFont();
            //le agrego negrita y tamaño  ala fuente
            fuente.IsBold=true;
            fuente.FontHeight = 30;
            titulos.SetFont(fuente);

            IRow row = sheet1.CreateRow(0);
            var celda = row.CreateCell(0);
            /*row.CreateCell(0).SetCellValue("Codigo");
            row.CreateCell(1).SetCellValue("Nombre");
            row.CreateCell(2).SetCellValue("Precio");
            row.CreateCell(3).SetCellValue("Precio mayorista");*/
            celda.SetCellValue("Codigo");
            celda.CellStyle = titulos;
            celda = row.CreateCell(1);
            celda.SetCellValue("Nombre");
            celda.CellStyle = titulos;
            celda = row.CreateCell(2);
            celda.SetCellValue("Precio");
            celda.CellStyle = titulos;
            celda = row.CreateCell(3);
            celda.SetCellValue("Precio Mayorista");
            celda.CellStyle = titulos;
            sheet1.AutoSizeColumn(0);
            sheet1.AutoSizeColumn(1);
            sheet1.AutoSizeColumn(2);
            sheet1.AutoSizeColumn(3);

            int rowNumber = 1;
            foreach (var item in articulos)
            {
                row = sheet1.CreateRow(rowNumber);
                row.CreateCell(0).SetCellValue(item.Id);
                row.CreateCell(1).SetCellValue(item.Nombre);
                row.CreateCell(2).SetCellValue((double)item.Precio);
                row.CreateCell(3).SetCellFormula($"C{rowNumber+1}*0.9");
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
 