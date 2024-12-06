/* 
 * Program.cs
 * 
 * Creado por: Elianis Manuel Medina Morón
 * Código: 1129578794
 * Progrma: Ingeniería Multimedia
 * Grupo: 213023_218
 * Fecha: 05/12/2024
 * Descripción: Programa de consola que simula un sistema de venta de computadoras
 * 
 */

using InventarioSpace;
using ListadoOrdenesSpace;
using OrdenSpace;
using ProductoSpace;
using System.Security.Cryptography;
using System.Text;

namespace ProgramSpace
{
    class Program
    {
        static void Main(string[] args)
        {
            mainDriver();
        }

        ////////////////////////////////////////////////////////////////////////////////

        // Main driver function
        public static void mainDriver()
        {
            // Inventory + Order List Initialization
            Inventario inventario = new Inventario();
            ListadoOrdenes ordenes = new ListadoOrdenes();

            // Entry Display Message
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------ACCESO AL SISTEMA-------------");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("-------------------------------------------");
            //Hash username and password
            string hashUsername(string username)
            {
                var sha = SHA256.Create();
                var asByteArray = Encoding.Default.GetBytes(username);
                var hashedUsername = sha.ComputeHash(asByteArray);
                return Convert.ToBase64String(hashedUsername);
            }
            string StoredUsername = hashUsername("admin");

            string hashPassword(string password)
            {
                var sha = SHA256.Create();
                var asByteArray = Encoding.Default.GetBytes(password);
                var hashedPassword = sha.ComputeHash(asByteArray);
                return Convert.ToBase64String(hashedPassword);
            }
            string StoredPassword = hashUsername("password");

            // User input

            Console.WriteLine("Por favor ingrese su usuario");
            string userName = Console.ReadLine();
            while (true)
            {
                userName = hashUsername(userName);
                if (userName.Equals(StoredUsername))
                {
                    Console.WriteLine("Por favor ingrese su contraseña");
                    string userPassword = Console.ReadLine();
                    while (true)
                    {

                        userPassword = hashPassword(userPassword);
                        if (userPassword.Equals(StoredPassword))
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Bienvenido al sistema de venta de computadoras");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Usuario es: " + userName);
                            Console.WriteLine("Contraseña es: " + userPassword);
                            // Main Driver Loop
                            while (true)
                            {

                                // Menu Selection Display
                                Console.WriteLine("¿Qúé operación desea realizar?");
                                Console.WriteLine("(1) - Crear una orden para llevar");
                                Console.WriteLine("(2) - Crear una orden para envio");
                                Console.WriteLine("(3) - Mostrar inventario");
                                Console.WriteLine("(4) - Añadir producto al inventario");
                                Console.WriteLine("(5) - Eliminar producto del inventario");
                                Console.WriteLine("(6) - Mostrar todas la ordenes");
                                Console.WriteLine("(0) - Salir\n");
                                Console.Write("Option #> ");

                                // Menu Selection Input
                                string? selection_input;
                                try
                                {
                                    selection_input = Console.ReadLine();
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Error en la entrada: Intenta de nuevo.");
                                    Console.WriteLine(e);
                                    continue;
                                }
                                Console.WriteLine("-------------------------------------------");

                                // selection_input null catcher
                                if (selection_input == null)
                                {
                                    Console.WriteLine("Error en la entrada: Intenta de nuevo.");
                                    Console.WriteLine("-------------------------------------------");
                                    continue;
                                }

                                // Case Statement
                                switch (selection_input)
                                {
                                    case "0":
                                        // Exit Display Message + Exit App
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine("             Nos vemos luego!              ");
                                        Console.WriteLine("-------------------------------------------");
                                        Console.WriteLine("-------------------------------------------");
                                        Environment.Exit(0);
                                        break;
                                    case "1":
                                        // Takeout Order Option
                                        CrearOrdenLlevar(ordenes: ref ordenes, inventario: ref inventario);
                                        Console.WriteLine("-------------------------------------------");
                                        break;
                                    case "2":
                                        // Delivery Order Option
                                        CrearOrdenEnvio(ordenes: ref ordenes, inventario: ref inventario);
                                        Console.WriteLine("-------------------------------------------");
                                        break;
                                    case "3":
                                        // Display Inventory Option
                                        if (inventario.ItemList.Count == 0)
                                        {
                                            Console.WriteLine("No hay productos en el inventario");
                                        }
                                        else
                                        {
                                            Console.WriteLine(inventario.ToString());
                                        }
                                        Console.WriteLine("-------------------------------------------");
                                        break;
                                    case "4":
                                        // Add Item to Inventory Option
                                        AnadirProducto(ref inventario);
                                        Console.WriteLine("-------------------------------------------");
                                        break;
                                    case "5":
                                        // Delete Item From Inventory Option
                                        EliminarProducto(ref inventario);
                                        Console.WriteLine("-------------------------------------------");
                                        break;
                                    case "6":
                                        // Display Order List orders
                                        if (ordenes.orderList.Count > 0)
                                            Console.WriteLine(ordenes.ToString());
                                        else
                                        {
                                            Console.WriteLine("No hay ordenes guardadas en el momento");
                                            Console.WriteLine("-------------------------------------------");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Por favor ingrese una opción válida!");
                                        Console.WriteLine("-------------------------------------------");
                                        break;
                                }
                            }
                        }
                        break;
                    }

                    Console.WriteLine("Contraseña incorrecta, por favor intente de nuevo");
                    userPassword = Console.ReadLine();

                }
                break;

            }
            Console.WriteLine("Usuario incorrecto, por favor intente de nuevo");
            userName = Console.ReadLine();

        }

