using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reader
{
    public partial class ReaderForm : Form
    {
        MangaReader reader;

        Manga manga;
        Chapter chapter;
        Page page;

        int imageXOffset;
        int imageYOffset;

        int controlYOffset;
        int controlXOffset;

        int chapterBoxOffset;
        int pageBoxOffset;

        int prevOffset;
        int nextOffset;

        public ReaderForm()
        {
            InitializeComponent();
        }

        private void nameBox_SelectedIndexChanged(object sender, EventArgs e)
        {

            loadManga((nameBox.SelectedItem as MangaData).Name, true);
            loadChapter(1, true);
            loadPage(1);

            loadImage();

        }

        private void chapterBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChapter(int.Parse(chapterBox.SelectedItem.ToString()), true);
            loadPage(1);

            loadImage();
        }

        private void pageBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadPage(int.Parse(pageBox.SelectedItem.ToString()));

            loadImage();
        }

        private async void loadManga(string name, bool d = false)
        {
            manga = new Manga(reader, name);

            chapterBox.Items.Clear();

            int count = await manga.GetChaptersAsync();

            for (int i = 1; i <= count; i++)
                chapterBox.Items.Add(i);

            if (d)
                chapterBox.SelectedIndex = 0;
        }

        private async void loadChapter(int number, bool d = false)
        {
            chapter = new Chapter(manga, number);

            pageBox.Items.Clear();

            int count = await chapter.GetPagesAsync();

            for (int i = 1; i <= count; i++)
                pageBox.Items.Add(i);

            if (d)
                pageBox.SelectedIndex = 0;
        }

        private void loadPage(int number)
        {
            page = new Page(chapter, number);
        }

        private async void loadImage()
        {
            string url = await page.GetImageAsync();
            imageBox.Load(url);
        }

        private async void loadList()
        {
            reader = new MangaReader();

            IList<MangaData> data = await reader.GetDataAsync();

            foreach (MangaData mangaData in data)
                nameBox.Items.Add(mangaData);
        }

        private void ReaderForm_Load(object sender, EventArgs e)
        {
            imageXOffset = Width - (imageBox.Location.X + imageBox.Width);
            imageYOffset = Height - (imageBox.Location.Y + imageBox.Height);

            controlXOffset = Width - (nameBox.Location.X + nameBox.Width);
            controlYOffset = Height - (nameBox.Location.Y + nameBox.Height);

            chapterBoxOffset = chapterBox.Location.X - (nameBox.Location.X + nameBox.Width);
            pageBoxOffset = pageBox.Location.X - (nameBox.Location.X + nameBox.Width);

            prevOffset = prevButton.Location.X - (nameBox.Location.X + nameBox.Width);
            nextOffset = nextButton.Location.X - (nameBox.Location.X + nameBox.Width);

            imageBox.SizeMode = PictureBoxSizeMode.Zoom;

            loadList();
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            if (pageBox.SelectedIndex > 0)
                pageBox.SelectedIndex--;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (pageBox.SelectedIndex < pageBox.Items.Count - 1)
                pageBox.SelectedIndex++;
        }

        private void ReaderForm_SizeChanged(object sender, EventArgs e)
        {
            imageBox.Width = Width - imageXOffset - imageBox.Location.X;
            imageBox.Height = Height - imageYOffset - imageBox.Location.Y;

            int nameBoxY = Height - controlYOffset - nameBox.Height;
            int nameBoxWidth = Width - controlXOffset - nameBox.Location.X;

            nameBox.Location = new Point(nameBox.Location.X, Height - controlYOffset - nameBox.Height);
            nameBox.Width = nameBoxWidth;

            int chapterBoxX = nameBox.Location.X + nameBoxWidth + chapterBoxOffset;
            int chapterBoxY = Height - controlYOffset - chapterBox.Height;

            int pageBoxX = nameBox.Location.X + nameBoxWidth + pageBoxOffset;
            int pageBoxY = Height - controlYOffset - pageBox.Height;

            chapterBox.Location = new Point(chapterBoxX, chapterBoxY);
            pageBox.Location = new Point(pageBoxX, pageBoxY);

            int prevX = nameBox.Location.X + nameBoxWidth + prevOffset;
            int prevY = Height - controlYOffset - prevButton.Height;

            int nextX = nameBox.Location.X + nameBoxWidth + nextOffset;
            int nextY = Height - controlYOffset - nextButton.Height;

            prevButton.Location = new Point(prevX, prevY);
            nextButton.Location = new Point(nextX, nextY);
        }
    }
}
