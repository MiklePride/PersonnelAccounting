class program
{
    static void Main(string[] args)
    {
        string[] fullNamesPersons = new string[0];
        string[] jobsPersons = new string[0];
        bool isExit = false;

        while (isExit == false)
        {
            Console.WriteLine("1. Добавить досье.\n" +
                "2. Вывести все досье на экран.\n" +
                "3. Удалить досье.\n" +
                "4. Найти досье по фамилии.\n" +
                "5. Выход.");

            switch (Console.ReadLine())
            {
                case "1":
                    AddDossier(ref fullNamesPersons, ref jobsPersons);
                    break;
                case "2":
                    DisplayDossierOnScreen(ref fullNamesPersons, ref jobsPersons);
                    break;
                case "3":
                    DeliteDossier(ref fullNamesPersons, ref jobsPersons);
                    break;
                case "4":
                    SearchDossierByLastName(ref fullNamesPersons, ref jobsPersons);
                    break;
                case "5":
                    isExit = true;
                    break;
                default:
                    Console.WriteLine("Такой команды нет.");
                    break;


            }
                
        }
    }

    static string[] ExpandArray(string[] array, int expandCount = 1)
    {
        string[] temporary = new string[array.Length + expandCount];

        for (int i = 0; i < array.Length; i++)
        {
            temporary[i] = array[i];
        }

        return temporary;
    }

    static string[] ReducingArray(string[] array, int reducingCount = 1)
    {
        string[] temporary = new string[array.Length - reducingCount];

        for (int i = 0; i < array.Length - reducingCount; i++)
        {
         
            temporary[i] = array[i];
        }

        return temporary;
    }

    static void AddDossier(ref string[] fullNamesPersons, ref string[] jobsPersons)
    {
        Console.Clear();
        Console.WriteLine("Введите ФИО:");
        string fullNamePerson = Console.ReadLine();
        Console.WriteLine("Введите должность:");
        string jobPerson = Console.ReadLine();
        Console.Clear();
        Console.Write("Данные записаны!");
        Console.WriteLine("\nНажмите любую кнопку для продолжения возвращения в меню.");
        Console.ReadKey();
        Console.Clear();

        fullNamesPersons = ExpandArray(fullNamesPersons);
        fullNamesPersons[fullNamesPersons.Length - 1] = fullNamePerson;

        jobsPersons = ExpandArray(jobsPersons);
        jobsPersons[jobsPersons.Length - 1] = jobPerson;
    }

    static void DisplayDossierOnScreen(ref string[] fullNamePersons, ref string[] jobPersons)
    {
        Console.Clear();

        for (int i = 0; i < fullNamePersons.Length; i++)
        {
            Console.Write($"{i + 1} - {fullNamePersons[i]}: {jobPersons[i]}.\n");
        }
        Console.WriteLine("\nНажмите любую кнопку для продолжения.");
        Console.ReadKey();
        Console.Clear();
    }

    static void DeliteDossier(ref string[] fullNamePersons, ref string[] jobPersons)
    {
        DisplayDossierOnScreen(ref fullNamePersons, ref jobPersons);

        Console.Write("Введите номер досье, который хотите удалить: ");
        int numberDossier = Convert.ToInt32(Console.ReadLine());
        
        fullNamePersons[numberDossier - 1] = fullNamePersons[fullNamePersons.Length - 1];
        jobPersons[numberDossier - 1] = jobPersons[jobPersons.Length - 1];

        fullNamePersons = ReducingArray(fullNamePersons);
        jobPersons = ReducingArray(jobPersons);
        DisplayDossierOnScreen(ref fullNamePersons, ref jobPersons);
    }

    static void SearchDossierByLastName(ref string[] fullNamePersons, ref string[] jobPersons)
    {
        Console.Clear();
        Console.WriteLine("Введите фамилию для поиска:");
        string lastName = Console.ReadLine();

        for (int i = 0; i < fullNamePersons.Length; i++)
        {
            string[] fullNameSplit = fullNamePersons[i].Split(' ');

            for (int j = 0; j < fullNameSplit.Length; j++)
            {
                if (fullNameSplit[j] == lastName)
                {
                    Console.Write($"{i + 1} - {fullNamePersons[i]}: {jobPersons[i]}.\n");
                }
            }
        }
        Console.WriteLine("\nНажмите любую кнопку для продолжения.");
        Console.ReadKey();
        Console.Clear();
    }
}