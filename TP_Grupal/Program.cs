using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TP_Grupal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Crear un programa que pida al usuario 10 números enteros y luego los muestre en
            //orden contrario, utilizando una pila.
            Console.WriteLine("Ejercicio 1");
            Ejercicio1();

            //Desarrollar un programa que pida 5 palabras, las muestre en pantalla apiladas y
            //finalmente deje solo la primera palabra que fue ingresada.
            Console.WriteLine("Ejercicio 2");
            Ejercicio2();

            //Crear una pila que permita agrupar marcas de celulares hasta ingresar la palabra fin.
            //Luego utilizar o crear una función que diga si alguna marca particular está en la pila
            //o no, por último, vaciar la pila.
            Console.WriteLine("Ejercicio 3");
            Ejercicio3();

            //Crear una interface relacionada con alguna tematica eligida, con la firma de dos
            //métodos, e implementarla en otras dos clases.
            Console.WriteLine("Ejercicio 4");
            Ejercicio4();

            //Desarrollar un programa que pida al usuario 5 números reales de doble precisión(double),
            //los guarde en una cola y luego los muestre en pantalla.
            Console.WriteLine("Ejercicio 5");
            Ejercicio5();

            //Crear un programa que pida frases al usuario, hasta que introduzca una frase vacía.En ese
            //momento, mostrará todas las frases que se habían introducido.
            Console.WriteLine("Ejercicio 6");
            Ejercicio6();

            //Desarrollar mediante un switch un sistema que permita agregar, quitar y mostrar los
            //elementos de una cola.
            Console.WriteLine("Ejercicio 7");
            Ejercicio7();


            //Crear una clase abstracta relacionada con alguna tematica elegida, con un método
            //abstracto y otro método no abstracto, e implementarla en otras dos clases.
            Console.WriteLine("Ejercicio 8");
            Ejercicio8();

        }
        static void Ejercicio1()
        {
            Stack pila = new Stack();

            Console.WriteLine("Ingrese 10 números");

            for (int i = 0; i < 10; i++)
            {
                int numPila = Int32.Parse(Console.ReadLine());
                pila.Push(numPila);
            }

            foreach (var item in pila)
            {
                Console.WriteLine(item);
            }
        }

        static void Ejercicio2()
        {
            Console.WriteLine("Ingrese 5 palabras");
            Stack pila = new Stack();

            for (int i = 0; i < 5; i++)
            {
                string palabraPila = Console.ReadLine();
                pila.Push(palabraPila);
            }

            foreach (var item in pila)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < 4; i++)
            {
                pila.Pop();
            }

            foreach (var item in pila)
            {
                Console.WriteLine("Primera palabra ingresada: ");
                Console.WriteLine(item);
            }
        }

        static void Ejercicio3()
        {
            Stack pila = new Stack();
            string opcion;
            string[] marcasCelulares = new string[] { "Samsung", "Apple", "Xiaomi", "Motorola", "Huawei" };

            do
            {
                Console.WriteLine("Ingresar una marca. Cuando no quieras ingresar mas poner 'fin'.");
                opcion = Console.ReadLine();
                if (marcasCelulares.Contains(opcion))
                {
                    pila.Push(opcion);
                }
                else
                {
                    Console.WriteLine("Insertar una de las marcas de la base de datos.");
                }
            } while (opcion != "fin");

            foreach (var item in pila)
            {
                Console.WriteLine(item);
            }

            averiguarMarca(pila);
            pila.Clear();

        }
        static void averiguarMarca(Stack pila)
        {
            if (pila.Contains("Samsung"))
            {
                Console.WriteLine("La pila creada contiene la marca Samsung");
            }
            else
            {
                Console.WriteLine("La pila creada no contiene a la marca Samsung");
            }

        }

        static void Ejercicio4()
        {
            Guerrero guerrero1 = new Guerrero()
            {
                nombre = "Lord"
            };
            guerrero1.SetAtributos("Ataque: 50");
            guerrero1.SetAtributos("Defensa: 80");

            Mago mago1 = new Mago()
            {
                nombre = "Magus"
            };
            mago1.SetAtributos("Ataque: 65");
            mago1.SetAtributos("Defensa: 85");

            mago1.MostrarAtributos();
            guerrero1.MostrarAtributos();
        }

        public interface IPersonaje
        {
            void MostrarAtributos();
            void LimpiarAtributos();
        }

        public class Mago : IPersonaje
        {
            public string nombre;
            public Stack atributos = new Stack();

            public void SetAtributos(string nuevoAtributo)
            {
                atributos.Push(nuevoAtributo);
            }

            public void MostrarAtributos()
            {
                foreach (var item in atributos)
                {
                    Console.WriteLine("Atributo: " + item);
                }
            }

            public void LimpiarAtributos()
            {
                atributos.Clear();
            }
        }

        public class Guerrero : IPersonaje
        {
            public string nombre;
            public Stack atributos = new Stack();

            public void SetAtributos(string nuevoAtributo)
            {
                atributos.Push(nuevoAtributo);
            }
            public void MostrarAtributos()
            {
                foreach (var item in atributos)
                {
                    Console.WriteLine("Atributo: " + item);
                }
            }

            public void LimpiarAtributos()
            {
                atributos.Clear();
            }
        }

        public static void Ejercicio5()
        {
            Queue cola = new Queue();
            Console.WriteLine("Ingrese 5 numeros");
            for (int i = 0; i < 5; i++)
            {
                int numero = Int32.Parse(Console.ReadLine());
                cola.Enqueue(numero);
            }
            foreach (var item in cola)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio6()
        {
            Console.WriteLine("Ingresar frases. Cuando no quiera ingresar aprete enter sin ingresar nada.");
            Queue cola = new Queue();
            string frase;
            do
            {
                frase = Console.ReadLine();
                cola.Enqueue(frase);
            } while (frase != "");
            Console.WriteLine("Frases ingresadas:");
            foreach (var item in cola)
            {
                Console.WriteLine(item);
            }
        }

        public static void Ejercicio7()
        {
            Queue cola = new Queue();

            while (true)
            {
                Console.WriteLine("Elegir una de las opciones: 'agregar', 'quitar', 'mostrar' o 'finalizar'.");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "agregar":
                        Console.WriteLine("Ingresa lo que quieres agregar a la cola.");
                        string elementoAIngresar = Console.ReadLine();
                        cola.Enqueue(elementoAIngresar);
                        break;
                    case "quitar":
                        if (cola.Count > 0)
                        {
                            Console.WriteLine("Eliminamos el primer elemento de la cola.");
                            cola.Dequeue();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("La cola esta vacia.");
                            break;
                        }
                    case "mostrar":
                        if (cola.Count > 0)
                        {
                            Console.WriteLine("Estos son los elementos de la cola: ");
                            foreach (var item in cola)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("La cola no tiene elementos.");
                            break;
                        }
                    case "finalizar":
                        Console.WriteLine("Finalizando el programa");
                        return;
                    default:
                        Console.WriteLine("Ingrese una opción valida.");
                        break;
                }

            }
        }

        public static void Ejercicio8()
        {
            Gato gato1 = new Gato()
            {
                nombre = "Min"
            };

            gato1.setCaracteristicas("Pelo: Negro");

            Perro perro1 = new Perro()
            {
                nombre = "Milo"
            };

            perro1.setCaracteristicas("Pelo: Rubio");

            gato1.MostrarCaracteristicas();

            perro1.MostrarCaracteristicas();



        }

        public abstract class Animal
        {
            public string nombre;
            public Queue caracteristicas = new Queue();

            public void setCaracteristicas(string nuevaCaracteristica)
            {
                caracteristicas.Enqueue(nuevaCaracteristica);
            }
            public void MostrarNombre()
            {
                Console.WriteLine("El nombre es: "+nombre);
            }

            public abstract void MostrarCaracteristicas();
        }

        public class Perro: Animal
        {
            public override void MostrarCaracteristicas()
            {
                Console.WriteLine("Las caracteristicas del perro son: ");
                foreach (var item in caracteristicas)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public class Gato : Animal
        {
            public override void MostrarCaracteristicas()
            {
                Console.WriteLine("Las caracteristicas del gato son: ");
                foreach (var item in caracteristicas)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
