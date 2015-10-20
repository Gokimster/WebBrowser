using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WebBrowser
{
    public partial class WebTab : UserControl
    {
        History history;
        Favourites favs;
        HomePage hp;
        BackgroundWorker worker;
        public WebTab(Favourites favs, HomePage hp)
        {
            initTab(favs, hp);
            loadHomePage();
            updateButtons();
        }

        public WebTab(Favourites favs, HomePage hp, string url)
        {
            initTab(favs, hp);
            loadPage(url);
            updateButtons();
        }

        private void initTab(Favourites favs, HomePage hp)
        {
            worker = new BackgroundWorker();
            this.favs = favs;
            this.hp = hp;
            InitializeComponent();
            history = new History();
        }

        public void loadHomePage()
        {
            string pageUrl = hp.getHomePageUrl();
            if (pageUrl != null)
            {
                loadPage(pageUrl);
                addPageToHistory(pageUrl);
            }
        }

        private void addFavToMenu(Favourite f)
        {
            ((GUI)this.ParentForm).addFavToMenu(f);
        }

        private void initRemoveFavButton(Button x)
        {
            x.Text = "X";
            x.ForeColor = Color.Red;
            x.AutoSize = true;
            x.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x.Left = 0;
        }

        private void initFavButton(Button b)
        {
            b.AutoSize = true;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = b.Parent.BackColor;
        }

        private void updateFavourites()
        {
            ((GUI)this.ParentForm).updateFavourites();
        }

        private void updateHistory()
        {
            ((GUI)this.ParentForm)?.updateHistory();
        }

        private void addPageToHistory(string url)
        {
            if (history.addPage(url))
                ((GUI)this.ParentForm)?.bHistory.addToBrowserHistory(url);
            updateHistory();
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addPageToHistory(address.Text);
                loadPage(address.Text);
            }
        }
        private void address_GotFocus(object sender, KeyEventArgs e)
        {
            address.SelectAll();
        }

        private void favBtn_Click(object sender, EventArgs e)
        {
            favs.addFavourite(address.Text, favNameBox.Text);
            favNameBox.Text = "Favourite Name";
            updateFavourites();
        }

        private void loadPage(string url)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
            }
            worker.RunWorkerAsync(url);
            //this writes the same text to the adress bar if called from address_KeyDown 
            //but better to have it here than duplicate the same line everywhere we need to set the text
            address.Text = url;
        }

        private void updateButtons()
        {
            fwdBtn.Enabled = history.canGoToNext();
            backBtn.Enabled = history.canGoToPrevious();
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            hp.setHomePage(address.Text);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            loadPage(history.goToPrevious());
        }

        private void fwdBtn_Click(object sender, EventArgs e)
        {
            loadPage(history.goToNext());
        }
        
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = WebManager.getPage((string)e.Argument);
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadPageWorker((string)e.Result);
        }

        private void loadPageWorker(string html)
        {
            pageContent.Text = html;
            updateButtons();
        }
    }
}
