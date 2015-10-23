using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class WebTab : UserControl
    {
        //-----------------------------//
        //----------Fields-------------//
        //-----------------------------//
        private History history;
        private BackgroundWorker worker;
        private string workerNextURL;

        //make a new tab
        public WebTab()
        {
            initTab();
        }

        //-----------------------------//
        //----------Methods------------//
        //-----------------------------//

        //initialise main components for a new tab
        private void initTab()
        {
            workerNextURL = null;
            worker = new BackgroundWorker();
            InitializeComponent();
            history = new History();
        }

        //load the browser home page
        public void loadHomePage()
        {
            string pageUrl = ((GUI)this.ParentForm)?.hp.getHomePageUrl();
            if (pageUrl != null)
            {
                loadPage(pageUrl);
                addPageToHistory(pageUrl);
            }
        }

        //add a favourite page to the favourites menu
        private void addFavToMenu(Favourite f)
        {
            ((GUI)this.ParentForm).addFavToMenu(f);
        }

        //updates favourites menu
        private void updateFavourites()
        {
            ((GUI)this.ParentForm).updateFavourites();
        }

        //updates browser history menu
        private void updateHistory()
        {
            ((GUI)this.ParentForm)?.updateHistory();
        }

        //adds a page to tab and browser history if it hasn't just been added
        private void addPageToHistory(string url)
        {
            if (history.addPage(url))
            {
                ((GUI)this.ParentForm)?.bHistory.addToBrowserHistory(url);
                updateHistory();
            }
        }

        //loads a new page when Enter key is pressed and adds it to history
        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addPageToHistory(address.Text);
                loadPage(address.Text);
            }
        }

        //adds current page to favourites with the name given in the favourite name box
        private void favBtn_Click(object sender, EventArgs e)
        {
            ((GUI)this.ParentForm)?.favs.addFavourite(address.Text, favNameBox.Text);
            favNameBox.Text = "Favourite Name";
            updateFavourites();
        }

        //loads new page onto the tabe given an url
        public void loadPage(string url)
        {
            //update buttons even if worker is busy to disable back/forward buttons 
            //if pressed repeatedly
            updateButtons();

            //remember latest url requested - no need to load a queue of pages, only interested in latest
            if (worker.IsBusy)
            {
                workerNextURL = url;
            }
            else
            {
                worker.RunWorkerAsync(url);
                //this writes the same text to the adress bar if called from address_KeyDown 
                //but better to have it here than duplicate the same line everywhere we need to set the text
                address.Text = url;
            }
        }

        //update back and fwd buttons depending on where we are in the
        //tab history
        private void updateButtons()
        {
            fwdBtn.Enabled = history.canGoToNext();
            backBtn.Enabled = history.canGoToPrevious();
        }

        //-----------------------------//
        //----------Events------------//
        //-----------------------------//

        //sets home page to the current page in the tab
        private void homeBtn_Click(object sender, EventArgs e)
        {
            ((GUI)this.ParentForm)?.hp.setHomePage(address.Text);
        }

        //loads previous page in history
        private void backBtn_Click(object sender, EventArgs e)
        {
            loadPage(history.goToPrevious());
        }

        //loads next page in history
        private void fwdBtn_Click(object sender, EventArgs e)
        {
            loadPage(history.goToNext());
        }
        
        //async fetching of html
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = WebManager.getPage((string)e.Argument);
        }

        //once html is fetched load content and check if 
        //there is another url waiting to be loaded
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pageContent.Text =((string)e.Result);
            if(workerNextURL != null)
            {
                loadPage((string)workerNextURL);
                workerNextURL = null;
            }
        }
    }
}
