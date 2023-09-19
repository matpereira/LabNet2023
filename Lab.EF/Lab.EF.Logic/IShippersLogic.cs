using Lab.EF.Logic.DTO;
using System.Collections.Generic;


namespace Lab.EF.Logic
{
    //Cree una nueva interface para poder utilizar inyeccion de dependencias con Shippers
    public interface IShippersLogic
    {
        List<ShippersDTO> GetAll();
        void Add(ShippersDTO entity);
        void Update(ShippersDTO entity);

        void Delete(int id);
    }
}
