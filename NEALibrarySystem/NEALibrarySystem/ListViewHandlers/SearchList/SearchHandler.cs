using NEALibrarySystem.Data_Structures;
using NEALibrarySystem.ListViewHandlers;
using NEALibrarySystem.ListViewHandlers.SearchList;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace NEALibrarySystem.SearchList
{
    public class SearchHandler
    {
        private SearchObjects _objects;

        private List<Book> _bookResultList = new List<Book>();
        private List<Member> _memberResultList = new List<Member>();
        private List<CirculationCopy> _circCopyResultList = new List<CirculationCopy>();
        private string search;
        private int _currentColumn;
        public SearchHandler(SearchObjects objects)
        {
            _objects = objects;
            _objects.ItemViewer.View = View.Details;
            _objects.ItemViewer.LabelEdit = false;
            _objects.ItemViewer.AllowColumnReorder = false;
            _objects.ItemViewer.CheckBoxes = true;
            _objects.ItemViewer.MultiSelect = true;
            _objects.ItemViewer.FullRowSelect = true;
            _objects.ItemViewer.GridLines = false;
            _objects.ItemViewer.Sorting = SortOrder.None;
            _objects.ItemViewer.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            _objects.ItemViewer.Scrollable = true;
        }
        #region loading
        public void SetUpSearchTab()
        {

            switch (FrmMainSystem.Main.SearchFeature)
            {
                case DataLibrary.SearchFeature.Book:
                    ToBook();
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    ToCirculation();
                    break;
                case DataLibrary.SearchFeature.Member:
                    ToMember();
                    break;
                case DataLibrary.SearchFeature.Staff:

                    break;
            }
        }
        public void ToBook()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Book);
            _objects.Delete.Visible = true;
            UpdateListView(DataLibrary.Books);
        }
        public void ToCirculation()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Circulation);
            _objects.Delete.Visible = true;
            UpdateListView(DataLibrary.CirculationCopies);
        }
        public void ToMember()
        {
            LoadColumns(ref _objects.ItemViewer, DataLibrary.SearchFeature.Member);
            _objects.Delete.Visible = true;
            UpdateListView(DataLibrary.Members);
        }
        public static void LoadColumns(ref ListView lsv, DataLibrary.SearchFeature feature)
        {
            lsv.Clear();

            string[] columns = new string[0];
            switch (feature)
            {
                case DataLibrary.SearchFeature.Member:
                    columns = new string[4]
                    {
                        "Barcode",
                        "First Name",
                        "Surname",
                        "Member Type"
                    };
                    break;
                case DataLibrary.SearchFeature.Book:
                    columns = new string[8]
                    {
                        "ISBN",
                        "Title",
                        "Series Title",
                        "Media Type",
                        "Author",
                        "Publisher",
                        "Genres",
                        "Themes"
                    };
                    break;
                case DataLibrary.SearchFeature.Circulation:
                    columns = new string[]
                    {
                        "ID",
                        "Barcode",
                        "Title",
                        "Series Title",
                        "Author",
                        "Date",
                        "Status",
                        "Due Date",
                        "Member Barcode"
                    };
                    break;
            }
            ListViewHandler.SetColumns(columns, ref lsv);
        }
        #endregion
        public void Delete()
        {
            if (_objects.ItemViewer.CheckedItems.Count > 0)
            {
                // output a confirmation message
                string itemType = "";
                frmConfirmation confirmation;
                // get the type of item being deleted
                switch (FrmMainSystem.Main.SearchFeature)
                {
                    case DataLibrary.SearchFeature.Member:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "member";
                        else
                            itemType = "members";
                        break;
                    case DataLibrary.SearchFeature.Book:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "book";
                        else
                            itemType = "books";
                        break;
                    case DataLibrary.SearchFeature.Circulation:
                        if (_objects.ItemViewer.CheckedItems.Count == 1)
                            itemType = "loan/reservation";
                        else
                            itemType = "loans/reservations";
                        break;
                    case DataLibrary.SearchFeature.Staff:
                        itemType = "staff";
                        break;
                }
                // output the confirmation message
                if (_objects.ItemViewer.CheckedItems.Count == 1)
                    confirmation = new frmConfirmation($"Do you want do delete 1 {itemType}?");
                else
                    confirmation = new frmConfirmation($"Do you want do delete {_objects.ItemViewer.CheckedItems.Count} {itemType}?");
                confirmation.ShowDialog();
                if (confirmation.DialogResult == DialogResult.Yes)
                {
                    switch (FrmMainSystem.Main.SearchFeature)
                    {
                        case DataLibrary.SearchFeature.Member:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteMember(DataLibrary.MemberBarcodes[SearchAndSort.Binary(DataLibrary.MemberBarcodes, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Book:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteBook(DataLibrary.Isbns[SearchAndSort.Binary(DataLibrary.Isbns, item.SubItems[0].Text, SearchAndSort.RefClassAndString)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Circulation:
                            foreach (ListViewItem item in _objects.ItemViewer.CheckedItems)
                                DataLibrary.DeleteCirculationCopy(DataLibrary.CirculationDates[SearchAndSort.Binary(DataLibrary.CirculationDates, Convert.ToDateTime(item.SubItems[4].Text), SearchAndSort.RefClassAndDate)].Reference);
                            break;
                        case DataLibrary.SearchFeature.Staff:
                            break;
                    }
                    FrmMainSystem.Main.DisplayProcessMessage($"Deleted {itemType}");
                    ToBook();
                }
            }
            else
                MessageBox.Show("No items selected");
        }
        #region UpdateListView
        public void UpdateListView(List<Member> memberList)
        {
            foreach (Member member in memberList)
            {
                string[] data = new string[4]
                {
                member.Barcode.Value,
                member.FirstName.Value,
                member.Surname.Value,
                member.Type.Value.ToString()
                };
                ListViewItem row = new ListViewItem(data);
                _objects.ItemViewer.Items.Add(row);
            }
            _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public void UpdateListView(List<Book> bookList)
        {
            foreach (Book book in bookList)
            {
                string[] data =
                {
                    book.Isbn.Value,
                    book.Title.Value,
                    book.SeriesTitle.Value,
                    book.MediaType.Value,
                    book.Author.Value,
                    book.Publisher.Value,
                    DataFormatter.ListToString(book.Genres),
                    DataFormatter.ListToString(book.Themes)
                };
                ListViewItem row = new ListViewItem(data);
                _objects.ItemViewer.Items.Add(row);
            }
            _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        public void UpdateListView(List<CirculationCopy> circulationCopyList)
        {
            foreach (CirculationCopy copy in circulationCopyList)
            {
                string[] data =
                {
                    copy.Id.Value.ToString(),
                    copy.BookCopy.Barcode.Value,
                    copy.BookCopy.BookRelation.Book.Title.Value,
                    copy.BookCopy.BookRelation.Book.SeriesTitle.Value,
                    copy.BookCopy.BookRelation.Book.Author.Value,
                    DataFormatter.GetDateAndTime(copy.Date.Value),
                    copy.Type.Value.ToString(),
                    DataFormatter.GetDate(copy.DueDate.Value),
                    copy.CircMemberRelation.Member.Barcode.Value.ToString()
                };
                ListViewItem row = new ListViewItem(data);
                _objects.ItemViewer.Items.Add(row);
            }
            _objects.ItemViewer.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        #endregion
        #region searching
        /// <summary>
        /// Applies a s
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public List<F> ApplyFilter<T, F>(List<ReferenceClass<T, F>> list, T item, SearchAndSort.Compare<T, ReferenceClass<T, F>> compare) where F : class
        {
            List<F> resultList = new List<F>();
            int[] bounds = SearchAndSort.BinaryRange(list, item, compare);
            if (bounds[0] != -1)
                for (int i = bounds[0]; i <= bounds[1]; i++)
                    resultList.Add(list[i].Reference);
            return resultList;
        }
        #region book
        /// <summary>
        /// Finds all books that contain the specified item in any of its properties
        /// </summary>
        /// 
        /// Algorithm method:
        /// Get lists of valid books for each property
        /// 
        /// Do until all lists are empty:
        ///     Get the first (smallest) book in each list
        ///     Find the smallest book out of all of the list based on the ISBN
        /// 
        /// <param name="item">items to </param>
        /// <returns>List of books that match the search term</returns>
        public List<Book> BookSearch(string item)
        {
            // Get lists of valid books for each property
            List<Book> isbns = ApplyFilter(DataLibrary.Isbns, item, SearchAndSort.RefClassAndString);
            isbns = SearchAndSort.QuickSort<Book, Book>(isbns, SearchAndSort.TwoBooks);
            List<Book> titles = ApplyFilter(DataLibrary.Titles, item, SearchAndSort.RefClassAndString);
            titles = SearchAndSort.QuickSort<Book, Book>(titles, SearchAndSort.TwoBooks);
            List<Book> seriesTitles = ApplyFilter(DataLibrary.SeriesTitles, item, SearchAndSort.RefClassAndString);
            seriesTitles = SearchAndSort.QuickSort<Book, Book>(seriesTitles, SearchAndSort.TwoBooks);
            List<Book> mediaTypes = ApplyFilter(DataLibrary.MediaTypes, item, SearchAndSort.RefClassAndString);
            mediaTypes = SearchAndSort.QuickSort<Book, Book>(mediaTypes, SearchAndSort.TwoBooks);
            List<Book> authors = ApplyFilter(DataLibrary.Authors, item, SearchAndSort.RefClassAndString);
            authors = SearchAndSort.QuickSort<Book, Book>(authors, SearchAndSort.TwoBooks);
            List<Book> publishers = ApplyFilter(DataLibrary.Publishers, item, SearchAndSort.RefClassAndString);
            publishers = SearchAndSort.QuickSort<Book, Book>(publishers, SearchAndSort.TwoBooks);
            List<Book> genres = ApplyFilter(DataLibrary.Genres, item, SearchAndSort.RefClassAndString);
            genres = SearchAndSort.QuickSort<Book, Book>(genres, SearchAndSort.TwoBooks);
            List<Book> themes = ApplyFilter(DataLibrary.Themes, item, SearchAndSort.RefClassAndString);
            themes = SearchAndSort.QuickSort<Book, Book>(themes, SearchAndSort.TwoBooks);

            List<Book> results = new List<Book>();
            bool finished = false;
            do
            {
                List<SmallestBook> books = new List<SmallestBook>();
                // Get the first(smallest) book in each list
                if (isbns.Count > 0)
                    books.Add(new SmallestBook(isbns[0], 0));
                if (titles.Count > 0)
                    books.Add(new SmallestBook(titles[0], 0));
                if (seriesTitles.Count > 0)
                    books.Add(new SmallestBook(seriesTitles[0], 0));
                if (mediaTypes.Count > 0)
                    books.Add(new SmallestBook(mediaTypes[0], 0));
                if (authors.Count > 0)
                    books.Add(new SmallestBook(authors[0], 0));
                if (publishers.Count > 0)
                    books.Add(new SmallestBook(publishers[0], 0));
                if (genres.Count > 0)
                    books.Add(new SmallestBook(genres[0], 0));
                if (themes.Count > 0)
                    books.Add(new SmallestBook(themes[0], 0));
                if (books.Count > 0)
                {
                    // Find the smallest book out of all of the list based on the ISBN
                    int index = GetSmallest(books);
                    if (index != -1)
                    {
                        // check if book has already been added
                        if (books[index].Book != results[results.Count - 1])
                            results.Add(books[index].Book);
                        switch (index)
                        {
                            case 0:
                                isbns.RemoveAt(0);
                                break;
                            case 1:
                                titles.RemoveAt(0);
                                break;
                            case 2:
                                seriesTitles.RemoveAt(0);
                                break;
                            case 3:
                                mediaTypes.RemoveAt(0);
                                break;
                            case 4:
                                authors.RemoveAt(0);
                                break;
                            case 5:
                                publishers.RemoveAt(0);
                                break;
                            case 6:
                                genres.RemoveAt(0);
                                break;
                            case 7: 
                                themes.RemoveAt(0);
                                break;
                        }
                    }
                }
                else
                    finished = true;
            } while (!finished);
            return results;
        }
        /// <summary>
        /// Stores smallest book
        /// </summary>
        private class SmallestBook
        {
            public Book Book; // smallest book
            public int Column; // column of the smallest book

            public SmallestBook(Book book, int column)
            {
                Book = book;
                Column = column;
            }
        }
        private int GetSmallest(List<SmallestBook> list)
        {
            int smallest = 0;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (SearchAndSort.TwoStrings(list[i].Book.Isbn.Value, list[smallest].Book.Isbn.Value) == Greatest.Right)
                        smallest = i;
                }
                return smallest;
            }
            return -1;
        }
        #endregion
        #endregion
    }
}