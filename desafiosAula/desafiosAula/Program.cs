void guessNumber()
{
    Random random = new Random();
    int number = random.Next(1, 101);
    int guess;

    do
    {
        string stringGuess = Console.ReadLine()!;
        guess = int.Parse(stringGuess);

        if (guess > number) Console.WriteLine("It's smaller");
        else if (guess < number) Console.WriteLine("It's heigher");
    }
    while (guess != number);

    Console.WriteLine("Congrats! You guessed the number");
}

void pairNumbers()
{
    Random random = new Random();
    List<int> numbers = new List<int>();
    int sizeListNumbers = 10;


    for (int i = 0; i < sizeListNumbers; i++)
    {
        int n = random.Next(0, 101);
        Console.Write($"{n} ");
        numbers.Add(n);
    }

    Console.WriteLine();
    foreach (int number in numbers)
    {
        if (number % 2 == 0)
        {
            Console.Write($"{number} ");
        }
    }

    Console.WriteLine();
    for (int i = 0; i < sizeListNumbers; i++)
    {
        if (numbers[i] % 2 == 0)
        {
            Console.Write($"{numbers[i]} ");
        }
    }

}

void carAverage()
{
    Dictionary<string, List<int>> vendasCarros = new Dictionary<string, List<int>> {
    { "Bugatti Veyron", new List<int> { 10, 15, 12, 8, 5 } },
    { "Koenigsegg Agera RS", new List<int> { 2, 3, 5, 6, 7 } },
    { "Lamborghini Aventador", new List<int> { 20, 18, 22, 24, 16 } },
    { "Pagani Huayra", new List<int> { 4, 5, 6, 5, 4 } },
    { "Ferrari LaFerrari", new List<int> { 7, 6, 5, 8, 10 } }
    };

    Console.Write("Digite o modelo de um carro: ");

    string carro = Console.ReadLine()!;

    if (vendasCarros.ContainsKey(carro))
    {
        Console.WriteLine($"A media de vendas do carro {carro} eh de {vendasCarros[carro].Average()}");
    }
    else {
        Console.WriteLine("Nao foi possivel encontrar este carro, tente novamente");
        Console.WriteLine("Pressione uma tecla para voltar ao menu");
        Console.ReadKey();
        Console.Clear();
        carAverage();
    }
}


// guessNumber();
// pairNumbers();
carAverage();