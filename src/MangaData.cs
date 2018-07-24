namespace Reader
{
    public class MangaData
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public MangaData(string Name, string Text)
        {
            this.Name = Name;
            this.Text = Text;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
