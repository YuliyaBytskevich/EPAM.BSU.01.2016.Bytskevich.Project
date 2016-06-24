namespace EFModel
{
    public class TextFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }
        public int CardId { get; set; }

        // navigation
        public virtual Card Card { get; set; }
    }
}
