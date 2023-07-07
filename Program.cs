////////////////////Practicando las clases para ver como lo haria/////////////
using System;
///La clase que recibira los parametros y tendra la funcion de obtener el producto y dar propiedades;
public class Maquina
{
    
    public string Producto;
    public int Cantidad, Precio,valor=5;
    public static int total;
    public Maquina(string producto, int precio)
    {
        Producto = producto;
        Cantidad = valor;
        Precio = precio;
    }
////////Esta funcion solo le pertenece al usuario ya que no tiene la capacidad de editarlo 
    public string obtener()
    {
        valor= --this.Cantidad;
        
        total+= this.Precio;

        return $"\nHaz seleccionado: {Producto}\nDisponible: {valor} items\nPrecio: {Precio}\n ***Suma Precio {total}***";
    }
////////Esta es la del Admnistrador que llenara los stocks vacios
     public void editar(int num)
    {
        this.valor+= num;
    }
}

public class MaquinaLlamado
{
    static void Main()
    {
///Creacion de array con diferentes productos///
        Maquina[] contenedor= new Maquina[5]; 
        contenedor[0]= new Maquina("Lays", 30);
        contenedor[1]= new Maquina("Pepsi", 25);
        contenedor[2]= new Maquina("M&M", 70);
        contenedor[3]= new Maquina("Esponjoso(Bizcochito)", 15);
        contenedor[4]= new Maquina("Agua(Cascada)", 20);

////Pregunta inicial de cual es tu rol////
        int desicion,digitos,contraseña,i;
        Console.WriteLine("Elige el número de qué eres?\n[1]Usuario\n[2]Administrador");
            desicion= int.Parse(Console.ReadLine()!);
            digitos= 1298;
            i=0;
///////Funcion para el Usuario
        static void UsuarioPedidos(int i, Maquina[]contenedor){

            Console.WriteLine("Que producto desea comprar?");
            foreach(var j in contenedor){
                Console.WriteLine($"{i++} {j.Producto}");
                }
            i=0;

           Console.Write("Elije: ");
           int desicion= int.Parse(Console.ReadLine()!);
           Console.WriteLine(contenedor[desicion].obtener());

            if(contenedor[desicion].valor==0){
                Console.WriteLine("Producto agotado, vuelva por mas otro dia");
            } 
//////Ahora usare una recursion, esto hace que se repita multiples veces el codigo hasta que la condicion sea falsa
           Console.WriteLine("\nQuieres seguir ordenando?\n[1]Si o [2]No");
           desicion= int.Parse(Console.ReadLine()!);
           if(desicion==2){
                Console.WriteLine("Gracias por comprar, adiós");
            } 
           while (desicion==1)
                {
                    desicion=0;
                    UsuarioPedidos(i,contenedor);
                }   
        }
//////////Misma funcion que use para el usuario, pero ahora esta en el Admin
                static void AdminRellenar(int i, Maquina[]contenedor,int desicion){

                    Console.WriteLine("Cual producto quieres rellenar?");
                    foreach(var j in contenedor){
                        Console.WriteLine($"{i++} {j.Producto}--- {j.valor}");
                        }
                    i=0;
                    Console.Write("Elije: ");
                    desicion= int.Parse(Console.ReadLine()!);
////Basicamente verifico la distancia entre los productos que hay y los que deberian de haber y se lo inyecto usando Math.Abs()                
                    if(contenedor[desicion].valor <=7){
                        int valorIntroducir= Math.Abs(contenedor[desicion].valor-8);
                        contenedor[desicion].editar(valorIntroducir);
                    }
//////Denuevo usare una recursion, esto hace que se repita multiples veces el codigo hasta que la condicion sea falsa
                    Console.WriteLine("\nQuieres seguir rellenando?\n[1]Si o [2]No");
                    desicion= int.Parse(Console.ReadLine()!);
                    while (desicion==1)
                    {
                        desicion=0;
                        AdminRellenar(i,contenedor,desicion);
                    }   
                }        

        switch(desicion){
            case 1:

                UsuarioPedidos(i,contenedor); 

            break;
//////////////////////Aqui abajo esta el admin
///Yo tenia pensado que el programa se ejecutara todo el rato a modo de reloj y que acceder al modo admin solo sea insertar un codigo
/// Esto es parecido a los videojuegos donde todo se ejercuta mientras una condicion sea verdadera
///Entonces en vez de dejar explicita la opcion, se deja implicita, el usuario no tiene que elegir si es usuario o admin
            case 2:
                Console.Write("Inserte su contraseña: ");
                    contraseña=int.Parse(Console.ReadLine()!);

                    if(contraseña== digitos){
                        AdminRellenar(i,contenedor,desicion);
                    
                    }
                    
                    else{
                       
                        while(contraseña!= digitos){
                        Console.Write("La contraseña insertada es incorrecta, inserte denuevo: ");
                        contraseña=int.Parse(Console.ReadLine()!);
                        Console.WriteLine($"Numero de intentos disponibles: {i}/6");

                            if(i>=6){
                            Console.WriteLine("Ha agotado el numero de intentos, cerrare el programa.");
                            break;
                            }
                        i++;
                    }}
                    
            break;
            default:
                Console.WriteLine("No ha seleccionado uno de los números mencionados anteriormente, adiós");
            break;
        }
    }
}
