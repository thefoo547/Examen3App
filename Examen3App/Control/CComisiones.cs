using Examen3App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen3App.Control
{
    class CComisiones
    {
        public DataTable Comisiones(int yr)
        {
            if (yr > DateTime.Now.Year)
            {
                throw new Exception("-Control de datos: Fecha no Válida");
            }
            return new MComisiones().Comisiones(yr);
        }
    }
}
