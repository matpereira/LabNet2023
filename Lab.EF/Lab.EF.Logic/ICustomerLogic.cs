using Lab.EF.Logic.DTO;
using System.Collections.Generic;


namespace Lab.EF.Logic
{
    //Cree una nueva interface para poder utilizar inyeccion de dependencias con Customers
    public interface ICustomersLogic
    {
        List<CustomersDTO> GetAll();
        void Add(CustomersDTO entity);
        void Update(CustomersDTO entity);

        void Delete(string id);

    }
}
