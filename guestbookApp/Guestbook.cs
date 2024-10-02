using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace guestbook
{
    public class Guestbook
    {
        private string filename = @"guestbook.json"; // Fil att skriva till
        private List<Post> posts = new List<Post>(); // Lista med Post-objekt


        public Guestbook()
        {
            if (File.Exists(filename) == false) // Om json fil inte finns
            {
                string content = "[]"; // Innehåll i json fil
                File.WriteAllText(filename, content); // Skapa json fil och lägg till innehåll
            }
            string jsonString = File.ReadAllText(filename); // Läs in all text från fil
            posts = JsonSerializer.Deserialize<List<Post>>(jsonString)!; // Deserialisera och spara i lista av Post
        }


        // Get-metod, returnerar lista av Post(inlägg)-objekt     
        public List<Post> GetPosts()
        {
            return posts;
        }

        // Metod för att lägga till inlägg i gästboken
        public Post AddPost(string name, string message)
        {
            Post post = new Post();
            post.Name = name;
            post.Message = message;
            posts.Add(post);
            marshal();
            return post;
        }

        // Metod för att ta bort inlägg från gästboken
        public int delPost(int index)
        {
            posts.RemoveAt(index);
            marshal();
            return index;
        }

        // Metod för serialisering och spara till json-fil
        private void marshal()
        {
            // Serialisera alla objekt och spara till fil
            var jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(filename, jsonString);
        }


    }
}