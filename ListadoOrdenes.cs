/* 
 * ListadoOrdenes.cs
 * 
 * Creado por: Elianis Manuel Medina Morón
 * Código: 1129578794
 * Progrma: Ingeniería Multimedia
 * Grupo: 213023_218
 * Fecha: 05/12/2024
 * Descripción: Programa de consola que simula un sistema de venta de computadoras
 * 
 */
using OrdenSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListadoOrdenesSpace
{
    public class ListadoOrdenes
    {
        public List<Orden> orderList = new List<Orden>();

        // Métodos

        // Returna el listado de ordenes
        public override string ToString()
        {
            StringBuilder s = new StringBuilder(
                "-------------------------------------------\nListado de ordenes:\n-------------------------------------------\n"
            );
            s.Append("-------------------------------------------\n");
            for (int i = 0; i < orderList.Count; i++)
            {
                s.Append("\nORDER #" + (i + 1) + "\n" + orderList[i].ToString() + "\n");
            }
            s.Append("-------------------------------------------");
            return s.ToString();
        }
    }
}
