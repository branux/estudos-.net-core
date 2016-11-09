using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using TodoApp.Api.Extensions;
using TodoApp.Api.Validators;
using TodoApp.Domain.Dtos;
using TodoApp.Domain.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService appService;
        private readonly TodoValidator validator;

        public TodoController(ITodoService appService, TodoValidator validator)
        {
            this.appService = appService;
            this.validator = validator;
        }

        // GET: api/todo
        [HttpGet]
        public Results.GenericResult<IEnumerable<TodoDTO>> Get()
        {
            var result = new Results.GenericResult<IEnumerable<TodoDTO>>();

            try
            {
                result.Result = appService.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public Results.GenericResult<TodoDTO> Get(int id)
        {
            var result = new Results.GenericResult<TodoDTO>();

            try
            {
                result.Result = appService.GetById(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }

        // POST api/todo
        [HttpPost]
        public Results.GenericResult<TodoDTO> Post([FromBody]TodoDTO model)
        {
            var result = new Results.GenericResult<TodoDTO>();

            var validatorResult = validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Result = appService.Create(model);
                    result.Success = true;
                    Response.StatusCode = (int)HttpStatusCode.Created;
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Errors = validatorResult.GetErrors();
            }

            return result;
        }

        // PUT api/todo/5
        [HttpPut("{id}")]
        public Results.GenericResult Put(int id, [FromBody]TodoDTO model)
        {
            var result = new Results.GenericResult();

            var validatorResult = validator.Validate(model);
            if (validatorResult.IsValid)
            {
                try
                {
                    result.Success = appService.Update(model) != null;
                    if (!result.Success)
                        throw new Exception($"Todo {id} can't be updated");
                }
                catch (Exception ex)
                {
                    Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    result.Errors = new string[] { ex.Message };
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                result.Errors = validatorResult.GetErrors();
            }


            return result;

        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public Results.GenericResult Delete(int id)
        {
            var result = new Results.GenericResult();

            try
            {
                result.Success = appService.Delete(id);
                if (!result.Success)
                    throw new Exception($"Todo {id} can't be deleted");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                result.Errors = new string[] { ex.Message };
            }

            return result;
        }
    }
}
