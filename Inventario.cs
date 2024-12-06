/* 
 * Inventario.cs
 * 
 * Creado por: Elianis Manuel Medina Morón
 * Código: 1129578794
 * Progrma: Ingeniería Multimedia
 * Grupo: 213023_218
 * Fecha: 05/12/2024
 * Descripción: Programa de consola que simula un sistema de venta de computadoras
 * 
 */
using ProductoSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioSpace
{
    public class Inventario
    {
        // Attributos
        public List<Producto> ItemList = new List<Producto>();

        // Métodos

        // Returna el listado de productos en el inventario
        public override string ToString()
        {
            StringBuilder s = new StringBuilder(
                "-------------------------------------------\nListado de productos:\n-------------------------------------------"
            );
            for (int i = 0; i < ItemList.Count; i++)
            {
                s.Append("\n" + (i + 1) + " - " + ItemList[i].ToString() + "\n");
            }
            s.Append("-------------------------------------------");
            return s.ToString();
        }
    }
}
