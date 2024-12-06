/* 
 * Producto.cs
 * 
 * Creado por: Elianis Manuel Medina Morón
 * Código: 1129578794
 * Progrma: Ingeniería Multimedia
 * Grupo: 213023_218
 * Fecha: 05/12/2024
 * Descripción: Programa de consola que simula un sistema de venta de computadoras
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductoSpace
{
    public class Producto
    {
        // Attributes
        private string name;
        private double price;

        // Constructor
        public Producto(string itemName, double itemPrice)
        {
            name = itemName;
            price = itemPrice;
        }

        // Getters + Setters
        public string ItemName
        {
            get { return name; }
            set { name = value; }
        }
        public double ItemPrice
        {
            get { return price; }
            set { price = value; }
        }

        // methods

        // Returns String value describing item for display
        public override string ToString()
        {
            return "Nombre del producto: " + name + "\tPrecio del producto: $" + price;
        }

        // Checks if two objects equal eachother
        public bool equals(Producto otherItem)
        {
            if ((otherItem.ItemName == name) && (otherItem.ItemPrice == price))
                return true;
            else
                return false;
        }

    }
}

