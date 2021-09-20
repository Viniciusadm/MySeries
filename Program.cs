using System;
using System.Collections.Generic;
using MySeries.Classes;
using MySeries.Enums;

namespace MySeries {
    class Program {
        static SerieRepository repository = new SerieRepository();
        static void Main(string[] args) {
            char option = GetOption();

            while (option != '7') {
                switch (option) {
                    case '1':
                        ListSeries();
                        break;
                    case '2':
                        InsertSerie();
                        break;
                    case '3':
                        UpdateSerie();
                        break;
                    case '4':
                        DeleteSerie();
                        break;
                    case '5':
                        ViewSerie();
                        break;
                    case '6':
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                option = GetOption();
            }
            Console.WriteLine("Obrigado por ultilizar nosso serviço");

        }
        private static void ListSeries() {
            if (repository.List().Count == 0)
                Console.WriteLine("Nenhuma série cadastrada");
            else 
                foreach (Series serie in repository.List())
                    if (serie.deleted == false)
                        Console.WriteLine($"ID: {serie.ID}: {serie.Title}");   
        }
        private static void InsertSerie() {
            Console.WriteLine("Inserir nova série");
            foreach (int i in Enum.GetValues(typeof(Genre))) {
                Console.WriteLine($"{i}- {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string description = Console.ReadLine();

            Series serie = new Series(repository.NextId(), (Genre)genre, title, description, year);
            repository.Insert(serie);
        }
        public static void UpdateSerie() {
            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre))) {
                Console.WriteLine($"{i}- {Enum.GetName(typeof(Genre), i)}");
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int genre = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string title = Console.ReadLine();

            Console.Write("Digite o ano da série: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string description = Console.ReadLine();
            
            Series serie = new Series(id, (Genre)genre, title, description, year);
            repository.Update(id, serie);
        }
        public static void DeleteSerie() {
            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            repository.Delete(id);
        }
        public static void ViewSerie() {
            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            Series serie = repository.GetID(id);
            Console.WriteLine(serie);
        }
        private static char GetOption() {
            Console.WriteLine("\nBanco de séries");
            Console.WriteLine("Escolha a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("6- Limpar tela");
            Console.WriteLine("7- Sair");

            char option = Char.Parse(Console.ReadLine());
            return option;
        } 
    }
}
