using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.Process;
using OfficeOpenXml;
using System.Data;
using X.PagedList;

namespace MvcMovie.Controllers{
    public class PersonController : Controller{
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public PersonController(ApplicationDbContext context){
            _context = context;
        }

        public async Task<IActionResult> Index(int? page, int? PageSize){
            ViewBag.PageSize = new List<SelectListItem>(){
                new SelectListItem() {Value = "3", Text = "3"},
                new SelectListItem() {Value = "5", Text = "5"},
                new SelectListItem() {Value = "10", Text = "10"},
                new SelectListItem() {Value = "15", Text = "15"},   
                new SelectListItem() {Value = "25", Text = "25"},   
                new SelectListItem() {Value = "50", Text = "50"},   
            };
            int pagesize = (PageSize ?? 3);
            ViewBag.psize = pagesize;
            var model = _context.Persons.ToList().ToPagedList(page ?? 1, pagesize);
            // var model = _context.Persons.ToList().ToPagedList(page ?? 1, 5);
            return View(model);
        }

        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonID, FullName, Address")] Person person){
            if(ModelState.IsValid){
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> Edit(string id){
            if(id == null || _context.Persons.Find(id) == null){
                return NotFound();
            }
            var person = await _context.Persons.FindAsync(id);
            if(person == null){
                return NotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PersonID, FullName, Address")] Person person){
            if(id != person.PersonID){
                return NotFound();
            }

            if(ModelState.IsValid){
                try{
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException){
                    if(!PersonExists(person.PersonID)){
                        return NotFound();
                    }
                    else{
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }
        public async Task<IActionResult> Delete(string id){
            if(id == null || _context.Persons == null){
                return NotFound();
            }
            var person = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if(person == null){
                return NotFound();
            }
            return View(person);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id){
            if(_context.Persons == null){
                return Problem("Entity set 'ApplicationDbContext.Persons' is null.");
            }
            var person = await _context.Persons.FindAsync(id);
            if(person != null){
                _context.Persons.Remove(person);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(string id){
            return(_context.Persons?.Any(e => e.PersonID == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> Upload(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    string fileExtension = Path.GetExtension(file.FileName);
                    if (fileExtension != ".xls" && fileExtension != ".xlsx")
                    {
                        ModelState.AddModelError(string.Empty, "File must be .xls or .xlsx");
                    }
                    else
                    {
                        var fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + fileExtension;
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", "Excels", fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);

                            var dt = _excelProcess.ReadExcelToDataTable(filePath);

                            foreach (DataRow row in dt.Rows)
                            {
                                var person = new Person
                                {
                                    PersonID = row[0].ToString(),
                                    FullName = row[1].ToString(),
                                    Address = row[2].ToString()
                                };
                                _context.Add(person);
                            }

                            await _context.SaveChangesAsync();
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log the error, display a user-friendly message)
                    ModelState.AddModelError(string.Empty, $"Error processing Excel file: {ex.Message}");
                }
            }

            return View();
        }

        public IActionResult Download(){
            //Name the file when downloading
            var fileName = "NguyenKhachLinh15/02" + ".xlsx";
            using(ExcelPackage excelPackage = new ExcelPackage()){
                //Create the WorkSheet
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet 1");
                //Add some text to cell A1
                worksheet.Cells["A1"].Value = "PersonID";
                worksheet.Cells["B1"].Value = "FullName";
                worksheet.Cells["C1"].Value = "Address";
                //get all Person
                var personsList = _context.Persons.ToList();
                //fill data to worksheet
                worksheet.Cells["A2"].LoadFromCollection(personsList);
                var stream = new MemoryStream(excelPackage.GetAsByteArray());
                //download file
                return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
            }
        }




        // public IActionResult Index(){
        //         return View();
        // }

        // [HttpPost]
        // public IActionResult Index(Person ps)
        // {
        //     string strOutput = "Xin chào: " + ps.PersonID + " - " + ps.FullName + " - " + ps.Address;
        //     ViewBag.Message = strOutput;
        //     return View();
        // }
    }
 }