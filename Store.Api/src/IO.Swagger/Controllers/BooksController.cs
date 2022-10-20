/*
 * Books API
 *
 * API that manages a collection of books in a fictional store
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git & Rich Dean
 */

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using IO.Swagger.Attributes;
using IO.Swagger.Models;
using Microsoft.EntityFrameworkCore;
using Store.Entities.Context;
using Store.Entities.Models;

namespace IO.Swagger.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly StoreContext _context;

        public BooksController(StoreContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Creates a new book
        /// </summary>
        /// <param name="body">A JSON object that represents a book. Leave out id line for creation</param>
        /// <response code="201">Created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("//books")]
        [ValidateModelState]
        [SwaggerOperation("CreateBook")]
        [SwaggerResponse(statusCode: 201, type: typeof(InlineResponse201), description: "Created")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult CreateBook([FromBody] Book body)
        {
            try
            {
                _context.Books.Add(body);
                _context.SaveChanges();
                var id = body.Id;
                var json = "{\n  \"id\" : " + id + "\n}";

                return StatusCode(201, json);
            }
            catch
            {
                return StatusCode(400, default(InlineResponse400));
            }
        }

        /// <summary>
        /// Deletes a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpDelete]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteBookById")]
        [SwaggerResponse(statusCode: 404, description: "Book not found")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult DeleteBookById([FromRoute][Required] long? id)
        {
            try
            {
                var books = _context.Books.Find(id);
                if (books == null)
                {
                    return StatusCode(404);
                }

                _context.Books.Remove(books);
                _context.SaveChanges();
                return StatusCode(200);
            }
            catch
            {
                return StatusCode(400, default(InlineResponse400));
            }
        }

        /// <summary>
        /// Returns a list of books. Sorted by title by default.
        /// </summary>
        /// <param name="sortby"></param>
        /// <response code="200">Success</response>
        [HttpGet]
        [Route("//books/")]
        [ValidateModelState]
        [SwaggerOperation("GetBook")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Book>), description: "Success")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult GetBook([FromQuery] string sortby)
        {
            try
            {
                List<Book> data;
                if (string.IsNullOrEmpty(sortby))
                {

                    data = _context.Books.OrderBy(p=>p.Title).ToList();
                }
                else
                {
                    //I wasn't sure what columns you'd want to sort on so just returning the list as is
                    //If there had been specific columns, passed into the sortby, I'd have amended it accordingly 
                    //TODO If required, create QueryableExtension method 
                    data = _context.Books.ToList();
                }
                
                return StatusCode(200, data);
            }
            catch
            {
                return StatusCode(400, default(InlineResponse400));
            }
        }

        /// <summary>
        /// Gets a book by id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="404">Book not found</response>
        [HttpGet]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetBookById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Book), description: "Success")]
        [SwaggerResponse(statusCode: 404, description: "Book not found")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult GetBookById([FromRoute][Required] long? id)
        {
            try
            {
                var data = _context.Books.Find(id);

                if (data != null)
                {
                    return StatusCode(200, data);
                }
                return StatusCode(404);
            }
            catch
            {
                return StatusCode(400, default(InlineResponse400));
            }
        }

        /// <summary>
        /// Update an existing book
        /// </summary>
        /// <param name="body">A JSON object that represents a book.</param>
        /// <param name="id"></param>
        /// <response code="200">Success</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Book not found</response>
        [HttpPut]
        [Route("//books/{id}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateBookById")]
        [SwaggerResponse(statusCode: 200, description: "Success")]
        [SwaggerResponse(statusCode: 404, description: "Book not found")]
        [SwaggerResponse(statusCode: 400, type: typeof(InlineResponse400), description: "Bad Request")]
        public virtual IActionResult UpdateBookById([FromBody] Book body, [FromRoute][Required] long? id)
        {
            if (id != body.Id)
            {
                return StatusCode(400, default(InlineResponse400));
            }
            try
            {
                if (!BooksExists(id))
                {
                    return StatusCode(404);
                }
                var oldBook = _context.Books.Find(id);
                _context.Entry(oldBook).CurrentValues.SetValues(body);
                return StatusCode(200);
            }
            catch (DbUpdateConcurrencyException)
            {
             
                return StatusCode(400, default(InlineResponse400));
            }
        }

        private bool BooksExists(long? id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
