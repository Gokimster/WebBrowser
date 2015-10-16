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
        Favourites fMgr;
        HomePage hp;
        public GUI()
        {
            InitializeComponent();
            fMgr = new Favourites();
            popluateFavourites();
            hp = new HomePage();
            loadHomePage();
        }

        private void loadHomePage()
        {
            string pageUrl = hp.getHomePageUrl();
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
            ContainerControl cc = new ContainerControl();
            cc.BackColor = Color.White;
            ToolStripControlHost c = new ToolStripControlHost(cc);
            Button b = new Button();
            b.Parent = cc;
            initRemoveFavButton(b);
            b.Click += (s, e) => { favMenu.DropDownItems.Remove(c);fMgr.removeFavourite(f); };
            Button temp = new Button();
            temp.Text = f.name;
            temp.Click += (s, e) => { loadPage(f.url);address.Text = f.url; };
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
        }

        private void homeBtn_Click(object sender, EventArgs e)
        {
            hp.setHomePage(address.Text);
        }
    }
}
