using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiConsulting.Controllers
{
    /// <summary>
    /// API for Documents table
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        private readonly MyDbContext _context;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="context"></param>
        public DocumentsController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Documents
        /// <summary>
        /// Return all the values from Documents table
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Document>>> GetDocuments()
        {
            return await _context.Documents.ToListAsync();
        }

        // GET: api/Documents/5
        /// <summary>
        /// Get Document by id
        /// </summary>
        /// <param name="id">Document Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Document>> GetDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);

            if (document == null)
            {
                return NotFound();
            }

            return document;
        }

        // GET: api/Documents/find
        /// <summary>
        /// Query Documents by given search fields. At least one parameter should be provided.
        /// </summary>
        /// <param name="id">SQL document Id</param>
        /// <param name="ownerName">Account owner's name</param>
        /// <param name="bankName">Bank name</param>
        /// <param name="iban">Iban</param>
        /// <param name="fromDate">Query records newer than this date</param>
        /// <param name="toDate">Query records older than this date (inclusive)</param>
        /// <returns></returns>
        [HttpGet("find")]
        public async Task<ActionResult<IEnumerable<Document>>> FindDocuments(
            [FromQuery] int? id = null,
            [FromQuery] string? ownerName = null,
            [FromQuery] string? bankName = null,
            [FromQuery] string? iban = null,
            [FromQuery] string? fromDate = null,
            [FromQuery] string? toDate = null
            )
        {
            var query = _context.Documents.AsQueryable();

            if (id.HasValue)
            {
                query = query.Where(u => u.Id == id.Value);
            }
            if (!string.IsNullOrEmpty(ownerName))
            {
                query = query.Where(u => u.AcctName == ownerName);
            }
            if (!string.IsNullOrEmpty(bankName))
            {
                query = query.Where(u => u.Bank == bankName);
            }
            if (!string.IsNullOrEmpty(iban))
            {
                query = query.Where(u => u.IBAN == iban);
               
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Update Documents data from PUT body
        /// </summary>
        /// <param name="id">Id of document to be updated</param>
        /// <param name="document"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDocument(int id, [FromBody] Document document)
        {
            // Retrieve the existing document from the database
            var existingDocument = await _context.Documents.FindAsync(id);

            if (existingDocument == null)
            {
                return NotFound();
            }

            // Update the fields that are present in the request body

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Add document, make sure that ID is not in use and that all the required fields are given
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        // POST: api/Documents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Document>> PostDocument(Document document)
        {
            _context.Documents.Add(document);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocument", new { id = document.Id }, document);
        }

        /// <summary>
        /// Delete document
        /// </summary>
        /// <param name="id">Id of the document record to be deleted</param>
        /// <returns></returns>
        // DELETE: api/Documents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(int id)
        {
            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            _context.Documents.Remove(document);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentExists(int id)
        {
            return _context.Documents.Any(e => e.Id == id);
        }
    }
}
