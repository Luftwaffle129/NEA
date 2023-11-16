using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.SearchList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NEALibrarySystem
{
    public class DeleteHandler
    {
        private ListView _listViewSelectedItems;
        /// <summary>
        /// Used to initialise the listview
        /// </summary>
        /// <param name="listview">listview in the delete panel</param>
        public DeleteHandler(ListView listview) 
        {
            listview.View = View.Details;
            listview.LabelEdit = false;
            listview.AllowColumnReorder = false;
            listview.CheckBoxes = false;
            listview.MultiSelect = false;
            listview.FullRowSelect = false;
            listview.GridLines = false;
            listview.Sorting = SortOrder.None;
            listview.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listview.Scrollable = true;
            _listViewSelectedItems = listview;
        }
        public void Load(ListView.CheckedListViewItemCollection selectedItems)
        {
            SearchedItemsHandler.LoadProperties(ref _listViewSelectedItems, FrmMainSystem.Main.CurrentFeature);
            if (selectedItems.Count > 0)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    string[] newItem = new string[item.SubItems.Count];
                    for (int i = 0; i < item.SubItems.Count; i++)
                    {
                        newItem[i] = item.SubItems[i].Text;
                    }
                    ListViewItem row = new ListViewItem(newItem);
                    _listViewSelectedItems.Items.Add(row);
                }
            }
            _listViewSelectedItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void Delete()
        {
            frmConfirmation confirmation = new frmConfirmation("Are you sure you want to delete these items?");
            confirmation.ShowDialog();
            if (_listViewSelectedItems.Items.Count > 0)
            {
                if (confirmation.DialogResult == DialogResult.Yes)
                {
                    foreach (ListViewItem item in _listViewSelectedItems.Items)
                    {
                        switch (FrmMainSystem.Main.CurrentFeature)
                        {
                            case (DataLibrary.Feature.Book):
                                if (DataLibrary.Books.Count > 0)
                                {
                                    int i = 0;
                                    bool removed = false;
                                    do
                                    {
                                        if (DataLibrary.Books[i].ISBN == item.SubItems[1].Text)
                                        {
                                            DataLibrary.Books.RemoveAt(i);
                                            removed = true;
                                        }
                                    } while (++i < DataLibrary.Books.Count && !removed);
                                }
                                break;
                            case (DataLibrary.Feature.Member):
                                if (DataLibrary.Members.Count > 0)
                                {
                                    int i = 0;
                                    bool removed = false;
                                    do
                                    {
                                        if (DataLibrary.Members[i].Barcode == item.SubItems[0].Text)
                                        {
                                            DataLibrary.Members.RemoveAt(i);
                                            removed = true;
                                        }
                                    } while (++i < DataLibrary.Members.Count && !removed);
                                }
                                break;
                        }
                    }
                }
                _listViewSelectedItems.Items.Clear();
            }
        }
        public void Cancel()
        {
            FrmMainSystem.Main.NavigatorCloseAllPanels();
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
