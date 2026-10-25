using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Kondratiev4
{
    internal class Methods
    {
        //Нормализовать ФИО
        static public void Normalized()

        {
            Console.WriteLine("ФИО: ");

            string something = Console.ReadLine();

            string[] normalized = something.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int count = 0;

            for (int i = 0; i < normalized.Length; i++)
            {
                string item = normalized[i];

                item = Char.ToUpper(item[0]) + item.Substring(1).ToLower();

                normalized[i] = item;

                count++;
            }

            Console.WriteLine("Было: " + something);

            Console.WriteLine("Стало: " + string.Join(" ", normalized));

            Console.WriteLine("Слов: " + count);

        }

        //Подсчитать знаки в тексте
        static public void EverythingIsCounted()
        {
            Console.WriteLine("Текст: ");

            string something = Console.ReadLine();
            something = something.ToLower();


            List<char> cons = new List<char>();
            List<char> vowels = new List<char>();
            List<char> numbers = new List<char>();
            List<char> random = new List<char>();
            string allCons = "йцкнгшщзхъфвпрлджчсмтьбqwrtypsdfghjklzxcvbnm";
            string allVowels = "ёуеыаоэяиюeuioa";
            string allNumbers = "1234567890";

            foreach (char c in allCons)
            {
                cons.Add(c);
            }
            foreach (var item in allVowels)
            {
                vowels.Add(item);
            }
            foreach (char num in allNumbers)
            {
                numbers.Add(num);
            }

            List<char> consCount = new List<char>();
            List<char> vowelsCount = new List<char>();
            List<char> numbersCount = new List<char>();
            List<char> otherCount = new List<char>();

            foreach (var character in something)
            {
                if (cons.Contains(character))
                {
                    consCount.Add(character);
                }
                if (vowels.Contains(character))
                { vowelsCount.Add(character); }
                if (numbers.Contains(character)) { numbersCount.Add(character); }
                if (!cons.Contains(character) && !vowels.Contains(character) && !numbers.Contains(character))
                {
                    otherCount.Add(character);
                }

            }

            Console.WriteLine("гласных: " + vowelsCount.Count);

            Console.WriteLine("согласных: " + consCount.Count);

            Console.WriteLine("цифр: " + numbersCount.Count);
            Console.WriteLine("прочего: " + otherCount.Count);

        }

        //Сделать из имени инициалы
        public static void FullName()
        {

            Console.WriteLine("ФИО: ");

            string something = Console.ReadLine();

            string[] normalized = something.Split(' ', StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < normalized.Length; i++)
            {
                string item = normalized[i];

                item = Char.ToUpper(item[0]) + item.Substring(1).ToLower();

                normalized[i] = item;

            }


            if (normalized.Length < 2)
            {
                Console.WriteLine("Введено меньше двух слов");
            }

            else if (normalized.Length == 2)
            {
                char firstInitial = normalized[1].First();
                Console.WriteLine(normalized[0] + " " + firstInitial + ". ");
            }

            else
            {
                char firstInitial = normalized[1].First();
                char secondInitial = normalized[2].First();
                Console.WriteLine(normalized[0] + " " + firstInitial + ". " + secondInitial + ". ");
            }
        }

        //исправить телефонный номер
        public static void PhoneNumber()
        {
            Console.WriteLine("Телефон: ");

            string something = Console.ReadLine();

            string allNumbers = "1234567890";

            List<char> numbers = new List<char>();
            List<char> numbersFromSomething = new List<char>();

            foreach (char num in allNumbers)
            {
                numbers.Add(num);
            }

            foreach (char ch in something)
            {
                if (numbers.Contains(ch))
                {
                    numbersFromSomething.Add(ch);
                }
            }

            if (numbersFromSomething.Count < 11)
            {
                Console.WriteLine("Ошибка: нужно 11 цифр, получено " + numbersFromSomething.Count);
            }

            else
            {
                Console.WriteLine("+" + numbersFromSomething[0] + " (" + numbersFromSomething[1] + numbersFromSomething[2] + numbersFromSomething[3] + ") ***-**-" + numbersFromSomething[9] + numbersFromSomething[10]);
            }
        }

        public static void StraightTable()
        {
            string[] names = { "Молоко", "Хлеб", "Шоколад", "Кофе" };
            int[] quantities = { 5, 10, 3, 2 };
            double[] prices = { 89.50, 45.00, 120.75, 350.00 };

            double total = 0;

            Console.WriteLine($"{"Название",-12}{"Количество",8}{"Цена",10}");
            Console.WriteLine(new string('-', 30));

            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine($"{names[i],-12}{quantities[i],8}{prices[i],10:F2}");

                total += quantities[i] * prices[i];
            }

            Console.WriteLine(new string('-', 30));
            Console.WriteLine($"{"ИТОГО:",-20}{total,10:F2}");
        }
        public static void ReadAndWrite()
        {
            String filename = "demo.txt";

            Console.WriteLine("Введите 3-5 строк:");

            List<string> allStrings = new List<string>();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{i + 1} строка:");
                string line = Console.ReadLine().ToString();
                if (line != string.Empty)
                {
                    allStrings.Add(line);
                }
                else
                {
                }
            }

            if (allStrings.Count < 3)
            {
                Console.WriteLine("Вам сказали ввести 3-5 строк, а не меньше!");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(filename))
                {
                    for (int j = 0; j < allStrings.Count; j++)
                    {
                        sw.WriteLine($"{j + 1} {allStrings[j]}");
                    }
                }

                Console.WriteLine("Записали! Теперь прочитаем:");
                string line = "";

                using (StreamReader sr = new StreamReader(filename))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
        }

        public static void SumOfNumbersFromFile()
        {
            Console.WriteLine("Введите название файла: ");
            string typeFile = Convert.ToString(Console.ReadLine());
            string filename = typeFile + ".txt";

            double sum = 0;
            int numbers = 0;
            int trash = 0;

            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} не найден!");
                return;
            }

            using (StreamReader sr = new StreamReader(filename))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);

                    bool hasNumbers = false;

                    string[] numbersInLine = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var num in numbersInLine)
                    {
                        if (double.TryParse(num, out double newNumber))
                        {
                            sum += newNumber;
                            numbers++;
                            hasNumbers = true;

                        }
                    }
                    if (!hasNumbers)
                    {
                        trash++;
                    }

                }
                Console.WriteLine($"Сумма: {sum:F2}");
                Console.WriteLine($"Чисел: {numbers} | мусора: {trash}");

            }
        }


        public static Dictionary<Questionaries, string> trashAndReasons = new Dictionary<Questionaries, string>();
        public static void MainTask()
        {
            List<string> editedLines = new List<string>();
            List<List<string>> questionnaireLines = new List<List<string>>();
            List<Questionaries> allPeople = new List<Questionaries>();

            string filename = ReadFile();
            if (filename != null)
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    DeleteEmptyLines(sr, editedLines);
                    GetAllPeopleLines(editedLines, allPeople);
                    FixNames(allPeople);
                    NormalizeNames(allPeople);
                    FixEmails(allPeople);
                    FixPhoneNumbers(allPeople);
                    FixGroups(allPeople);
                    SortQuestionaries(allPeople);
                    ShowAllPeople(allPeople);
                    SaveInNewFiles(allPeople, trashAndReasons);
                }
            }
        }

        public static string ReadFile()
        {
            Console.WriteLine("Введите название файла: ");
            string typeFile = Convert.ToString(Console.ReadLine());
            string filename = typeFile + ".txt";

            if (!File.Exists(filename))
            {
                Console.WriteLine($"Файл {filename} не найден!");
                return null;
            }
            else
            {
                return filename;
            }
        }

        public static List<string> DeleteEmptyLines(StreamReader sr, List<string> editedLines)
        {
            string line = "";
            while ((line = sr.ReadLine()) != null)
            {
                if (line != string.Empty)
                {
                    editedLines.Add(line);
                }
            }
            return editedLines;
        }

        public static List<Questionaries> GetAllPeopleLines(List<string> edited, List<Questionaries> all)
        {
            foreach (string line in edited)
            {
                string[] newQuestionaryLine = line.Split(';', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < newQuestionaryLine.Length; i++)
                {
                    newQuestionaryLine[i] = newQuestionaryLine[i].Trim();
                }

                if (newQuestionaryLine.Length != 4 || newQuestionaryLine.Any(field => field == ""))
                {
                    /////////////////////////
                    string fullName = newQuestionaryLine.Length > 0 ? newQuestionaryLine[0] : "";
                    string email = newQuestionaryLine.Length > 1 ? newQuestionaryLine[1] : "";
                    string phone = newQuestionaryLine.Length > 2 ? newQuestionaryLine[2] : "";
                    string group = newQuestionaryLine.Length > 3 ? newQuestionaryLine[3] : "";

                    Questionaries trashPerson = new Questionaries(
                        fullName, email, phone, group);

                    DeleteLikeATrash(
                        trashAndReasons, trashPerson, "Нет полных данных!");


                    continue;
                }
                else
                {
                    Questionaries person = new Questionaries(newQuestionaryLine[0], newQuestionaryLine[1],
                        newQuestionaryLine[2], newQuestionaryLine[3]);
                    all.Add(person);
                }
            }
            return all;
        }

        public static void ShowAllPeople(List<Questionaries> all)
        {
            Console.WriteLine(
                $"{"#",-4} {"ФИО",-30} {"Почта",-30} {"Телефон",-20} {"Группа",-15}");

            Console.WriteLine(new string('-', 105));

            for (int i = 0; i < all.Count; i++)
            {
                var person = all[i];

                string phone = person.PhoneNumber;

                if (phone.Length >= 10)
                {
                    phone = phone.Substring(0, 9) + "***-**-" + phone.Substring(phone.Length - 2);
                }

                Console.WriteLine(
                    $"{i + 1,-4} {person.FullName,-30} {person.Email,-30} {phone,-20} {person.Group,-15}");
            }

            Console.WriteLine("Отверженные:");

            foreach (var person in trashAndReasons)
            {

                Console.WriteLine(
                    $"{person.Key.FullName,-30} {person.Key.Email,-30} {person.Key.PhoneNumber,-20} {person.Key.Group,-15}");
                Console.WriteLine("Причина тряски: " + person.Value);
            }

        }

        public static List<Questionaries> FixNames(List<Questionaries> all)
        {
            for (int i = all.Count - 1; i >= 0; i--)
            {
                {
                    string[] trimmedName = all[i].FullName.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    if (trimmedName.Length < 3)
                    {
                        Questionaries person = all[i];
                        all.Remove(all[i]);
                        DeleteLikeATrash(trashAndReasons, person, "Нет полного ФИО!");
                    }
                    else
                        continue;
                }
            }
            return all;
        }

        public static List<Questionaries> NormalizeNames(List<Questionaries> all)
        {
            foreach (var person in all)
            {
                string[] fullname = person.FullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < fullname.Length; i++)
                {
                    string item = fullname[i];

                    fullname[i] = char.ToUpper(item[0]) + item.Substring(1).ToLower();
                }

                person.FullName = string.Join(" ", fullname);
            }
            return all;
        }
        public static List<Questionaries> FixEmails(List<Questionaries> all)
        {
            for (int i = all.Count - 1; i >= 0; i--)
            {
                string email = all[i].Email.ToLower();

                int dogIndex = email.IndexOf('@');

                if (dogIndex <= 0 || dogIndex != email.LastIndexOf('@'))
                {
                    Questionaries person = all[i];
                    all.RemoveAt(i);

                    DeleteLikeATrash(trashAndReasons, person, "Неверное положение собачки");
                    continue;
                }

                string beforeDog = email.Substring(0, dogIndex);
                string afterDog = email.Substring(dogIndex + 1);

                if (afterDog == string.Empty || !afterDog.Contains('.'))
                {
                    Questionaries person = all[i];
                    all.RemoveAt(i);
                    DeleteLikeATrash(trashAndReasons, person, "Нет домена");
                    continue;
                }

                int dotIndex = afterDog.IndexOf('.');

                if (dotIndex == 0 ||
                    dotIndex == afterDog.Length - 1)
                {
                    Questionaries person = all[i];
                    all.RemoveAt(i);

                    DeleteLikeATrash(trashAndReasons, person, "Неверный домен");
                    continue;
                }

                all[i].Email = email;
            }

            return all;
        }

        public static List<Questionaries> FixPhoneNumbers(List<Questionaries> all)
        {
            for (int i = all.Count - 1; i >= 0; i--)
            {
                string phone = all[i].PhoneNumber;

                phone = new string(phone.Where(char.IsDigit).ToArray());

                if (phone.Length != 11 || (phone[0] != '7' && phone[0] != '8'))
                {
                    Questionaries person = all[i];
                    all.RemoveAt(i);

                    DeleteLikeATrash(trashAndReasons, person, "Неверный номер телефона (меньше 11 символов, не из России)");
                    continue;
                }

                if (phone[0] == '8')
                {
                    phone = "7" + phone.Substring(1);
                }

                all[i].PhoneNumber = $"+7 ({phone.Substring(1, 3)}) " +
                                     $"{phone.Substring(4, 3)}-" +
                                     $"{phone.Substring(7, 2)}-" +
                                     $"{phone.Substring(9, 2)}";
            }

            return all;
        }

        public static List<Questionaries> FixGroups(List<Questionaries> all)
        {
            for (int i = all.Count - 1; i >= 0; i--)
            {
                string group = all[i].Group;

                group = group.Replace(" ", "").ToLower();

                if (group == string.Empty)
                {
                    Questionaries person = all[i];
                    all.RemoveAt(i);
                    DeleteLikeATrash(trashAndReasons, person, "Нет группы");
                    continue;
                }
                all[i].Group = group;
            }
            return all;
        }

        public static List<Questionaries> SortQuestionaries(List<Questionaries> all)
        {
            all.Sort((a, b) => a.FullName.CompareTo(b.FullName));
            return all;
        }

        public static Dictionary<Questionaries, string> DeleteLikeATrash(Dictionary<Questionaries, string> dict,
            Questionaries person, string reason)
        {
            if (!dict.ContainsKey(person))
            {
                dict.Add(person, reason);
            }
            return dict;
        }

        public static void SaveInNewFiles(List<Questionaries> good, Dictionary<Questionaries, string> trash)
        {
            string okName = "ok.txt";
            string errorsName = "errors.txt";

            using (StreamWriter sw = new StreamWriter(okName))
            {
                for (int j = 0; j < good.Count; j++)
                {
                    sw.WriteLine(
                        $"{j + 1}; {good[j].FullName}; {good[j].Email}; " +
                        $"{good[j].PhoneNumber}; {good[j].Group}");
                }
            }

            using (StreamWriter sw = new StreamWriter(errorsName))
            {
                int j = 1;

                foreach (var person in trash)
                {
                    sw.WriteLine(
                        $"{j}; {person.Key.FullName}; {person.Key.Email}; " +
                        $"{person.Key.PhoneNumber}; {person.Key.Group}; " +
                        $"Причина: {person.Value}");
                    j++;
                }
            }
        }
    }
}