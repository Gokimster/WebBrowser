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
        History history;
        Favourites fMgr;
        HomePage hp;
        public GUI()
        {
            InitializeComponent();
            history = new History();
            fMgr = new Favourites();
            popluateFavourites();
            hp = new HomePage();
            loadHomePage();
            updateButtons();
        }

        private void loadHomePage()
        {
            string pageUrl = hp.getHomePageUrl();
            if (pageUrl!= null)
            {
                loadPage(pageUrl);
                history.addPage(pageUrl);
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
            ContainerControl cc = new ContainerControl();
            cc.BackColor = Color.White;
            ToolStripControlHost c = new ToolStripControlHost(cc);
            Button b = new Button();
            b.Parent = cc;
            initRemoveFavButton(b);
            b.Click += (s, e) => { favMenu.DropDownItems.Remove(c);fMgr.removeFavourite(f); };
            Button temp = new Button();
            temp.Text = f.name;
            temp.Click += (s, e) => { loadPage(f.url); history.addPage(address.Text); };
            temp.Parent = cc;
            temp.Left = b.Size.Width;
            initFavButton(temp);
            favMenu.DropDownItems.Add(c);
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
            favMenu.DropDownItems.Clear();
            popluateFavourites();
        }
        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                history.addPage(address.Text);
                loadPage(address.Text);
            }
        }
        private void address_GotFocus(object sender, KeyEventArgs e)
        {
            address.SelectAll();
        }

        private void favBtn_Click(object sender, EventArgs e)
        {
            fMgr.addFavourite(address.Text, favNameBox.Text);
            favNameBox.Text = "Favourite Name";
            updateFavourites();
        }

        private void loadPage(string url)
        {
            pageContent.Text = WebManager.getPage(url);
            //this writes the same text to the adress bar if called from address_KeyDown 
            //but better to have it here than duplicate the same line everywhere we need to set the text
            address.Text = url;
            updateButtons();
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
    }
}
