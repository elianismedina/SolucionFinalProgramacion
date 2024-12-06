/* 
 * Orden.cs
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

namespace OrdenSpace
{
    public class Orden
    {
        // Attributes
        public List<Producto> ItemList = new List<Producto>();
        private double subtotal;
        private string deliveryAddress;
        private string name;

        // Getters + Setters
        public string OrderAddress
        {
            get { return deliveryAddress; }
            set { deliveryAddress = value; }
        }
        public double OrderSubtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        public string OrderName
        {
            get { return name; }
            set { name = value; }
        }

        // Constructor
        public Orden(string orderName, string orderAddress)
        {
            name = orderName;
            deliveryAddress = orderAddress;
            subtotal = 0.0;
        }

        // Methods

        // Deletes Item From Order
        public int DeleteItemFromOrder()
        {

            // Check if Inventory is empty
            if (ItemList.Count == 0)
            {
                Console.WriteLine("No hay productos en la orden para borrar");

                // Failed Execution code
                return -1;
            }

            // Display the Inventory
            Console.WriteLine(ToString());

            // Prompt Item Price Input
            Console.WriteLine("Por favor ingresa el número del producto que deseas borrar:\n");
            string? ItemNumber_input;
            Console.Write("Borrar producto #> ");
            ItemNumber_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Null Check
            if (ItemNumber_input == null)
            {
                Console.WriteLine("Error en la entrada: Intenta de nuevo.");

                // Failed execution code
                return -1;
            }

            // Correct Input Check
            List<string> inv_nums = new List<string>();
            for (int i = 0; i < ItemList.Count; i++)
            {
                inv_nums.Add((i + 1).ToString());
            }
            if (!inv_nums.Contains(ItemNumber_input))
            {
                Console.WriteLine("Entrada incorrecta: Por favor ingrese un número de producto válido");
                Console.WriteLine("Cancelando la transacción...");
                return -1;
            }

            // Try and Cast Input to Int
            int itemNumber;
            try
            {
                itemNumber = Int32.Parse(ItemNumber_input);
            }
            catch (Exception)
            {
                Console.WriteLine("Entrada incorrecta: Por favor ingrese un número de producto válido");
                Console.WriteLine("Cancelando la transacción...");
                return -1;
            }

            // Decrement for proper iteration number in list
            itemNumber--;

            // Remove the Item from list
            ItemList.Remove(ItemList[itemNumber]);

            // Confirmation Display message
            Console.WriteLine("Producto fue removido de la orden");

            // Successful Execution Code
            return 1;
        }

        // Calcula el subtotal de la orden
        public void CalculateSubtotal()
        {
            double total = 0.0;
            for (int i = 0; i < ItemList.Count; i++)
            {
                total += ItemList[i].ItemPrice;
            }

            subtotal = total;
        }

        // Returna el listado de productos en la orden
        public override string ToString()
        {
            StringBuilder s = new StringBuilder(
                "-------------------------------------------\nListado de productos en la orden:\n-------------------------------------------"
            );
            s.Append("\nNombre en la orden: " + name + "\nDirección de la orden: " + deliveryAddress);
            s.Append("\nTotal de la orden: $" + subtotal);
            s.Append("\n-------------------------------------------");
            for (int i = 0; i < ItemList.Count; i++)
            {
                s.Append("\n" + (i + 1) + " - " + ItemList[i].ToString() + "\n");
            }
            s.Append("-------------------------------------------");
            return s.ToString();
        }
    }
}
