using Lab8CSharp.Fourth;
using System.Text.RegularExpressions;

void ReplaceOrRemoveEmail(string filePath, string oldEmail="", string newEmail = "")
{
    // Читаємо вміст вхідного файлу
    string inputText = File.ReadAllText(filePath);
    string outfile = "D:\\CHsarp\\Csharp_Lab8\\output.txt";
    // Визначаємо шаблон для пошуку заданої електронної адреси
    string pattern = @"\b" + Regex.Escape(oldEmail) + @"\b";

    // Виконуємо заміну або видалення адреси
    string resultText;
    if (string.IsNullOrEmpty(newEmail))
    {
        // Видаляємо адресу
        resultText = Regex.Replace(inputText, pattern, "");
    }
    else
    {
        // Замінюємо адресу на новий текст
        resultText = Regex.Replace(inputText, pattern, newEmail);
    }

    // Записуємо змінений текст у файл
    File.WriteAllText(outfile, resultText);
}
void counterEmail()
{
    string inputText = File.ReadAllText("D:\\CHsarp\\Csharp_Lab8\\input.txt");

    // Визначаємо шаблон для пошуку електронних адрес gmail
    string pattern = @"\b[A-Za-z0-9._%+-]+@gmail\.com\b";

    // Знаходимо всі збіги шаблону у тексті
    MatchCollection matches = Regex.Matches(inputText, pattern);

    // Підраховуємо кількість знайдених підтекстів
    int matchCount = matches.Count;

    // Записуємо всі підтексти у новий файл
    using (StreamWriter writer = new StreamWriter("D:\\CHsarp\\Csharp_Lab8\\output.txt"))
    {
        foreach (Match match in matches)
        {
            writer.WriteLine(match.Value);
        }
    }

    Console.WriteLine($"Знайдено {matchCount} адрес gmail.");
}

void first()
{
    Console.WriteLine();
    string filepath = "D:\\CHsarp\\Csharp_Lab8\\input.txt";
    string inputText = File.ReadAllText(filepath);
    Console.WriteLine(inputText);

    Console.WriteLine("(1 - замінити адресу на значення. / 2 - видалити адресу. / 0 - пiдрахувати усі пошти і записати у файл.)");
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 0:
            counterEmail();

            break;
        case 1:
            Console.Write("Введіть пошту яку треба замінити: ");
            string oldValue = Console.ReadLine();
            Console.Write("Введiть нове значення:");
            string newValue = Console.ReadLine();
            ReplaceOrRemoveEmail(filepath, oldValue, newValue);
            Console.WriteLine("OK");
            break;
        case 2:
            Console.Write("Введіть пошту яку треба видалити: ");
            string deleteValue = Console.ReadLine();
            ReplaceOrRemoveEmail(filepath,deleteValue);
            Console.WriteLine("OK");
            break;

    }


}

void second()
{
    string inputFilePath = "D:\\CHsarp\\Csharp_Lab8\\SecTaskInput.txt";
    string outputFilePath = "D:\\CHsarp\\Csharp_Lab8\\SecTaskOutput.txt";

    // Читаємо вміст вхідного файлу
    string inputText = File.ReadAllText(inputFilePath);

    // Визначаємо шаблон для пошуку шістнадцяткових цифр
    string pattern = "[0-9A-F]";

    // Замінюємо всі шістнадцяткові цифри на "+"
    string resultText = Regex.Replace(inputText, pattern, "+");

    // Записуємо змінений текст у новий файл
    File.WriteAllText(outputFilePath, resultText);

    Console.WriteLine("ОК.");
}

void third()
{
    string filename = "D:\\CHsarp\\Csharp_Lab8\\Third_In.txt";
    string text = File.ReadAllText(filename);
    string editedText = EditText(text);
    Console.WriteLine("OK");
    File.WriteAllText ("D:\\CHsarp\\Csharp_Lab8\\Third_Out.txt", editedText);
}
static string EditText(string text)
{
    

    string[] words = Regex.Split(text, @"(\s+|\W+)");


    for (int i = 0; i < words.Length; i++)
    {
   
        if (words[i].Length % 2 != 0)
        {
     
            int middleIndex = words[i].Length / 2;
            words[i] = words[i].Remove(middleIndex, 1);
        }
    }

    
    string editedText = string.Join(" ", words);
    return editedText;
}

void fourth()
{
    Fourth fourth = new Fourth();
    fourth.fourth();
}

static void fifth()
{
    string studentLastName = "Krutov";
    string directory1 = $@"D:\temp\{studentLastName}1";
    string directory2 = $@"D:\temp\{studentLastName}2";
    string file1Path = Path.Combine(directory1, "t1.txt");
    string file2Path = Path.Combine(directory1, "t2.txt");
    string file3Path = Path.Combine(directory2, "t3.txt");


    Directory.CreateDirectory(directory1);
    Directory.CreateDirectory(directory2);


    string text1 = "<Шевченко Степан Іванович, 2001> року народження, місце проживання <м. Суми>";
    string text2 = "<Комар Сергій Федорович, 2000> року народження, місце проживання <м. Київ>";
    File.WriteAllText(file1Path, text1);
    File.WriteAllText(file2Path, text2);


    using (StreamWriter writer = new StreamWriter(file3Path))
    {
        writer.WriteLine(File.ReadAllText(file1Path));
        writer.WriteLine(File.ReadAllText(file2Path));
    }

 
    Console.WriteLine($"Створені файли:");
    Console.WriteLine($"Файл {file1Path}: {File.ReadAllText(file1Path)}");
    Console.WriteLine($"Файл {file2Path}: {File.ReadAllText(file2Path)}");
    Console.WriteLine($"Файл {file3Path}: {File.ReadAllText(file3Path)}");


    File.Move(file2Path, Path.Combine(directory2, "t2.txt"));

    File.Copy(file1Path, Path.Combine(directory2, "t1.txt"), true);


    Directory.Move(directory2, @"D:\temp\ALL");
    Directory.Delete(directory1, true); 


    string[] allFiles = Directory.GetFiles(@"D:\temp\ALL");
    Console.WriteLine("\nПовна інформація про файли папки ALL:");
    foreach (string file in allFiles)
    {
        Console.WriteLine($"Файл: {file}, Розмір: {new FileInfo(file).Length} байт");
    }


}

void main()
{
    Console.Write("Enter your choice: ");
    int choise = int.Parse(Console.ReadLine());
    switch (choise)
    {
        case 1: first(); break;
        case 2: second(); break;
        case 3: third(); break;
        case 4: fourth(); break;
        case 5: fifth(); break;
    }
}
main();
