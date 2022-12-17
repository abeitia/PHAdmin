

using AutoMapper;
using PHAdmin.API.Models;
using PHAdmin.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PHAdmin.API.Entities;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PHAdmin.API.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IPHAdminRepository _phAdminRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public ExpensesController(IPHAdminRepository phAdminRepository,
            IMapper mapper,
            IWebHostEnvironment environment,
            FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _phAdminRepository = phAdminRepository ?? throw new ArgumentNullException(nameof(phAdminRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
        {
            var expenseEntities = await _phAdminRepository.GetExpensesAsync();
            return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(expenseEntities));
        }

        [HttpGet("{id}", Name ="GetExpense")]
        public async Task<ActionResult<ExpenseDto>> GetExpense(int id)
        {
            var expense = await _phAdminRepository.GetExpenseAsync(id);
            if (expense == null)
            {
                return NotFound();
            }


            return Ok(_mapper.Map<ExpenseDto>(expense));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> DeleteExpense(
            int id,
            JsonPatchDocument<ExpenseForUpdateDto> patchDocument)
        {
            

            var expenseEntity = await _phAdminRepository.GetExpense2Async(id);
            if (expenseEntity == null)
            {
                return NotFound();
            }

            var expenseToPatch = _mapper.Map<ExpenseForUpdateDto>(
                expenseEntity);

            patchDocument.ApplyTo(expenseToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(expenseToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(expenseToPatch, expenseEntity);
            var t= await  _phAdminRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpense2( int id )
        {


            var expenseEntity = await _phAdminRepository.GetExpense2Async(id);
            if (expenseEntity == null)
            {
                return NotFound();
            }



            _phAdminRepository.DeleteExpense(expenseEntity);


            var t = await _phAdminRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("file/{expenseId}")]
        public async Task<ActionResult> GetFile(int expenseId)
        {
            var expense = await _phAdminRepository.GetExpense2Async(expenseId);
            
            if (expense.Document == null)
            { return NotFound(); };

            var docBytes= GetFileBytes(Convert.ToBase64String(expense.Document));

            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                expense.DocumentName, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            return File(docBytes, contentType, expense.DocumentName);

            //var pathToFile = "getting-started-with-rest-slides.pdf";

            //// check whether the file exists
            //if (!System.IO.File.Exists(pathToFile))
            //{
            //    return NotFound();
            //}

            //if (!_fileExtensionContentTypeProvider.TryGetContentType(
            //    pathToFile, out var contentType))
            //{
            //    contentType = "application/octet-stream";
            //}

            //var bytes = System.IO.File.ReadAllBytes(pathToFile);
            //return File(bytes, contentType, Path.GetFileName(pathToFile));
        }

        private byte[] GetFileBytes(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
            
        }

        [HttpPost()]
        public async Task<ActionResult<ExpenseDto>> CreateExpense(ExpenseForCreationDto expense)
        {
            var finalExpense = _mapper.Map<Entities.Expense>(expense);

            

            if (expense.FilePath != null)
            {
                //ContentRootPath
                var myPath = _environment.WebRootPath + expense.FilePath;
                if (System.IO.File.Exists(myPath))
                {
                    byte[] byteArray = System.IO.File.ReadAllBytes(myPath);
                    finalExpense.Document = byteArray;
                    finalExpense.DocumentName = Path.GetFileName(myPath);
                }
            }

            


            _phAdminRepository.AddExpense(finalExpense);

            await _phAdminRepository.SaveChangesAsync();

            var createdExpenseToReturn =
                _mapper.Map<Models.ExpenseDto>(finalExpense);

            

            return CreatedAtRoute("GetExpense",
                new
                {
                    id = createdExpenseToReturn.Id,
                },
                createdExpenseToReturn);


            //var expenseEntities = await _phAdminRepository.GetExpensesAsync();
            //return Ok(_mapper.Map<IEnumerable<ExpenseDto>>(expenseEntities));
        }

        //    [HttpPost()]
        //    public async Task<ActionResult<ExpenseDto>> CreateExpenseWithDocument( FileUpload fileObj)
        //    {
        //        Expense expense = JsonConvert.DeserializeObject<Expense>(fileObj.Expense);
        //        if (fileObj.file.Length > 0)
        //        {
        //            using (var ms= new MemoryStream())
        //            {
        //                fileObj.file.CopyTo(ms);
        //                var fileBytes = ms.ToArray();
        //                expense.Document = fileBytes;

        //            }
        //        }
        //        var finalExpense = _mapper.Map<Entities.Expense>(expense); 

        //        _phAdminRepository.AddExpenseWithDocument(finalExpense);

        //        await _phAdminRepository.SaveChangesAsync();    

        //        var createdExpenseToReturn =
        //            _mapper.Map<Models.ExpenseDto>(finalExpense);   

        //        return CreatedAtRoute("GetExpense" ,
        //            new
        //            {
        //                id= createdExpenseToReturn.Id,
        //            },
        //            createdExpenseToReturn);



        //    }
        }
    }
