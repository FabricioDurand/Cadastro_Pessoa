using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Validators;
using System;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IBaseService<Person> _baseUserService;

        public PersonController(IBaseService<Person> baseUserService)
        {
            _baseUserService = baseUserService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            if (person == null)
                return NotFound();

            return Execute(() => _baseUserService.Add<PersonValidator>(person).Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null)
                return NotFound();

            return Execute(() => _baseUserService.Update<PersonValidator>(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
                return NotFound();

            Execute(() =>
            {
                _baseUserService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _baseUserService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return NotFound();

            return Execute(() => _baseUserService.GetById(id));
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
