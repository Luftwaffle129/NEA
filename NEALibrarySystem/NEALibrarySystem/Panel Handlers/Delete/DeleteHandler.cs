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
        /// <param name="listview">Listview in the delete panel</param>
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
        /// <summary>
        /// Sets up the list view
        /// </summary>
        /// <param name="selectedItems">Collection of the items to be displayed in the listview</param>
        public void Load(ListView.CheckedListViewItemCollection selectedItems)
        {
            // loads the correct columns for the selected record type
            SearchHandler.LoadColumns(ref _listViewSelectedItems, FrmMainSystem.Main.SearchFeature);
            if (selectedItems.Count > 0)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    string[] newItem = new string[item.SubItems.Count]; // create an array to store the new subitems
                    for (int i = 0; i < item.SubItems.Count; i++)       // add each subitem into the new array
                    {
                        newItem[i] = item.SubItems[i].Text;
                    }
                    ListViewItem row = new ListViewItem(newItem);       // convert the array to the correct format for the listview
                    _listViewSelectedItems.Items.Add(row);
                }
            }
            _listViewSelectedItems.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        /// <summary>
        /// Deletes the selected items in the list view
        /// </summary>
        public void Delete()
        {
            if (_listViewSelectedItems.Items.Count > 0)
            {
                // use a confirmation box to ensure the user wants to delete the items
                frmConfirmation confirmation = new frmConfirmation("Are you sure you want to delete these items?");
                confirmation.ShowDialog();
                if (confirmation.DialogResult == DialogResult.Yes)
                {
                    foreach (ListViewItem item in _listViewSelectedItems.Items)
                    {
                        // identifies what type of record is being deleted
                        switch (FrmMainSystem.Main.CurrentFeature)
                        {
                            case (DataLibrary.Feature.Book):
                                DataLibrary.DeleteBook(DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[1].Text, SearchAndSort.RefClassAndString)].Reference);
                                break;
                            case (DataLibrary.Feature.Member):
                                DataLibrary.DeleteMember(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                                break;
                        }
                    }
                }
                _listViewSelectedItems.Items.Clear();
            }
        }
        /// <summary>
        /// Closes the delete panel
        /// </summary>
        public void ClosePanel()
        {
            FrmMainSystem.Main.NavigatorOpenSearchViewTab();
        }
    }
}
