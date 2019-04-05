using Examen3App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3App.Control
{
    class CListaclientes
    {
        public DataTable listaClientes()
        {
            return new Mlistaclientes().listaClientes();
        }
    }
}