        ////////////////////////////////////////////////////////////////////////////////

        //Funcion para añadir un nuevo producto al inventario
        public static int AnadirProducto(ref Inventario inventario)
        {
            // Prompt Item Name Input
            Console.WriteLine("Por favor ingrese el nonbre del producto:\n");
            string? ItemName_input;
            Console.Write("Nombre del producto #> ");
            ItemName_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Prompt Item Price Input
            Console.WriteLine("Por favor ingrese el precio del producto:\n");
            string? ItemPrice_input;
            Console.Write("Precio del producto #> $");
            ItemPrice_input = Console.ReadLine();

            // Null Check to Quiet Warning
            if ((ItemName_input == null) || (ItemPrice_input == null))
            {
                Console.WriteLine("Error al ingresar datos: Intente de nuevo.");
                Console.WriteLine("-------------------------------------------");

                // Failed execution code
                return -1;
            }
            else
            {

                // Variable Initialization
                Double itemPrice_double;

                // Check to ensure double value entered
                try
                {
                    // Cast Price to Double
                    itemPrice_double = Double.Parse(ItemPrice_input);
                }
                catch (Exception)
                {
                    Console.WriteLine("\nError al ingresar datos: Porfavor ingrese una cantidad númerica en pesos\nCancelando transacción...");
                    Console.WriteLine("-------------------------------------------");

                    // Failed Execution Code
                    return -1;
                }

                // Create Item + Add to Inventory
                Producto producto = new Producto(itemName: ItemName_input, itemPrice: itemPrice_double);
                inventario.ItemList.Add(producto);

                // Successful Execution Code
                return 1;
            }

        }

        //Funcion para eliminar un producto del inventario
        public static int EliminarProducto(ref Inventario inventario)
        {
            // Check if Inventory is empty
            if (inventario.ItemList.Count == 0)
            {
                Console.WriteLine("No hay productos en el inventario para borrar.");

                // Failed Execution code
                return -1;
            }
            // Display the Inventory
            Console.WriteLine(inventario.ToString());

            // Prompt Item Price Input
            Console.WriteLine("Por favor ingrese el número del producto que desea borrar:\n");
            string? ItemNumber_input;
            Console.Write("Eliminar producto #> ");
            ItemNumber_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Null Check
            if (ItemNumber_input == null)
            {
                Console.WriteLine("Error al ingresar datos: Intente de nuevo.");

                // Failed execution code
                return -1;
            }
            // Correct Input Check
            List<string> inv_nums = new List<string>();
            for (int i = 0; i < inventario.ItemList.Count; i++)
            {
                inv_nums.Add((i + 1).ToString());
            }
            if (!inv_nums.Contains(ItemNumber_input))
            {
                Console.WriteLine("Entrada incorrecta: Por favor ingrese el número de producto válido");
                Console.WriteLine("Cancelando transacción...");
                return -1;
            }
            // Try and Catch Input to Int
            int itemNumber;
            try
            {
                itemNumber = Int32.Parse(ItemNumber_input);
            }
            catch (Exception)
            {
                Console.WriteLine("Entrada incorrecta: Por favor ingrese el número de producto válido");
                Console.WriteLine("Cancelando transacción...");
                return -1;
            }
            // Decrement for proper iteration number in list
            itemNumber--;
            // Remove the Item from list
            inventario.ItemList.Remove(inventario.ItemList[itemNumber]);
            // Confirmation Display message
            Console.WriteLine("El producto ha sido removido del inventario");
            // Successful Execution Code
            return 1;

        }

