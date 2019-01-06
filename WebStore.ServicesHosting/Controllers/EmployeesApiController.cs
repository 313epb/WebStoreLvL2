using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Models;
using WebStore.Interfaces;

namespace WebStore.ServicesHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/employees")]
    public class EmployeesApiController : Controller,IEmployeesData
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesApiController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }


        /// <summary>
        /// Get api/employees
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employeesData.GetAll();
        }

        /// <summary>
        /// PUT api/employees/{id}  
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public EmployeeView UppdateEmployee(int id, [FromBody]EmployeeView entity)
        {
            return _employeesData.UppdateEmployee(id, entity);
        }

        /// <summary>
        /// GET api/employees{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public EmployeeView GetById(int id)
        {
            return _employeesData.GetById(id);
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// POST api/employees
        /// </summary>
        /// <param name="model"></param>
        [HttpPost]
        public void AddNew([FromBody]EmployeeView model)
        {
            _employeesData.AddNew(model);
        }

        /// <summary>
        /// DELETE api/employees/{id}
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeesData.Delete(id);
        }
    }
}