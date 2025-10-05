using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IViajesRepositorio
    {
        //Funcion general para el id de los moviles
        IEnumerable<MovilResumenDTO> SeleccionarMovil();

        // Funciones del modulo de viajes
        void Agregar(AgregarViajeDTO viaje);
        void Editar(ModificarViajeDTO dto);
        void Eliminar(int id);
        void CambiarEstado(int idViaje);
        ModificarViajeDTO ObtenerPorId(int idViaje);
        DataTable MostrarTodo(DateTime fecha);

        // Funciones del modulo de vuelta
        void AgregarVueltaManual(VueltaDTO dto);
        bool CambiarEstadoVuelta(int idVuelta);
        void EliminarVuelta(int idVuelta);
        void EliminarUltimaVueltaDeMovil(int idMovil, DateTime fecha);
        int ObtenerProximoNumeroDeVuelta(int idMovil, DateTime fecha);
        int CalcularVueltaJustaParaNuevoMovil(DateTime fecha);
        bool MovilTieneVueltas(int idMovil, DateTime fecha);
        bool MovilYaTieneVuelta(int idMovil, DateTime fecha, int numeroVuelta);
        DataTable MostrarVuelta(DateTime fecha);
        List<MovilResumenDTO> ObtenerMovilesDelDia(DateTime fecha);
        bool ExisteVueltaConEstado(int idMovil, DateTime fecha, int numeroVuelta, string estado);
        void ActivarVueltaPendiente(int idMovil, DateTime fecha, int numeroVuelta);
        int ObtenerIdVuelta(int idMovil, DateTime fecha, int numeroVuelta);
    }
}
