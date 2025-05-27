using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IRecordatorioRepositorio
    {
        void agregar(RecordatorioModelo recordatorioModelo);

        void editar(RecordatorioModelo recordatorioModelo);

        void eliminar(int id);

        IEnumerable<RecordatorioModelo> mostrarTodo();
    }
}
