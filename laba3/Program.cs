using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            // Створення об'єкта текстового редактора
            TextEditor editor = new TextEditor();
            bool exit = false;

            while (!exit)
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.WriteLine("\nОберіть дію:");
                Console.WriteLine("1. Створити новий документ");
                Console.WriteLine("2. Додати текст до документа");
                Console.WriteLine("3. Очистити документ");
                Console.WriteLine("4. Показати вміст документа");
                Console.WriteLine("5. Вийти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть назву документа: ");
                        string title = Console.ReadLine();
                        editor.CreateDocument(title);
                        break;
                    case "2":
                        if (editor.CurrentDocument != null)
                        {
                            Console.Write("Введіть текст для додавання: ");
                            string text = Console.ReadLine();
                            editor.AddTextToDocument(text);
                        }
                        else
                        {
                            Console.WriteLine("Документ ще не створено.");
                        }
                        break;
                    case "3":
                        editor.ClearDocument();
                        break;
                    case "4":
                        editor.DisplayDocument();
                        break;
                    case "5":
                        exit = true;
                        Console.WriteLine("Вихід з програми...");
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }

    class Document
    {
        public string Title { get; set; }
        public string Content { get; private set; }

        public Document(string title)
        {
            Title = title;
            Content = string.Empty;
        }

        public void AddText(string text)
        {
            Content += text + "\n";
        }

        public void ClearText()
        {
            Content = string.Empty;
        }

        public void Display()
        {
            Console.WriteLine($"--- {Title} ---");
            Console.WriteLine(Content == string.Empty ? "Документ порожній" : Content);
        }
    }

    class TextEditor
    {
        public Document CurrentDocument { get; private set; }

        public void CreateDocument(string title)
        {
            CurrentDocument = new Document(title);
            Console.WriteLine($"Документ '{title}' створено.");
        }

        public void AddTextToDocument(string text)
        {
            if (CurrentDocument != null)
            {
                CurrentDocument.AddText(text);
                Console.WriteLine("Текст додано до документа.");
            }
            else
            {
                Console.WriteLine("Документ не створено.");
            }
        }

        public void ClearDocument()
        {
            if (CurrentDocument != null)
            {
                CurrentDocument.ClearText();
                Console.WriteLine("Документ очищено.");
            }
            else
            {
                Console.WriteLine("Документ не створено.");
            }
        }

        public void DisplayDocument()
        {
            if (CurrentDocument != null)
            {
                CurrentDocument.Display();
            }
            else
            {
                Console.WriteLine("Документ не створено.");
            }
        }
    }
}

