/* variables */
Dictionary<string, List<int>> bands = new Dictionary<string, List<int>>();

void title() 
{
    Console.Clear();
    string titleMessage = "\r\n░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░\r\n██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗\r\n╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║\r\n░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║\r\n██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝\r\n╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";
    
    /* Verbatim Literal (@) - interpreta e exibe o conteúdo final da string */
    titleMessage = @"
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░";

    Console.WriteLine($"{titleMessage}\n");
}

void waitKey()
{
    Console.WriteLine("Press any key to quit");
    Console.ReadKey();
}

void help() 
{
    Console.WriteLine("1 - Register a band");
    Console.WriteLine("2 - Show all bands");
    Console.WriteLine("3 - Rate a band");
    Console.WriteLine("4 - Band's average");
    Console.WriteLine("5 - Quit");
    waitKey();
}

void writeMessage(string message = "")
{
    if (message.Length > 0) Console.WriteLine(message);
    Console.WriteLine("Returning to Menu...");
    Thread.Sleep(1500);
}

int readOption()
{
    title();

    /* Write: Sem \n no final*/
    Console.Write("Write the desired option (0 for help): ");

    /* Exclamação ao final do ReadLine impede que a entrada seja nula */
    string option = Console.ReadLine()!;
    return int.Parse(option);
}

bool searchBand(string bandName) { 
    foreach (string band in bands.Keys){
        if (band.Equals(bandName)) return true;
    }
    return false;
}

int readRate()
{
    title();
    Console.Write("Type a rate (1 - 5): ");

    string stringRate = Console.ReadLine()!;
    int rate = int.Parse(stringRate);

    if (rate > 5 || rate < 0)
    {
        writeMessage("Invalid rate, try again");
        return readRate();
    }
    else return rate;
}

float bandAverage(string bandName)
{
    float average = 0;
    List<int> rates = bands[bandName];
    if (rates.Count > 0) average = (float) rates.Sum() / rates.Count;
    return average;
}

void goToOption(int value)
{
    switch (value)
    {
        case 0: help(); break;
        case 1: newBand(); break;
        case 2: showBands(false); break;
        case 3: rateBand(); break;
        case 4: showBands(true); break;
        default: writeMessage("Invalid option, try again"); break;
    }
}

/* Options Functions */
void newBand()
{
    title();

    Console.WriteLine("Registering a new band");
    Console.Write("Type the band's name: ");

    string bandName = Console.ReadLine()!;
    bands.Add(bandName, new List<int>());
    Console.WriteLine($"The band '{bandName}' was registered succesfully");
    writeMessage();
}

void showBands(bool showAverage)
{
    title();
    Console.WriteLine("Registered Bands");

    int i = 1;
    foreach (string band in bands.Keys) { 
        if (showAverage) Console.WriteLine($"{i++}  - {band}: {bandAverage(band)}/5");
        else Console.WriteLine($"{i++}  - {band}");
    }
    Console.WriteLine($"Total: {bands.Count} bands");
    Console.WriteLine("----------------------");
    waitKey();
}

void rateBand(){
    title();
    Console.WriteLine("Rating a Band");

    Console.Write("Type the band's name: ");
    string bandName = Console.ReadLine()!;
    
    if (!searchBand(bandName)){
        writeMessage("Invalid band's name, try again");
        rateBand();
    }
    else
    {
        Console.WriteLine($"Rating the band {bandName}");
        int rate = readRate();
        bands[bandName].Add(rate);
        Console.WriteLine($"The rate of '{bandName}' was registered succesfully");
        writeMessage();
    }
}

void main()
{
    while (true)
    {
        int option = readOption();
        if (option == 5) {
            Console.WriteLine("Bye bye :D");
            break;
        }
        goToOption(option);
    }
}
main();