using System.Text.Json;
using System.Text.Json.Serialization;
using GraphQLBooks.Models;

namespace GraphQLBooks.GraphQL
{
    public class Query
    {
        // public List<Book> Books => ReadFile<Book>("books");
        public List<Magazine> Magazines => ReadFile<Magazine>("magazines");
        public List<IReadingMaterials> ReadingMaterials => GetReadingMaterials();
        public List<IThings> Things => GetThings();

        public List<Book> Books(string nameContains = "")
        {
            var books = ReadFile<Book>("books");
            return [.. books.Where(r => r.Name.Contains(nameContains, StringComparison.InvariantCultureIgnoreCase))];
        }

        private static List<IReadingMaterials> GetReadingMaterials()
        {
            var books = ReadFile<Book>("books");
            var magazines = ReadFile<Magazine>("magazines");
            return [.. books, .. magazines];
        }

        private static List<IThings> GetThings()
        {
            var books = ReadFile<Book>("books");
            var magazines = ReadFile<Magazine>("magazines");
            return [.. books, .. magazines];
        }

        private static List<T> ReadFile<T>(string fileName) where T : new()
        {
            string file = $"Database/{fileName}.json";
            string jsonString = File.ReadAllText(file);
            return JsonSerializer.Deserialize<List<T>>(jsonString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new JsonStringEnumConverter() }
            })!;
        }
    }
}