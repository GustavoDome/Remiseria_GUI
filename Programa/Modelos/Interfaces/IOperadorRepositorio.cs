using Programa.DTOs;
using System.Collections.Generic;

namespace Programa.Modelos.Interfaces
{
    public interface IOperadorRepositorio
    {
        void Agregar(Operador operador);
        void Editar(Operador operador);
        void Eliminar(int id); // ya es borrado lógico
        IEnumerable<Operador> ObtenerTodos(); // ya filtra por Activo
        OperadorLoginDTO Autenticar(string nombre, string contrasena);

        ConfiguracionDTO ObtenerConfiguracion(int id);

        void EditarConfiguracion(int id, ConfiguracionDTO config);

        // Alias más claro para el presentador
        IEnumerable<Operador> MostrarActivos(); // opcional
    }
}