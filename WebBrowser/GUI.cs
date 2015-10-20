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
        //----------------------------------------//
        //----------Fieds-------------------------//
        //----------------------------------------//
        private Favourites favs;
        private HomePage hp;
        public BrowserHistory bHistory { get; private set; }
        private ArrayList tabs;

        public GUI()
        {
            InitializeComponent();
            tabs = new ArrayList();
            favs = new Favourites();
            bHistory = new BrowserHistory();
            populateFavourites();
            populateHistory();
            hp = new HomePage();
            initNewTab();
        }

        //----------------------------------------//
        //----------Methods-----------------------//
        //----------------------------------------//

        //create a new tab which loads the home page
        private void initNewTab()
        {
            TabPage tab = new TabPage();
            WebTab x = new WebTab(favs, hp);
            tab.Controls.Add(x);
            tabControl1.Controls.Add(tab);
            tab.Text = "Tab " + tabControl1.Controls.Count;
        }

        //create a new tab which loads a given url
        private void initNewTab(string url)
        {
            TabPage tab = new TabPage();
            WebTab x = new WebTab(favs, hp, url);            
            tab.Controls.Add(x);
            tabControl1.Controls.Add(tab);
            tab.Text = "Tab " + tabControl1.Controls.Count;
        }

        //dynamically add an item to the history drop down menu
        //given a page
        private void addPageToHistoryMenu(Page p)
        {
            ContainerControl cc = new ContainerControl();
            cc.BackColor = Color.White;
            ToolStripControlHost c = new ToolStripControlHost(cc);
            Button temp = new Button();
            temp.Text = p.url;
            temp.Click += (s, e) => { initNewTab();};
            temp.Parent = cc;
            initMenuButton(temp);
            historyMenu.DropDownItems.Add(c);
        }

        //dynamically add an item to the favourites drop down menu given a Favourite
        public void addFavToMenu(Favourite f)
        {
            ContainerControl cc = new ContainerControl();
            cc.BackColor = Color.WhiteSmoke;
            ToolStripControlHost c = new ToolStripControlHost(cc);
            Button b = new Button();
            b.Parent = cc;
            initRemoveFavButton(b);
            b.Click += (s, e) => { favMenu.DropDownItems.Remove(c);favs.removeFavourite(f); };
            TextBox temp = new TextBox();
            temp.Text = f.name;
            temp.Click += (s, e) => { initNewTab(f.url); };
            temp.Parent = cc;
            temp.Left = b.Size.Width;
            temp.Left = (int)Math.Floor((float)temp.Left * 1.3f);
            initFavBox(temp);
            Button t = new Button();
            t.Text = f.url;
            t.Parent = cc;
            initMenuButton(t);
            t.Top = temp.Height>b.Height?temp.Height :b.Height;
            t.Top = (int)Math.Floor((float)t.Top * 1.1f);
            t.Left = temp.Left;
            t.Enabled = false;
            Button eb = new Button();
            eb.Parent = cc;
            eb.Left = temp.Left + temp.Size.Width;
            eb.Click += (s, e) => editButtonClick(temp, eb, f);
            initEditButton(eb);
            favMenu.DropDownItems.Add(c);
        }

        //style for the remove button for a favourite in the menu
        private void initRemoveFavButton(Button x)
        {
            x.Text = "X";
            x.FlatStyle = FlatStyle.Flat;
            x.ForeColor = Color.Red;
            x.AutoSize = true;
            x.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            x.Left = 0;
        }

        //style for text box with the favourite name
        private void initFavBox(TextBox b)
        {
            b.AutoSize = true;
            b.ReadOnly = true;
            b.BorderStyle = BorderStyle.None;
            b.BackColor = b.Parent.BackColor;
        }

        private void initMenuButton(Button b)
        {
            b.AutoSize = true;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = b.Parent.BackColor;
        }

        private void initEditButton(Button b)
        {
            b.Text = "E";
            b.FlatStyle = FlatStyle.Flat;
            b.ForeColor = Color.Blue;
            b.AutoSize = true;
            b.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }

        private void editButtonClick(TextBox temp, Button eb, Favourite f)
        {
            temp.ReadOnly = false;
            eb.Text = "S";
            eb.ForeColor = Color.Green;
            eb.Click += (s, e) => confirmEditClick(temp, eb, f);
        }

        private void confirmEditClick(TextBox temp, Button eb, Favourite f)
        {
            temp.ReadOnly = true;
            eb.Text = "E";
            eb.ForeColor = Color.Blue;
            favs.changeFavName(f, temp.Text);
            eb.Click += (s, e) => editButtonClick(temp, eb, f);
        }

        public void updateFavourites()
        {
            favMenu.DropDownItems.Clear();
            populateFavourites();
        }

        public void updateHistory()
        {
            historyMenu.DropDownItems.Clear();
            populateHistory();
        }

        private void populateHistory()
        {
            foreach (Page p in bHistory.browserHistory)
            {
                addPageToHistoryMenu(p);
            }
        }
        private void populateFavourites()
        {
            foreach (Favourite f in favs.getFavourites().Values)
            {
                addFavToMenu(f);
            }
        }

        //----------------------------------------//
        //----------Events------------------------//
        //----------------------------------------//

        private void newTabMenuItem_Click(object sender, EventArgs e)
        {
            initNewTab();
        }

        private void addTabBtn_Click(object sender, EventArgs e)
        {
            initNewTab();
        }

        private void removeTabBtn_Click(object sender, EventArgs e)
        {
            tabControl1.Controls.Remove(tabControl1.SelectedTab);
        }

        private void clearHistory_Click(object sender, EventArgs e)
        {
            bHistory.clearBrowserHistory();
            updateHistory();
        }
    }
}
