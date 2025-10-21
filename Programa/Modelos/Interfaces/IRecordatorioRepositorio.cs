using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    /// <summary>
    /// Interfaz que define las operaciones de acceso a datos para la entidad Recordatorio.
    /// </summary>
    public interface IRecordatorioRepositorio
    {
        void Agregar(Recordatorio recordatorioModelo);
        void Editar(Recordatorio recordatorioModelo);
        void Eliminar(int id);
        string ObtenerTipoAlarma(int idOperador);
        RecordatorioDTO ObtenerPorId(int id);
        IEnumerable<RecordatorioDTO> ObtenerTodos();
    }
}
