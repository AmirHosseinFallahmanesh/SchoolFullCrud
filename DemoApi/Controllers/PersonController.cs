using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        PersonRepository repository = PersonRepository.Current;

        [HttpGet]
       
        public IActionResult GetAll()
        {
            ApiRespnoseModel<IEnumerable<Person>> model = new ApiRespnoseModel<IEnumerable<Person>>();
            try
            {
                model.Data = repository.GetAll();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {

                model.ErrorMessage = ex.Message;
            }
            
            return Ok(model);
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public IActionResult Get(int id)
        {
            ApiRespnoseModel<Person> model = new ApiRespnoseModel<Person>();
            try
            {
                model.Data = repository.Get(id);
                model.IsSuccess = true;

            }
            catch (Exception ex)
            {

                model.ErrorMessage = ex.Message;
                model.IsSuccess = false;
                return NotFound(model);
            }
            return Ok(model);
        }

        //[HttpGet("test/{id}")]
        //public ApiRespnoseModel<Person> GetStudent(int id) => repository.Get(id);

        [HttpPost]
        public IActionResult PostPerson(Person person)
        {
            ApiRespnoseModel<int> model = new ApiRespnoseModel<int>();
            try
            {
                model.Data = repository.Create(person);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {

                model.ErrorMessage = ex.Message;
                model.IsSuccess = false;
            }
            return Created($"api/person/{model.Data}", model);
        }

        [HttpPut]
        public ApiRespnoseModel<Person> UpdatePerson(Person person)
        {
            ApiRespnoseModel<Person> model = new ApiRespnoseModel<Person>();
            try
            {
                model.Data = repository.Update(person);
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {

                model.ErrorMessage = ex.Message;
                model.IsSuccess = false;
            }
            return model;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            repository.Delete(id);
        }

    }
}