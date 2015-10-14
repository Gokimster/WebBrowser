using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class GUI : Form
    {
        FavouritesMgr fMgr;
        HomePageMgr hpMgr;
        public GUI()
        {
            InitializeComponent();
            fMgr = new FavouritesMgr();
            popluateFavourites();
            hpMgr = new HomePageMgr();
            loadHomePage();
        }

        private void loadHomePage()
        {
            string pageUrl = hpMgr.getHomePageUrl();
            if (pageUrl!= null)
            {
                loadPage(pageUrl);
                address.Text = pageUrl;
            }
        }

        private void popluateFavourites()
        {
            foreach(Favourite f in fMgr.getFavourites().Values)
            {
                addFavToMenu(f);
            }
        }

        private void addFavToMenu(Favourite f)
        {
            ToolStripButton temp = new ToolStripButton(f.name);
            temp.Click += (s, e) => { loadPage(f.url);address.Text = f.url; };
            favMenu.DropDownItems.Add(temp);
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadPage(address.Text);
            }
        }
        private void address_GotFocus(object sender, KeyEventArgs e)
        {
            address.SelectAll();
        }

        private void favBtn_Click(object sender, EventArgs e)
        {
            fMgr.addFavourite(address.Text, "test");
        }

        private void loadPage(string url)
        {
            pageContent.Text = WebManager.getPage(url);
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            hpMgr.setHomePage(address.Text);
        }
    }
}
