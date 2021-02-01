using System;

class MainClass {
  public static void Main (string[] args) {

    // Creamos una nueva pila vacia.
    Stack<string> stack = new Stack<string>(5);

    //Agregamos un nuevo elemento a la pila
    stack.push("Primer elemento");
    stack.push("Segundo elemento");
    stack.push("Tercero elemento");

    Console.WriteLine("Ultimo elemento: "+stack.top());

    stack.pop();
    stack.pop();

    // stack.push("Elemento extra");

    Console.WriteLine("Ultimo elemento: "+stack.top());

    Console.WriteLine("El tamaño de la pila : " + stack.size());
    Console.WriteLine("¿La pila esta vacia? " + stack.empty());

  }
}

public class Stack<T> {
  private T[] stack;
  int currentPosition = 0; 

  // Crear (constructor): crea la pila vacía.
  public Stack(int size){
    stack = new T[size];
  }

  // Apilar (push): añade un elemento a la pila.
  public void push(T input) {
    stack[currentPosition] = input;
    currentPosition++;
  }

  // Desapilar (pop): lee y retira el elemento superior de la pila.
  public void pop() {
    currentPosition--;
  }

  // Leer último (top o peek): lee el elemento superior de la pila sin retirarlo.
  public T top(){
    if (empty()) {
      throw new Exception("La pila esta vacia");
    }

    return stack[currentPosition - 1];
  }

  // Tamaño (size): regresa el número de elementos de la pila. 
  public int size(){
    return currentPosition;
  }

  // Vacía (empty): devuelve cierto si la pila está sin elementos o falso en caso de que contenga alguno.
  public bool empty(){
    return currentPosition == 0;
  }
}