        //Funcion para añadir una nueva orden a la lista de ordenes
        public static int CrearOrden(ref ListadoOrdenes ordenes, ref Inventario inventario, string address, string name)
        {
            Orden orden = new Orden(orderName: name, orderAddress: address);

            // Order Menu Driver Loop
            while (true)
            {
                // Menu Selection Display
                // Display Order if at least 1 item is in it
                if (orden.ItemList.Count > 0)
                    Console.WriteLine(orden.ToString());
                else
                {
                    Console.WriteLine("Orden de  " + name + "\nOrder para: " + address);
                    Console.WriteLine("-------------------------------------------");
                }

                Console.WriteLine("¿Qué operación le gustaría realizar?");
                Console.WriteLine("(1) - Agregar un producto a la orden");
                Console.WriteLine("(2) - Borrar un producto de la orden");
                Console.WriteLine("(3) - Guardar Orden");
                Console.WriteLine("(0) - Volver al Menú\n");
                Console.Write("Opcion escogida #> ");

                // Menu Selection Input
                string? selection_input = Console.ReadLine();
                Console.WriteLine("-------------------------------------------");

                // selection_input null catcher
                if (selection_input == null)
                {
                    Console.WriteLine("Error al ingresar datos: Intenta nuevamente.");
                    Console.WriteLine("-------------------------------------------");
                    continue;
                }

                // Switch statement for order menu selection
                switch (selection_input)
                {
                    case "0":
                        // exit to menu
                        Console.WriteLine("Volviendo al menú...");
                        return 1;
                    case "1":
                        // Add Item to Order
                        // Display Inventory
                        Console.WriteLine(inventario.ToString());
                        Console.WriteLine("-------------------------------------------");

                        // Prompt Item Entry
                        Console.WriteLine("Por favor ingrese el número del producto que desea añadir:\n");
                        string? ItemNumber_input;
                        Console.Write("Añadir producto a la orden #> ");
                        ItemNumber_input = Console.ReadLine();
                        Console.WriteLine("-------------------------------------------");

                        // Check Input
                        // Null Check
                        if (ItemNumber_input == null)
                        {
                            Console.WriteLine("Error al ingresar datos: Cancelando la operación...");
                            Console.WriteLine("-------------------------------------------");
                            continue;
                        }

                        // Correct Input Check
                        List<string> inv_nums = new List<string>();
                        for (int i = 0; i < inventario.ItemList.Count; i++)
                        {
                            inv_nums.Add((i + 1).ToString());
                        }
                        if (!inv_nums.Contains(ItemNumber_input))
                        {
                            Console.WriteLine("Error al ingresar datos: Cancelando la operación...");
                            Console.WriteLine("-------------------------------------------");
                            continue;
                        }

                        // Try and Catch Input to Int
                        int itemNumber;
                        try
                        {
                            itemNumber = Int32.Parse(ItemNumber_input);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Entrada incorrecta: Por favor ingrese un número de producto válido");
                            Console.WriteLine("Cancelando la transacción...");
                            Console.WriteLine("-------------------------------------------");
                            continue;
                        }

                        // Decrement for proper iteration number in list
                        itemNumber--;

                        // Add item to order
                        orden.ItemList.Add(inventario.ItemList[itemNumber]);
                        orden.CalculateSubtotal();
                        Console.WriteLine(inventario.ItemList[itemNumber].ItemName + " añadido a la orden.");
                        Console.WriteLine("-------------------------------------------");

                        break;
                    case "2":
                        // Delete Item from Order
                        orden.DeleteItemFromOrder();
                        orden.CalculateSubtotal();
                        break;
                    case "3":
                        // Save Order
                        ordenes.orderList.Add(orden);
                        Console.WriteLine("Orden guardada!.");
                        return 1;
                    default:
                        Console.WriteLine("Por favor ingrese una opción válida!");
                        Console.WriteLine("-------------------------------------------");
                        break;
                }
            }
        }

        //Función para crear orden con envio
        public static int CrearOrdenEnvio(ref ListadoOrdenes ordenes, ref Inventario inventario )
        {
            // Get Name For Order
            string? name_input;
            Console.WriteLine("Por favor ingrese un nombre para la orden:\n");
            Console.Write("Nombre para la orden #> ");
            name_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // Get Address For Order
            string? address_input;
            Console.WriteLine("Por favor ingrese una dirección de envio:\n");
            Console.Write("Dirección de envio #> ");
            address_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // name_input null catcher
            if ((name_input == null) || (address_input == null))
            {
                Console.WriteLine("Error en la entrada");
                Console.WriteLine("Cancelando transacción...");
                Console.WriteLine("-------------------------------------------");
                return -1;
            }

            // Order Driver Function
            CrearOrden(ordenes: ref ordenes, inventario: ref inventario, address: address_input, name: name_input);

            return 1;

        }

        //Función para crear una orden para llevar
        public static int CrearOrdenLlevar(ref ListadoOrdenes ordenes, ref Inventario inventario)
        {
            // Get Name For Order
            string? name_input;
            Console.WriteLine("Por favor ingrese un nombre para la orden:\n");
            Console.Write("Nombre para la orden #> ");
            name_input = Console.ReadLine();
            Console.WriteLine("-------------------------------------------");

            // name_input null catcher
            if (name_input == null)
            {
                Console.WriteLine("Error en la entrada");
                Console.WriteLine("Cancelando transacción...");
                Console.WriteLine("-------------------------------------------");
                return -1;
            }

            // Order Driver Functionality Function
            CrearOrden(ordenes: ref ordenes, inventario: ref inventario, address: "PARA LLEVAR", name: name_input);

            return 1;

        }


    }


}


