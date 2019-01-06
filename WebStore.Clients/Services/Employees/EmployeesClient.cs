using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.DomainNew.Models;
using WebStore.Interfaces;

namespace WebStore.Clients.Services.Employees
{
    public class EmployeesClient:BaseClient,IEmployeesData
    {
        private readonly IConfiguration _configuration;

        public EmployeesClient(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
            ServiceAddress = "api/employees";
        }

        protected sealed override string ServiceAddress { get; set; }

        public IEnumerable<EmployeeView> GetAll()
        {
            var url = $"{ServiceAddress}";
            var list = Get<List<EmployeeView>>(url);
            return list;
        }

        public EmployeeView UppdateEmployee(int id, EmployeeView entity)
        {
            var url = $"{ServiceAddress}/{id}";
            var response = Put<EmployeeView>(url, entity);
            var result = response.Content.ReadAsAsync<EmployeeView>().Result;
            return result;
        }

        public EmployeeView GetById(int id)
        {
            var url = $"{ServiceAddress}/{id}";
            var result = Get<EmployeeView>(url);
            return result;
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void AddNew(EmployeeView model)
        {
            var url = $"{ServiceAddress}";
            Post(url, model);
        }

        public void Delete(int id)
        {
            var url = $"{ServiceAddress}";
            Delete(url);
        }
    }
}
