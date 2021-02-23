using System;

class MainClass {
  public static void Main (string[] args) {

    // Creamos una nueva pila vacia.
    Stack stack = new Stack(5);

    //Agregamos un nuevo elemento a la pila
    stack.Push("Primer elemento");
    stack.Push("Segundo elemento");
    stack.Push("Tercero elemento");

    Console.WriteLine("Ultimo elemento: " + stack.Top());

    stack.Pop();
    stack.Pop();

    Console.WriteLine("Ultimo elemento: " + stack.Top());

    Console.WriteLine("El tamaño de la pila : " + stack.Size());
    Console.WriteLine("¿La pila esta vacia? " + stack.Empty());
  }
}

/// <summary>
/// Clase Stack. Basada en la estructura de .NET. https://docs.microsoft.com/en-us/dotnet/api/system.collections.stack?view=net-5.0
/// </summary>
public class Stack
{
    private const int DEFAULT_STACK_SIZE = 10;
    private object[] _stackItems;
    private int currentPosition = -1;

    //  Este constructor crea la pila con un tamaño por defecto. La pila irá incrementado de acuerdo a lo necesario. 
    public Stack() 
        : this(DEFAULT_STACK_SIZE)
    { }

    //  Constructor que recibe un tamaño inicial.
    public Stack(int initialSize)
    {
        if(initialSize < DEFAULT_STACK_SIZE)
            _stackItems = new object[DEFAULT_STACK_SIZE];
        else
            _stackItems = new object[initialSize];
    }

    //  Apilar (push): añade un elemento a la pila.
    public void Push(object input)
    {
        var nextPosition = ++currentPosition;
        bool isHigherOrEqual = nextPosition >= _stackItems.Length;

        if (isHigherOrEqual)
            Resize();

        _stackItems[currentPosition] = input;
    }

    //  Desapilar (pop): lee y retira el elemento superior de la pila.
    public void Pop()
    {
        if (Empty())
            throw new InvalidOperationException("Stack is empty.");

        currentPosition--;
    }

    //  Leer último (top o peek): lee el elemento superior de la pila sin retirarlo.
    public object Top()
    {
        if (Empty())
        {
            throw new Exception("La pila esta vacia");
        }

        return _stackItems[currentPosition];
    }

    //  Tamaño (size): regresa el número de elementos de la pila. 
    public int Size()
    {
        return currentPosition + 1;
    }

    //  Vacía (empty): devuelve cierto si la pila está sin elementos o falso en caso de que contenga alguno.
    public bool Empty()
    {
        return currentPosition < 0;
    }

    // Reajusta la colección al doble de su tamaño actual.
    private void Resize()
    {
        var currentSize = _stackItems.Length;

        var newStack = new object[currentSize * 2];

        for (int increment = 0; increment < currentSize; increment++)
            newStack[increment] = _stackItems[increment];

        _stackItems = newStack;
    }
}
