using System;
using System.Collections;
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
        Favourites favs;
        HomePage hp;
        ArrayList tabs;
        public GUI()
        {
            InitializeComponent();
            tabs = new ArrayList();
            history = new History();
            favs = new Favourites();
            popluateFavourites();
            hp = new HomePage();
            initNewTab();
        }

        private void initNewTab()
        {
            TabPage tab = new TabPage();
            WebTab x = new WebTab(favs, hp);
            tab.Controls.Add(x);
            tabControl1.Controls.Add(tab);
        }

        private void popluateFavourites()
        {
            foreach(Favourite f in favs.getFavourites().Values)
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
            b.Click += (s, e) => { favMenu.DropDownItems.Remove(c);favs.removeFavourite(f); };
            Button temp = new Button();
            temp.Text = f.name;
            temp.Click += (s, e) => { initNewTab(); ; };
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
    }
}
