using System.Text;
using MySeries.Enums;

namespace MySeries.Classes {
    public class Series : Base {
        public Genre Genre { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Year { get; private set; }
        public bool deleted { get; private set; }

        public Series(int id, Genre genre, string title, string description, int year) : base(id) {
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
        }

        public void Delete() {
            this.deleted = true;
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {this.Title}");
            sb.AppendLine($"Gênero: {this.Genre}");
            sb.AppendLine($"Ano: {this.Year}");
            sb.AppendLine($"Descrição: {this.Description}");
            return sb.ToString();
        }
    }
}