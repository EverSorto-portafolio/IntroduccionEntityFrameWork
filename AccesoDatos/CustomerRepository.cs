using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public  class CustomerRepository
    {
        public NorthwindEntities contexto = new NorthwindEntities();

        public List<Customers> ObtenerTodos() {
            var cliente = from custM in contexto.Customers select custM;  
            
            return cliente.ToList();
        }
    }
}
