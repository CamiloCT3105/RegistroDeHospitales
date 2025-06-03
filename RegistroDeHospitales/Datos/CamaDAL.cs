using System;
using System.Collections.Generic;
using System.Linq;
using RegistroDeHospitales.Modelos;

namespace RegistroDeHospitales.Datos
{
    public class CamaDAL
    {
        // Lista simulada de camas
        private static List<Cama> listaCamas = new List<Cama>();

        // Agregar cama
        public void Agregar(Cama cama)
        {
            listaCamas.Add(cama);
        }

        // Obtener todas las camas
        public List<Cama> ObtenerTodas()
        {
            return listaCamas;
        }

        // Buscar cama por ID
        public Cama ObtenerPorID(int id)
        {
            return listaCamas.FirstOrDefault(c => c.CamaID == id);
        }

        // Actualizar cama
        public void Actualizar(Cama camaActualizada)
        {
            var cama = ObtenerPorID(camaActualizada.CamaID);
            if (cama != null)
            {
                cama.Numero = camaActualizada.Numero;
                cama.Especializacion = camaActualizada.Especializacion;
                cama.Estado = camaActualizada.Estado;
                cama.SalaID = camaActualizada.SalaID;
            }
        }

        // Eliminar cama
        public void Eliminar(int id)
        {
            var cama = ObtenerPorID(id);
            if (cama != null)
            {
                listaCamas.Remove(cama);
            }
        }

        // Cambiar estado de la cama
        public void CambiarEstado(int id, string nuevoEstado)
        {
            var cama = ObtenerPorID(id);
            if (cama != null)
            {
                cama.Estado = nuevoEstado;
            }
        }
    }
}